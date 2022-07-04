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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user=_context.Users.Find(userId);
            HttpContext.Session.SetString("userName", user.Name);
            HttpContext.Session.SetInt32("projid", ProjectId);
            return RedirectToAction(nameof(Index), new { ProjectId });
        }
        // GET: Folders
        public async Task<IActionResult> Index(int ProjectId)
        {
            ViewBag.ProjId = ProjectId;
            var project=_context.Projects.Include(f=>f.Folders).ThenInclude(f=>f.CreatorUser).Include(fi=>fi.Files).ThenInclude(fi=>fi.CreatorUser).FirstOrDefault(p=>p.Id == ProjectId).Name;
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Include(T=>T.SharedTasks).FirstOrDefault(u => u.Id == userId);
            var projectFiles = _context.Projects.Include(f => f.Folders).Include(u=>u.Users).FirstOrDefault(p => p.Id == ProjectId).Files.Where(f=>f.ProjectId==ProjectId && f.FolderId==null);
            ViewBag.ProjectFiles = projectFiles;
            ViewBag.project = project;
            ViewBag.User = user;
            return View(await _context.Folders.Include(u=>u.CreatorUser).ToListAsync());
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CreationDate,UserId,ProjectId,ParentId")] Folder folder)
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
                if(folder.ParentId == 0){
                    return RedirectToAction(nameof(Index), new { ProjectId = folder.ProjectId });
                }
                else if (folder.ParentId!=0)
                {
                    folder.HasParent = true;
                    _context.Update(folder);
                    return RedirectToAction(nameof(InnerDet), new {id= folder.ParentId,projectId=folder.ProjectId });
                }
                
            }
            return View(folder);
        }

        // GET: Folders/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var folder = await _context.Folders
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    ViewBag.projectId = folder.ProjectId;
        //    if (folder == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(folder);
        //}

        //// POST: Folders/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id,int ProjectId)
        //{
        //    var folder = await _context.Folders.FindAsync(id);
        //    _context.Folders.Remove(folder);
        //    await _context.SaveChangesAsync();
        //    if(folder.ParentId==0)
        //    return RedirectToAction(nameof(Index),new {ProjectId});
        //    else return RedirectToAction(nameof(InnerDet), new { id=folder.ParentId ,projectId= ProjectId });
        //}
        // GET: Folders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var folder = await _context.Folders
                .Include(f => f.Files)
                .Include(f => f.InnerFolders)
                .Include(f => f.CreatorUser)
                .Include(f => f.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            ViewBag.projectId = folder.ProjectId;
            if (folder == null)
            {
                return NotFound();
            }

            return View(folder);
        }

        public void again(Folder folder)
        {
            if (folder.InnerFolders.Count > 0)
            {
                foreach (var inner in folder.InnerFolders.ToList())
                {
                    if (inner.InnerFolders.Count == 0) { folder.InnerFolders.Remove(inner); }
                    else { again(inner); }
                }

                foreach (var file in folder.Files.ToList())
                {
                    folder.Files.Remove(file);
                }
            }
        }

        // POST: Folders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, int ProjectId)
        {
            var folder = _context.Folders.Include(f => f.InnerFolders)
                .Include(f => f.Files).FirstOrDefault(f => f.Id == id);

            again(folder);

            _context.Folders.Remove(folder);
            await _context.SaveChangesAsync();
            if (folder.ParentId == 0)
                return RedirectToAction(nameof(Index), new { ProjectId });
            else return RedirectToAction(nameof(InnerDet), new { id = folder.ParentId, projectId = ProjectId });
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
            var folder = await _context.Folders.Include(i => i.InnerFolders).Include(f => f.Files).ThenInclude(u=>u.CreatorUser).Include(p=>p.Project).Include(u=>u.CreatorUser)
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
            ViewBag.parent = id;
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
            var folder = await _context.Folders.Include(i => i.InnerFolders).Include(f=>f.Files).ThenInclude(u=>u.CreatorUser)
                                    .FirstOrDefaultAsync(m => m.Id == id);
            foreach (var file in files)
            {
                var fileName = file.FileName.Split('.').First() + ";" + id + Path.GetExtension(file.FileName);
                using (var fileStream = new FileStream(Path.Combine(full, fileName), FileMode.Create, FileAccess.Write))
                {
                    file.CopyTo(fileStream);
                }
                Models.File newF = new Models.File { Name = fileName, Type = Path.GetExtension(Path.Combine(full, fileName)), Path = Path.GetFullPath(Path.Combine(full, fileName)), ProjectId = folder.ProjectId, CreatorUserId = User.FindFirstValue(ClaimTypes.NameIdentifier)};
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
            if (fileName.Contains('@'))
            {
                string Name = fileName.Split('@').First()+Path.GetExtension(fileName);
                return File(bytes, "application/octet-stream", Name);
            }
            else if(fileName.Contains(';'))
            {
                string Name = fileName.Split(';').First() + Path.GetExtension(fileName);
                return File(bytes, "application/octet-stream", Name);
            }
            else
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
        public async Task<IActionResult> DeleteFileConfirmed(int? id)
        {
            var file = await _context.Files.FindAsync(id);
            int? Id = file.FolderId;
            _context.Files.Remove(file);

            await _context.SaveChangesAsync();
            return RedirectToAction("InnerDet",new{Id});
        }
        public IActionResult ViewFiles(int Id)
        {
            var file = _context.Files.Include(f=>f.Folder).FirstOrDefault(f => f.Id == Id);
            return View(file);
        }
		//public IActionResult PDFViewer(string Fname)
		//{
		//    string path = _env.WebRootPath + "\\Files\\" + Fname;
		//    return File(System.IO.File.ReadAllBytes(path), "application/pdf");
		//}
		public async Task<IActionResult> MultipleFilesInProject(IEnumerable<IFormFile> files, int projectId)
		{
			var dir = _env.WebRootPath;
			var full = dir + "/Files";
			var project = await _context.Projects.Include(i => i.Files).ThenInclude(i=>i.CreatorUser).Include(f => f.Folders).ThenInclude(f=>f.CreatorUser)
									.FirstOrDefaultAsync(m => m.Id == projectId);
			foreach (var file in files)
			{
				var fileName = file.FileName.Split('.').First() + "@" + projectId + Path.GetExtension(file.FileName);
				using (var fileStream = new FileStream(Path.Combine(full, fileName), FileMode.Create, FileAccess.Write))
				{
					file.CopyTo(fileStream);
				}
				Models.File newF = new Models.File { Name = fileName, Type = Path.GetExtension(Path.Combine(full, fileName)), Path = Path.GetFullPath(Path.Combine(full, fileName)), ProjectId = projectId, CreatorUserId = User.FindFirstValue(ClaimTypes.NameIdentifier) };
				_context.Add(newF);
				project.Files.Add(newF);
				_context.SaveChanges();
			}
			return RedirectToAction("Index", new { projectId });
		}
        public async Task<IActionResult> DeleteFileFromProject(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var file = await _context.Files.Include(c=>c.CreatorUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (file == null)
            {
                return NotFound();
            }

            return View(file);
        }
        [HttpPost,ActionName("DeleteFileFromProject")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteFileFromProjectConfirmed(int? id,int ProjectId)
        {
            var file = await _context.Files.FindAsync(id);
           
            _context.Files.Remove(file);

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { ProjectId });
        }


        //public async Task<IActionResult> MultipleFilesInProject(IEnumerable<IFormFile> files, int ProjectId)
        //{
        //    var dir = _env.WebRootPath;
        //    var full = dir + "/ProjectFiles";
        //    var project = await _context.Projects.Include(c => c.CreatorUser).Include(u => u.Users).Include(f=>f.Folders).Include(fi=>fi.Files)
        //                            .FirstOrDefaultAsync(p => p.Id == ProjectId);
        //    foreach (var file in files)
        //    {
        //        var fileName = file.FileName.Split('.').First() + "_" + ProjectId + Path.GetExtension(file.FileName);
        //        using (var fileStream = new FileStream(Path.Combine(full, fileName), FileMode.Create, FileAccess.Write))
        //        {
        //            file.CopyTo(fileStream);
        //        }
        //        Models.File newF = new Models.File { Name = fileName, Type = Path.GetExtension(Path.Combine(full, fileName)), Path = Path.GetFullPath(Path.Combine(full, fileName)), ProjectId = ProjectId, UserId = User.FindFirstValue(ClaimTypes.NameIdentifier) };
        //        _context.Add(newF);
        //        project.Files.Add(newF);
        //        _context.SaveChanges();
        //    }
        //    return RedirectToAction(nameof(Index), new { ProjectId });
        //}
    }
}
