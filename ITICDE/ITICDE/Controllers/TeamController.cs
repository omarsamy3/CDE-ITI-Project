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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace ITICDE.Controllers
{
    [Authorize]
    public class TeamController : Controller
    {
        private readonly CDEDBContext _context;

        public TeamController(CDEDBContext context)
        {
            _context = context;
        }
        #region Index
        // GET: Team
        public async Task<IActionResult> Index(int ProjectId)
        {

            ViewBag.TeamProjId = ProjectId;
            var cDEDBContext = _context.Teams.Include(t => t.CreatorUser).Include(t => t.Project).Include(u => u.Users);
            return View(await cDEDBContext.ToListAsync());
        }
        #endregion

        #region TeamUsers
        public async Task<IActionResult> TeamUsers(int? TeamId)
        {
            var team = await _context.Teams.Include(u => u.Users).Where(u => u.Id == TeamId).FirstOrDefaultAsync();
            List<User> users = team.Users;
            ViewBag.TeamId = TeamId;
            return View(users);
        }
        #endregion

        #region Details
        // GET: Team/Details/5
        public async Task<IActionResult> Details(int? id, int ProjectId)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.ProjectId = ProjectId;
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
        #endregion

        #region Create
        // GET: Team/Create
        public IActionResult Create(int? ProjectId)
        {
            ViewBag.ProjectId = ProjectId;
            var EnteredProject = _context.Projects.Include(p => p.Users).FirstOrDefault(p => p.Id == ProjectId);
            List<User> ProjectUsers = EnteredProject.Users;
            ViewBag.thisProjectUsers = ProjectUsers.ToList();
            ViewData["CreatorUserId"] = new SelectList(ProjectUsers.ToList(), "Id", "ConfirmEmail");

            ViewData["TeamLeaderId"] = new SelectList(ProjectUsers.ToList(), "Id", "Name");
            return View();
        }

        // POST: Team/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CreatorUserId,ProjectId,TeamLeaderId")] Team team, int ProjectId)
        {
            if (ModelState.IsValid)
            {

                var TeamAdmin = _context.Users.FirstOrDefault(a => a.Id == team.TeamLeaderId);
                team.Users.Add(TeamAdmin);
                team.ProjectId = ProjectId;
                _context.Teams.Add(team);
                ViewBag.TeamLeader = TeamAdmin;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { ProjectId });
            }
            ViewData["CreatorUserId"] = new SelectList(_context.Users, "Id", "ConfirmEmail", team.CreatorUserId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", team.ProjectId);
            return View(team);
        }
        #endregion

        #region Edit
        // GET: Team/Edit/5
        public IActionResult Edit(int? id, int ProjectId)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.ProjectId = ProjectId;
            var team = _context.Teams.Include(t => t.Users).FirstOrDefault(t => t.Id == id);
            if (team == null)
            {
                return NotFound();
            }
            ViewData["TeamLeaderId"] = new SelectList(team.Users.ToList(), "Id", "Name", team.TeamLeaderId);
            return View(team);
        }

        // POST: Team/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CreatorUserId,ProjectId,TeamLeaderId")] Team team, int ProjectId)
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
                return RedirectToAction(nameof(Index), new { ProjectId });
            }
            ViewData["CreatorUserId"] = new SelectList(_context.Users, "Id", "ConfirmEmail", team.CreatorUserId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", team.ProjectId);
            return View(team);
        }
        #endregion

        #region Delete
        // GET: Team/Delete/5
        public async Task<IActionResult> Delete(int? id, int ProjectId)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.ProjectId = ProjectId;
            var team = await _context.Teams
                .Include(t => t.CreatorUser)
                .Include(t => t.Project)
                .Include(u => u.Users)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Team/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, int ProjectId)
        {
            var team = _context.Teams.Include(t => t.Users).FirstOrDefault(t => t.Id == id);
            if (team.Users.Count > 0)
            {
                foreach (var user in team.Users.ToList())
                {
                    team.Users.Remove(user);
                    user.JoinedTeams.Remove(team);
                }
            }


            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { ProjectId });
        }
        #endregion

        #region TeamExists
        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }
        #endregion

        #region TeamUsersDetails
        public async Task<IActionResult> UsersDetails(int id, int ProjectId)
        {
            var team = await _context.Teams.Include(c => c.Users).Where(c => c.Id == id).FirstOrDefaultAsync();

            List<User> users = team.Users;
            ViewBag.TeamId = id;
            ViewBag.TeamLeader = team.TeamLeaderId;
            ViewBag.TeamName = team.Name;
            ViewBag.ProjectId = ProjectId;

            return View(users);
        }
        #endregion

    }
}