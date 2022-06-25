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
using Microsoft.AspNetCore.Http;

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
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var UserAssignedTo = _context.Users.FirstOrDefault(u => u.Id == UserId);
            UserAssignedTo.HasTasks = false;
            _context.SaveChanges();
            ViewBag.ProjectId = ProjectId;
            var cDEDBContext = _context.Tasks.Include(t => t.AssignedtoUser).Include(t => t.CreatorUser).Include(t => t.Project).Include(t => t.Team).Include(t => t.View).Include(t=>t.Team.Users).Where(T=>T.ProjectId== ProjectId);
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
        public IActionResult Create(int ProjectId)
        {
            ViewBag.ProjId = ProjectId;
            var project = _context.Projects.Include(p => p.Users).FirstOrDefault(p => p.Id == ProjectId);

            ViewData["AssignedtoUserId"] = new SelectList(project.Users, "Id", "Name");
            ViewData["CreatorUserId"] = new SelectList(_context.Users, "Id", "Name");
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name");
            ViewData["TeamId"] = new SelectList(_context.Teams.Where(p => p.ProjectId == ProjectId), "Id", "Name");
            ViewData["ViewId"] = new SelectList(_context.Views.Where(v => v.ProjectId == ProjectId), "Id", "Name");
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Progress,Priority,Description,CreationDate,DeadLine,CreatorUserId,AssignedtoUserId,ProjectId,TeamId,ViewId")] ITICDE.Models.Task task)
        {
            if (ModelState.IsValid)
            {
                if(task.AssignedtoUserId !=null)
                {
                    var UserAssignedTo = _context.Users.FirstOrDefault(u => u.Id == task.AssignedtoUserId);
                    UserAssignedTo.HasTasks = true;
                }
                
            //UserAssignedTo.SharedTasks.Add(task);
                
                _context.Add(task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { task.ProjectId });
            }
            var project = _context.Projects.Include(p => p.Users).FirstOrDefault(p => p.Id == task.ProjectId);

            ViewData["AssignedtoUserId"] = new SelectList(project.Users, "Id", "Name", task.AssignedtoUserId);
            ViewData["CreatorUserId"] = new SelectList(_context.Users, "Id", "Name", task.CreatorUserId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", task.ProjectId);
            ViewData["TeamId"] = new SelectList(_context.Teams.Where(p => p.ProjectId == task.ProjectId), "Id", "Name", task.TeamId);
            ViewData["ViewId"] = new SelectList(_context.Views.Where(v => v.ProjectId == task.ProjectId), "Id", "Name", task.ViewId);
            return View(task);
        }
        public IActionResult CreateFromView(int ProjectId, int viewid)
        {
            ViewBag.Projid = ProjectId;
            ViewBag.Vieid = viewid;
            var project = _context.Projects.Include(p => p.Users).FirstOrDefault(p => p.Id == ProjectId);

            ViewData["AssignedtoUserId"] = new SelectList(project.Users, "Id", "Name");
            ViewData["CreatorUserId"] = new SelectList(_context.Users, "Id", "Name");
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", ProjectId);
            ViewData["TeamId"] = new SelectList(_context.Teams.Where(p => p.ProjectId == ProjectId), "Id");
            ViewData["ViewId"] = new SelectList(_context.Views.Where(v => v.ProjectId == ProjectId), "Id");
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
                return RedirectToAction(nameof(Index),new {task.ProjectId});
            }
            var project = _context.Projects.Include(p => p.Users).FirstOrDefault(p => p.Id == task.ProjectId);

            ViewData["AssignedtoUserId"] = new SelectList(project.Users, "Id", "Name", task.AssignedtoUserId);
            ViewData["CreatorUserId"] = new SelectList(_context.Users, "Id", "Name", task.CreatorUserId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", task.ProjectId);
            ViewData["TeamId"] = new SelectList(_context.Teams.Where(p => p.ProjectId == task.ProjectId), "Id", "Name", task.TeamId);
            ViewData["ViewId"] = new SelectList(_context.Views.Where(v => v.ProjectId == task.ProjectId), "Id", "Name", task.ViewId);
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
            var project = _context.Projects.Include(p => p.Users).FirstOrDefault(p => p.Id == ProjId);

            ViewData["AssignedtoUserId"] = new SelectList(project.Users, "Id", "Name", task.AssignedtoUserId);
            ViewData["CreatorUserId"] = new SelectList(_context.Users, "Id", "Name", task.CreatorUserId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", task.ProjectId);
            ViewData["TeamId"] = new SelectList(_context.Teams.Where(p => p.ProjectId == task.ProjectId), "Id", "Name", task.TeamId);
            ViewData["ViewId"] = new SelectList(_context.Views.Where(v => v.ProjectId == task.ProjectId), "Id", "Name", task.ViewId);
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
var project = _context.Projects.Include(p=>p.Users).FirstOrDefault(p => p.Id == task.ProjectId);

            ViewData["AssignedtoUserId"] = new SelectList(project.Users, "Id", "Name", task.AssignedtoUserId);
            ViewData["CreatorUserId"] = new SelectList(_context.Users, "Id", "Name", task.CreatorUserId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", task.ProjectId);
            ViewData["TeamId"] = new SelectList(_context.Teams.Where(p=>p.ProjectId==task.ProjectId), "Id", "Name", task.TeamId);
            ViewData["ViewId"] = new SelectList(_context.Views.Where(v=>v.ProjectId==task.ProjectId), "Id", "Name", task.ViewId);
            return View(task);
        }

        // GET: Task/Delete/5
        public async Task<IActionResult> Delete(int? id,int ProjId)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.ProjId = ProjId;
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
        public async Task<IActionResult> DeleteConfirmed(int id,int ProjectId)
        {
            var task = await _context.Tasks.FindAsync(id);
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index),new { ProjectId });
        }

        private bool TaskExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
