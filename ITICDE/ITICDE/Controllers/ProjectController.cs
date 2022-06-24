using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ITICDE.Data;
using ITICDE.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.CodeAnalysis;
using Project = ITICDE.Models.Project;

namespace ITICDE.Controllers
{
[Authorize]
    public class ProjectController : Controller
    {
        private readonly CDEDBContext _context;

        public ProjectController(CDEDBContext context)
        {
            _context = context;
        }

        // GET: Project
        public async Task<IActionResult> Index(string addedUser)
        {
            var userLog = _context.Users.Include(u=>u.WorkonProjects).FirstOrDefault(s=>s.Id == addedUser);
            var projectLst = _context.Projects.Include(p => p.CreatorUser).Include(u=>u.Users);
            ViewBag.userLog = userLog;
            return View(await projectLst.ToListAsync());
        }

        // GET: Project/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.CreatorUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Project/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Units,Progress,StartDate,CreationDate,Description,CreatorUserId")] ITICDE.Models.Project project)
        {
            if (ModelState.IsValid)
            {
                project.CreatorUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatorUserId"] = new SelectList(_context.Users, "Id", "ConfirmEmail", project.CreatorUserId);
            return View(project);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        public IActionResult CreateFolder(int ProjectId)
        {
            return RedirectToAction("Create", "Folders", new { ProjectId });
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////


        // GET: Project/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            ViewData["CreatorUserId"] = new SelectList(_context.Users, "Id", "ConfirmEmail", project.CreatorUserId);
            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Units,Progress,StartDate,CreationDate,Description,CreatorUserId")] ITICDE.Models.Project project)
        {
            if (id != project.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.Id))
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
            ViewData["CreatorUserId"] = new SelectList(_context.Users, "Id", "ConfirmEmail", project.CreatorUserId);
            return View(project);
        }

        // GET: Project/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.CreatorUser)
                .Include(f => f.Folders)
                .Include(f => f.Files)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }
           // ViewBag.proId = id;
            return View(project);
        }

        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            _context.Projects.Remove(project);            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddUser(int? projectId)
        {
            if (projectId == null)
            {
                return NotFound();
            }
            Project project = _context.Projects.Include(u=>u.Users).FirstOrDefault(w=>w.Id== projectId);
            var projectUser = _context.Users.Include(u=>u.WorkonProjects).ToList();
            ViewBag.project= project;
                       
            return View(projectUser);
        }


        public IActionResult AddedUser (string ProjectUser ,int projectId)
        {
            User user = _context.Users.FirstOrDefault(p=>p.Id== ProjectUser);
            Project project = _context.Projects.Find(projectId);
            user.WorkonProjects.Add(project);
            project.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction(nameof(AddUser),new {projectId});
        }
        
        public IActionResult ViewUser (int projectId)
        {
            Project project = _context.Projects.Include(u => u.Users).FirstOrDefault(w => w.Id == projectId);
            //var projectuser = project.Users.ToList();
            var projectuser = _context.Users.Include(i => i.WorkonProjects).ToList();
            ViewBag.project = project;           
            return View(projectuser);
        }
        public IActionResult DeleteUser(string ProjectUser, int projectId)
        {
            User user = _context.Users.FirstOrDefault(p => p.Id == ProjectUser);
            Project project = _context.Projects.Find(projectId);
            user.WorkonProjects.Remove(project);
            project.Users.Remove(user);
            _context.SaveChanges();
            return RedirectToAction(nameof(ViewUser), new { projectId });
        }


        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}
