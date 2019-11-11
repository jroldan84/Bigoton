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
    public class DiscountVouchersController : Controller
    {
        private readonly DataContext _context;

        public DiscountVouchersController(DataContext context)
        {
            _context = context;
        }

        // GET: DiscountVouchers
        public async Task<IActionResult> Index()
        {
            return View(await _context.DiscountVouchers.ToListAsync());
        }

        // GET: DiscountVouchers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discountVoucher = await _context.DiscountVouchers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (discountVoucher == null)
            {
                return NotFound();
            }

            return View(discountVoucher);
        }

        // GET: DiscountVouchers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DiscountVouchers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Discount,DiscountCode,discountpercentage")] DiscountVoucher discountVoucher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(discountVoucher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(discountVoucher);
        }

        // GET: DiscountVouchers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discountVoucher = await _context.DiscountVouchers.FindAsync(id);
            if (discountVoucher == null)
            {
                return NotFound();
            }
            return View(discountVoucher);
        }

        // POST: DiscountVouchers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Discount,DiscountCode,discountpercentage")] DiscountVoucher discountVoucher)
        {
            if (id != discountVoucher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(discountVoucher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiscountVoucherExists(discountVoucher.Id))
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
            return View(discountVoucher);
        }

        // GET: DiscountVouchers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discountVoucher = await _context.DiscountVouchers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (discountVoucher == null)
            {
                return NotFound();
            }

            return View(discountVoucher);
        }

        // POST: DiscountVouchers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var discountVoucher = await _context.DiscountVouchers.FindAsync(id);
            _context.DiscountVouchers.Remove(discountVoucher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiscountVoucherExists(int id)
        {
            return _context.DiscountVouchers.Any(e => e.Id == id);
        }
    }
}
