using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ITICDE.Data;
using ITICDE.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
//using System.Web.Mvc;

namespace ITICDE.Controllers
{
    public class TeamController : Controller
    {
        private readonly CDEDBContext _context;

        public TeamController(CDEDBContext context)
        {
            _context = context;
        }

        // GET: Team
        public async Task<IActionResult> Index()
        {
            //ViewBag.TeamProjId = ProjectId;
            var cDEDBContext = _context.Teams.Include(t => t.CreatorUser).Include(t => t.Project);
            return View(await cDEDBContext.ToListAsync());
        }

        //[HandleError(View = "Error", ExceptionType = typeof(DbUpdateException))]
        public async Task<IActionResult> TeamUsers(int? TeamId)
        {
            var team = await _context.Teams.Include(u => u.Users).Where(u => u.Id == TeamId).FirstOrDefaultAsync();
            List<User> users = team.Users;
            ViewBag.TeamId = TeamId;
            return View(users);
        }

        // GET: Team/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .Include(t => t.CreatorUser)
                .Include(t => t.Project)
                .Include(t => t.Users)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // GET: Team/Create
        public IActionResult Create()
        {
            //ViewData["CreatorUserId"] = new SelectList(_context.Users, "Id", "ConfirmEmail");
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name");
            return View();
        }

        // POST: Team/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CreatorUserId,ProjectId")] Team team)
        {
            if (ModelState.IsValid)
            {
               // var project = _context.Projects.Find(ProjTeamId);
               // team.ProjectId = ProTeamId;
                _context.Add(team);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatorUserId"] = new SelectList(_context.Users, "Id", "ConfirmEmail", team.CreatorUserId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", team.ProjectId);
            return View(team);
        }

        // GET: Team/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            ViewData["CreatorUserId"] = new SelectList(_context.Users, "Id", "ConfirmEmail", team.CreatorUserId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", team.ProjectId);
            return View(team);
        }

        // POST: Team/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CreatorUserId,ProjectId")] Team team)
        {
            if (id != team.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(team);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(team.Id))
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
            ViewData["CreatorUserId"] = new SelectList(_context.Users, "Id", "ConfirmEmail", team.CreatorUserId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", team.ProjectId);
            return View(team);
        }

        // GET: Team/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .Include(t => t.CreatorUser)
                .Include(t => t.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Team/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }

        public async Task<IActionResult> UsersDetails(int id)
        {
            var team = await _context.Teams.Include(c => c.Users).Where(c => c.Id == id).FirstOrDefaultAsync();
            List<User> users = team.Users;
            return View(users);
        }

        
    }
}