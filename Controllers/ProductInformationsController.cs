using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimMarketing.Data;
using SimMarketing.Models;

namespace SimMarketing.Controllers
{
    public class ProductInformationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductInformationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductInformations
        public async Task<IActionResult> Index()
        {
              return _context.ProductInformation != null ? 
                          View(await _context.ProductInformation.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ProductInformation'  is null.");
        }

        // GET: ProductInformations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductInformation == null)
            {
                return NotFound();
            }

            var productInformation = await _context.ProductInformation
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productInformation == null)
            {
                return NotFound();
            }

            return View(productInformation);
        }

        // GET: ProductInformations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,InquiryInformationId,ProductName,LogicalDelete,DateCreated,DateModified")] ProductInformation productInformation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productInformation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productInformation);
        }

        // GET: ProductInformations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductInformation == null)
            {
                return NotFound();
            }

            var productInformation = await _context.ProductInformation.FindAsync(id);
            if (productInformation == null)
            {
                return NotFound();
            }
            return View(productInformation);
        }

        // POST: ProductInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,InquiryInformationId,ProductName,LogicalDelete,DateCreated,DateModified")] ProductInformation productInformation)
        {
            if (id != productInformation.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productInformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductInformationExists(productInformation.ProductId))
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
            return View(productInformation);
        }

        // GET: ProductInformations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductInformation == null)
            {
                return NotFound();
            }

            var productInformation = await _context.ProductInformation
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productInformation == null)
            {
                return NotFound();
            }

            return View(productInformation);
        }

        // POST: ProductInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductInformation == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProductInformation'  is null.");
            }
            var productInformation = await _context.ProductInformation.FindAsync(id);
            if (productInformation != null)
            {
                _context.ProductInformation.Remove(productInformation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductInformationExists(int id)
        {
          return (_context.ProductInformation?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
