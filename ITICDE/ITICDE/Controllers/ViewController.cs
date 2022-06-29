using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ITICDE.Data;
using ITICDE.Models;
using Microsoft.AspNetCore.Http;

namespace ITICDE.Controllers
{
    public class ViewController : Controller
    {
        private readonly CDEDBContext _context;

        public ViewController(CDEDBContext context)
        {
            _context = context;
        }

        // GET: View
        public async Task<IActionResult> Index(int ProjectId)
        {
            var ViewsList = _context.Views.Where(v=>v.ProjectId==ProjectId).Include(v => v.CreatorUser).Include(v => v.Project);
            ViewBag.Projiid = ProjectId;
            return View(await ViewsList.ToListAsync());
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////




        //Preview 3D Model
        public IActionResult ShowView(int viewid)
        {
            var projid = HttpContext.Session.GetInt32("projid");
            ViewBag.Projiid = projid;
            ViewBag.viewid = viewid;
            ViewBag.Folders = _context.Folders.Where(f => f.ProjectId == projid);
            ViewBag.Files = _context.Files.Where(f => f.Type == ".ifc" && f.ProjectId==projid);
            ViewBag.Loadedfiles = _context.Views.Include(v => v.Files).FirstOrDefault(v => v.Id == viewid).Files;
            return View(_context.Views.FirstOrDefault(v => v.Id == viewid));
        }
        [HttpPost]
        public IActionResult ShowView(int viewid, string loadedfilesids)
        {

            //string a = HttpContext.Request.Form["loadedfilesids"];
            string[] idstrings = loadedfilesids.Split(',');

            int[] ids = Array.ConvertAll(idstrings, s => int.TryParse(s, out var x) ? x : -1);


            var viewfiles = _context.Views.Include(v => v.Files).FirstOrDefault(v => v.Id == viewid).Files;
            viewfiles.Clear();
            foreach (var item in ids)
            {
                if (item != 0)
                {
                    viewfiles.Add(_context.Files.First(f => f.Id == item));
                }
            }
            _context.SaveChanges();
            var projid = HttpContext.Session.GetInt32("projid");
            ViewBag.viewid = viewid;
            ViewBag.Folders = _context.Folders.Where(f => f.ProjectId == projid);
            ViewBag.Files = _context.Files.Where(f => f.Type == ".ifc" && f.ProjectId == projid);
            ViewBag.Loadedfiles = _context.Views.Include(v => v.Files).FirstOrDefault(v => v.Id == viewid).Files;

            //tobecontiued
            return View(_context.Views.FirstOrDefault(v => v.Id == viewid));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        // GET: View/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var view = await _context.Views
                .Include(v => v.CreatorUser)
                .Include(v => v.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (view == null)
            {
                return NotFound();
            }

            return View(view);
        }

        // GET: View/Create
        public IActionResult Create(int ProjectId)
        {
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "ConfirmEmail");
            //ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name");
            ViewBag.Projiid = ProjectId;
            return View();
        }

        // POST: View/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Type,CreationDate,UserId,ProjectId")] View view)
        {
            if (ModelState.IsValid)
            {
                _context.Add(view);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new {ProjectId=view.ProjectId});
            }
           
            return View(view);
        }

        // GET: View/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var view = await _context.Views.FindAsync(id);
            if (view == null)
            {
                return NotFound();
            }
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "ConfirmEmail", view.UserId);
            //ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", view.ProjectId);
            ViewData["ProjectId"] = view.ProjectId;
            return View(view);
        }

        // POST: View/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Type,CreationDate,UserId,ProjectId")] View view)
        {
            if (id != view.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(view);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ViewExists(view.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index),new{view.ProjectId});
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "ConfirmEmail", view.UserId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", view.ProjectId);
            return View(view);
        }

        // GET: View/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var view = await _context.Views
                .Include(v => v.CreatorUser)
                .Include(v => v.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (view == null)
            {
                return NotFound();
            }

            return View(view);
        }

        // POST: View/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id,int ProjectId)
        {
            var view = await _context.Views.FindAsync(id);
            _context.Views.Remove(view);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index),new{ProjectId});
        }

        private bool ViewExists(int id)
        {
            return _context.Views.Any(e => e.Id == id);
        }
    }
}
