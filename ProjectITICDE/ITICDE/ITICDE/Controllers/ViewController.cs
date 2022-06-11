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
    public class ViewController : Controller
    {
        private readonly CDEDBContext _context;

        public ViewController(CDEDBContext context)
        {
            _context = context;
        }

        // GET: View
        public async Task<IActionResult> Index()
        {
            var cDEDBContext = _context.Views.Include(v => v.CreatorUser).Include(v => v.Project);
            return View(await cDEDBContext.ToListAsync());
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        

        
        
        //Preview 3D Model
        public  IActionResult ShowView()
        {
            return View(nameof(ShowView));
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
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "ConfirmEmail");
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name");
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "ConfirmEmail", view.UserId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", view.ProjectId);
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "ConfirmEmail", view.UserId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", view.ProjectId);
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
                return RedirectToAction(nameof(Index));
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var view = await _context.Views.FindAsync(id);
            _context.Views.Remove(view);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ViewExists(int id)
        {
            return _context.Views.Any(e => e.Id == id);
        }
    }
}
