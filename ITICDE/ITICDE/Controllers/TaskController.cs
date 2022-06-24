using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ITICDE.Data;
using ITICDE.Models;

namespace ITICDE.Controllers
{
    public class TaskController : Controller
    {
        private readonly CDEDBContext _context;

        public TaskController(CDEDBContext context)
        {
            _context = context;
        }

        // GET: Task
        public async Task<IActionResult> Index(int ProjectId)
        {
            ViewBag.ProjectId = ProjectId;
            var cDEDBContext = _context.Tasks.Include(t => t.AssignedtoUser).Include(t => t.CreatorUser).Include(t => t.Project).Include(t => t.Team).Include(t => t.View).Include(t=>t.Team.Users);
            return View(await cDEDBContext.ToListAsync());
        }

        // GET: Task/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks
                .Include(t => t.AssignedtoUser)
                .Include(t => t.CreatorUser)
                .Include(t => t.Project)
                .Include(t => t.Team)
                .Include(t => t.View)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // GET: Task/Create
        public IActionResult Create()
        {
            ViewData["AssignedtoUserId"] = new SelectList(_context.Users, "Id", "Email");
            ViewData["CreatorUserId"] = new SelectList(_context.Users, "Id", "Name");
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name");
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Name");
            ViewData["ViewId"] = new SelectList(_context.Views, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Progress,Priority,Description,CreationDate,DeadLine,CreatorUserId,AssignedtoUserId,ProjectId,TeamId,ViewId")] ITICDE.Models.Task task)
        {
            if (ModelState.IsValid)
            {
                _context.Add(task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { ProjectId = task.ProjectId });
            }
            ViewData["AssignedtoUserId"] = new SelectList(_context.Users, "Id", "Name", task.AssignedtoUserId);
            ViewData["CreatorUserId"] = new SelectList(_context.Users, "Id", "Name", task.CreatorUserId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", task.ProjectId);
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Name", task.TeamId);
            ViewData["ViewId"] = new SelectList(_context.Views, "Id", "Name", task.ViewId);
            return View(task);
        }
        public IActionResult CreateFromView(int ProjectId, int viewid)
        {
            ViewBag.Projid = ProjectId;
            ViewBag.Vieid = viewid;
            ViewData["AssignedtoUserId"] = new SelectList(_context.Users, "Id", "Email");
            ViewData["CreatorUserId"] = new SelectList(_context.Users, "Id", "Name");
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name");
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Name");
            ViewData["ViewId"] = new SelectList(_context.Views, "Id", "Name");
            return View();
        }

        // POST: Task/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> CreateFromView([Bind("Id,Title,Progress,Priority,Description,CreationDate,DeadLine,CreatorUserId,AssignedtoUserId,ProjectId,TeamId,ViewId")] ITICDE.Models.Task task)
        {
            if (ModelState.IsValid)
            {
                _context.Add(task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index),new { ProjectId=task.ProjectId});
            }
            ViewData["AssignedtoUserId"] = new SelectList(_context.Users, "Id", "Name", task.AssignedtoUserId);
            ViewData["CreatorUserId"] = new SelectList(_context.Users, "Id", "Name", task.CreatorUserId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", task.ProjectId);
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Name", task.TeamId);
            ViewData["ViewId"] = new SelectList(_context.Views, "Id", "Name", task.ViewId);
            return View(task);
        }

        // GET: Task/Edit/5
        public async Task<IActionResult> Edit(int? id,int ProjId)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.ProjId = ProjId;
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            ViewData["AssignedtoUserId"] = new SelectList(_context.Users, "Id", "Name", task.AssignedtoUserId);
            ViewData["CreatorUserId"] = new SelectList(_context.Users, "Id", "Name", task.CreatorUserId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", task.ProjectId);
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Name", task.TeamId);
            ViewData["ViewId"] = new SelectList(_context.Views, "Id", "Name", task.ViewId);
            return View(task);
        }

        // POST: Task/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Progress,Priority,Description,DeadLine,AssignedtoUserId,ProjectId,CreatorUserId,TeamId,ViewId")] ITICDE.Models.Task task)
        {
            if (id != task.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(task);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskExists(task.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index),new{task.ProjectId});
            }
            ViewData["AssignedtoUserId"] = new SelectList(_context.Users, "Id", "Name", task.AssignedtoUserId);
            ViewData["CreatorUserId"] = new SelectList(_context.Users, "Id", "Name", task.CreatorUserId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", task.ProjectId);
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Name", task.TeamId);
            ViewData["ViewId"] = new SelectList(_context.Views, "Id", "Name", task.ViewId);
            return View(task);
        }

        // GET: Task/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks
                .Include(t => t.AssignedtoUser)
                .Include(t => t.CreatorUser)
                .Include(t => t.Project)
                .Include(t => t.Team)
                .Include(t => t.View)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // POST: Task/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
