using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bigoton.Web.Data;
using Bigoton.Web.Data.Entities;

namespace Bigoton.Web.Controllers
{
    public class CutStylesController : Controller
    {
        private readonly DataContext _context;

        public CutStylesController(DataContext context)
        {
            _context = context;
        }

        // GET: CutStyles
        public async Task<IActionResult> Index()
        {
            return View(await _context.CutStyles.ToListAsync());
        }

        // GET: CutStyles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cutStyle = await _context.CutStyles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cutStyle == null)
            {
                return NotFound();
            }

            return View(cutStyle);
        }

        // GET: CutStyles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CutStyles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ImageUrl,Price,Remarks")] CutStyle cutStyle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cutStyle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cutStyle);
        }

        // GET: CutStyles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cutStyle = await _context.CutStyles.FindAsync(id);
            if (cutStyle == null)
            {
                return NotFound();
            }
            return View(cutStyle);
        }

        // POST: CutStyles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ImageUrl,Price,Remarks")] CutStyle cutStyle)
        {
            if (id != cutStyle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cutStyle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CutStyleExists(cutStyle.Id))
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
            return View(cutStyle);
        }

        // GET: CutStyles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cutStyle = await _context.CutStyles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cutStyle == null)
            {
                return NotFound();
            }

            return View(cutStyle);
        }

        // POST: CutStyles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cutStyle = await _context.CutStyles.FindAsync(id);
            _context.CutStyles.Remove(cutStyle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CutStyleExists(int id)
        {
            return _context.CutStyles.Any(e => e.Id == id);
        }
    }
}
