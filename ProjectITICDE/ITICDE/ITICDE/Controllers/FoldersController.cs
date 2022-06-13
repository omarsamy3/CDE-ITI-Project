using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ITICDE.Data;
using ITICDE.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ITICDE.Controllers
{
    public class FoldersController : Controller
    {
        private readonly CDEDBContext _context;
        private IWebHostEnvironment _env;

        public FoldersController(CDEDBContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Folders
        public async Task<IActionResult> Index(int ProjectId)
        {
            ViewBag.ProjId = ProjectId;
            return View(await _context.Folders.ToListAsync());
        }

        // GET: Folders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var folder = await _context.Folders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (folder == null)
            {
                return NotFound();
            }

            return View(folder);
        }

        // GET: Folders/Create
        public IActionResult Create(int ProjectId)
        {
            ViewBag.proId = ProjectId;
            return View();
        }

        // POST: Folders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name, ProjectId")] Folder folder, int ProjectId)
        {
            if (ModelState.IsValid)
            {
                var project = await _context.Projects.FindAsync(ProjectId); //This project is to have folders in it.
                folder.UserId = 1;
                _context.Add(folder);
                project.Folders.Add(folder); //Adding this folder to the this project exclusively
                await _context.SaveChangesAsync();
                folder.HasParent = false;
                return RedirectToAction(nameof(Index), new { ProjectId });
            }
            return View(folder);
        }

        // GET: Folders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var folder = await _context.Folders.FindAsync(id);
            if (folder == null)
            {
                return NotFound();
            }
            return View(folder);
        }

        // POST: Folders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CreationDate")] Folder folder)
        {
            if (id != folder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(folder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FolderExists(folder.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(folder);
        }

        // GET: Folders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var folder = await _context.Folders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (folder == null)
            {
                return NotFound();
            }

            return View(folder);
        }

        // POST: Folders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var folder = await _context.Folders.FindAsync(id);
            _context.Folders.Remove(folder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> InnerDet(int? id)
        {
            var folder = await _context.Folders.Include(i => i.InnerFolders).Include(f => f.Files)
                        .FirstOrDefaultAsync(m => m.Id == id);

            if (id == null)
            {
                return NotFound();
            }
            // Files Display Code 
            if (folder == null)
            {
                return NotFound();
            }
            return View(folder);
        }

        public IActionResult CreateInnerFolder(int? id)
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateInnerFolder(int id, [Bind("Name,CreationDate")] Folder folder)
        {
            var parent = _context.Folders.FirstOrDefault(m => m.Id == id);
            folder.UserId = 1;
            folder.ProjectId = parent.ProjectId;
            parent.InnerFolders.Add(folder);
            folder.HasParent = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(InnerDet), new { id });
        }
        private bool FolderExists(int id)
        {
            return _context.Folders.Any(e => e.Id == id);
        }

        // Uploading Files 


        public async Task<IActionResult> MultipleFiles(IEnumerable<IFormFile> files, int? id)
        {
            var dir = _env.WebRootPath;
            var full = dir + "/Files";
            var folder = await _context.Folders.Include(i => i.InnerFolders)
                                   .FirstOrDefaultAsync(m => m.Id == id);
            foreach (var file in files)
            {
                var fileName = file.FileName.Split('.').First() + "_" + id + Path.GetExtension(file.FileName);
                using (var fileStream = new FileStream(Path.Combine(full, fileName), FileMode.Create, FileAccess.Write))
                {
                    file.CopyTo(fileStream);
                }
                Models.File newF = new Models.File { Name = fileName, Type = Path.GetExtension(Path.Combine(full, fileName)), Path = Path.GetFullPath(Path.Combine(full, fileName)), ProjectId = folder.ProjectId, UserId = 1 };
                _context.Add(newF);
                folder.Files.Add(newF);
                _context.SaveChanges();
            }
           
            //foreach (var f in files)
            //{

            //    Models.File newF = new Models.File { Name = f.FileName, Type = Path.GetExtension(Path.Combine(full, f.FileName)), Path = Path.GetFullPath(Path.Combine(full, f.FileName)), ProjectId = folder.ProjectId , UserId = 1};
            //    _context.Add(newF);
            //    folder.Files.Add(newF);
            //    _context.SaveChanges();
            //}
            return RedirectToAction("InnerDet", new { id });
        }
        public FileResult DownloadFile(string fileName)
        {
            string path = Path.Combine(this._env.WebRootPath, "Files/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", fileName);
        }

        public async Task<IActionResult> DeleteFile(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var file = await _context.Files
                .FirstOrDefaultAsync(m => m.Id == id);
            if (file == null)
            {
                return NotFound();
            }

            return View(file);
        }
        [HttpPost, ActionName("DeleteFile")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteFileConfirmed(int id)
        {
            var file = await _context.Files.FindAsync(id);
            _context.Files.Remove(file);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult ViewFiles(int Id)
        {
            var file = _context.Files.FirstOrDefault(f => f.Id == Id);
            return View(file);
        }
        //public IActionResult PDFViewer(string Fname)
        //{
        //    string path = _env.WebRootPath + "\\Files\\" + Fname;
        //    return File(System.IO.File.ReadAllBytes(path), "application/pdf");
        //}
    }
}
