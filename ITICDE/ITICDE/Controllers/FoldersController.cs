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
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.CodeAnalysis;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace ITICDE.Controllers
{
    [Authorize]
    public class FoldersController : Controller
    {
        private readonly CDEDBContext _context;
        private IWebHostEnvironment _env;
        private readonly UserManager<User> _userManager;
        public FoldersController(CDEDBContext context, IWebHostEnvironment env, UserManager<User> userManager)
        {
            _context = context;
            _env = env;
            _userManager = userManager;
        }

        public IActionResult Redirect(int ProjectId)
        {
            HttpContext.Session.SetInt32("projid", ProjectId);
            return RedirectToAction(nameof(Index), new { ProjectId });
        }
        // GET: Folders
        public async Task<IActionResult> Index(int ProjectId)
        {
            ViewBag.ProjId = ProjectId;
            var project=_context.Projects.Include(f=>f.Folders).FirstOrDefault(p=>p.Id == ProjectId).Name;
            ViewBag.project = project;
            return View(await _context.Folders.ToListAsync());
        }

        // GET: Folders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var folder = await _context.Folders.Include(c=>c.CreatorUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (folder == null)
            {
                return NotFound();
            }

            return View(folder);
        }

        // GET: Folders/Create
        public  IActionResult Create(int ProjectId)
        {
            ViewBag.proId = ProjectId;
            var projectName = _context.Projects.FirstOrDefault(f => f.Id == ProjectId).Name;
            ViewBag.projectName = projectName;
            var myUsers = _context.Users;
            ViewBag.users = myUsers;
            List<string> shared = null;
            //List<string> users = new List<string>();
            ViewBag.sharedId = shared;
            //ViewData["User"]  = new SelectList(_context.Users, "Id", "ConfirmEmail");
            return View();
            
        }

        // POST: Folders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind("Id,Name,CreationDate, ProjectId,UserId,Users")] Folder folder, int ProjectId,string UserId)
        {
            //Task<string> content = new StreamReader(Request.Body).ReadToEndAsync();
            if (ModelState.IsValid)
            {
                var project = await _context.Projects.FindAsync(ProjectId); //This project is to have folders in it.
                _context.Add(folder);
                project.Folders.Add(folder); //Adding this folder to the this project exclusively
                await _context.SaveChangesAsync();
                folder.HasParent = false;
                folder.ParentId = 0;
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
            ViewData["ProjectId"] = folder.ProjectId;
            ViewBag.projid=folder.ProjectId;
            return View(folder);
        }

        // POST: Folders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CreationDate,UserId,ProjectId")] Folder folder)
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
                return RedirectToAction(nameof(Index),new { ProjectId=folder.ProjectId});
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
            ViewBag.projectId = folder.ParentId;
            if (folder == null)
            {
                return NotFound();
            }

            return View(folder);
        }

        // POST: Folders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id,int ProjectId)
        {
            var folder = await _context.Folders.FindAsync(id);
            _context.Folders.Remove(folder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index),new {ProjectId});
        }

        public async Task<IActionResult> InnerDet(int? id,int projectId)
        {
            
            if (id==0)
            {
                return RedirectToAction(nameof(Index),new{projectId});
            }
            if (id == null)
            {
                return NotFound();
            }
            var folder = await _context.Folders.Include(i => i.InnerFolders).Include(f => f.Files).Include(p=>p.Project)
                                    .FirstOrDefaultAsync(m => m.Id == id);
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
        public async Task<IActionResult> CreateInnerFolder(int id, [Bind("Name,CreationDate,ProjectId,UserId")] Folder folder,string UserId)
        {
            if (ModelState.IsValid)
            {
                var parent = _context.Folders.FirstOrDefault(m => m.Id == id);
                folder.ProjectId = parent.ProjectId;
                parent.InnerFolders.Add(folder);
                folder.HasParent = true;
                folder.ParentId = id;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(InnerDet), new { id });
            }
            return View(folder);
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
                Models.File newF = new Models.File { Name = fileName, Type = Path.GetExtension(Path.Combine(full, fileName)), Path = Path.GetFullPath(Path.Combine(full, fileName)), ProjectId = folder.ProjectId, UserId = User.FindFirstValue(ClaimTypes.NameIdentifier) };
                _context.Add(newF);
                folder.Files.Add(newF);
                _context.SaveChanges();
            }
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
            int Id = file.FolderId;
            _context.Files.Remove(file);

            await _context.SaveChangesAsync();
            return RedirectToAction("InnerDet",new{Id});
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
        //public async Task<IActionResult> MultipleFilesInProject(IEnumerable<IFormFile> files, int projectId)
        //{
        //    var dir = _env.WebRootPath;
        //    var full = dir + "/Files";
        //    var project = await _context.Projects.Include(i => i.Files).Include(f=>f.Folders)
        //                            .FirstOrDefaultAsync(m => m.Id == projectId);
        //    foreach (var file in files)
        //    {
        //        var fileName = file.FileName.Split('.').First() + "-" + projectId + Path.GetExtension(file.FileName);
        //        using (var fileStream = new FileStream(Path.Combine(full, fileName), FileMode.Create, FileAccess.Write))
        //        {
        //            file.CopyTo(fileStream);
        //        }
        //        Models.File newF = new Models.File { Name = fileName, Type = Path.GetExtension(Path.Combine(full, fileName)), Path = Path.GetFullPath(Path.Combine(full, fileName)), ProjectId = projectId, UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),FolderId=0 };
        //        _context.Add(newF);
        //        project.Files.Add(newF);
                
        //        _context.SaveChanges();
        //    }
        //    return RedirectToAction("Index", new { projectId });
        //}
    }
}
