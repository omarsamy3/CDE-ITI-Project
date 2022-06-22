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
        public async Task<IActionResult> Index()
        {
            var cDEDBContext = _context.Projects.Include(p => p.CreatorUser);
            return View(await cDEDBContext.ToListAsync());
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
            //ViewData["CreatorUserId"] = new SelectList(_context.Users, "Id", "ConfirmEmail");
            return View();
        }

        // POST: Project/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // POST: Project/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

            //To remove the folders in the project you want to delete
            //foreach (var folder in project.Folders)
            //{
            //    _context.Folders.Remove(folder);
            //} 
            
            //To remove the files in the project you want to delete
            //foreach (var file in project.Files)
            //{
            //    _context.Files.Remove(file);
            //}
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}
