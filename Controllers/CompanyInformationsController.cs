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
    public class CompanyInformationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompanyInformationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CompanyInformations
        public async Task<IActionResult> Index()
        {
              return _context.CompanyInformation != null ? 
                          View(await _context.CompanyInformation.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CompanyInformation'  is null.");
        }

        // GET: CompanyInformations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CompanyInformation == null)
            {
                return NotFound();
            }

            var companyInformation = await _context.CompanyInformation
                .FirstOrDefaultAsync(m => m.CompanyId == id);
            if (companyInformation == null)
            {
                return NotFound();
            }

            return View(companyInformation);
        }

        // GET: CompanyInformations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompanyInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyId,InquiryInformationId,CompanyAddress,LogicalDelete,DateCreated,DateModified")] CompanyInformation companyInformation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companyInformation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(companyInformation);
        }

        // GET: CompanyInformations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CompanyInformation == null)
            {
                return NotFound();
            }

            var companyInformation = await _context.CompanyInformation.FindAsync(id);
            if (companyInformation == null)
            {
                return NotFound();
            }
            return View(companyInformation);
        }

        // POST: CompanyInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompanyId,InquiryInformationId,CompanyAddress,LogicalDelete,DateCreated,DateModified")] CompanyInformation companyInformation)
        {
            if (id != companyInformation.CompanyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyInformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyInformationExists(companyInformation.CompanyId))
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
            return View(companyInformation);
        }

        // GET: CompanyInformations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CompanyInformation == null)
            {
                return NotFound();
            }

            var companyInformation = await _context.CompanyInformation
                .FirstOrDefaultAsync(m => m.CompanyId == id);
            if (companyInformation == null)
            {
                return NotFound();
            }

            return View(companyInformation);
        }

        // POST: CompanyInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CompanyInformation == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CompanyInformation'  is null.");
            }
            var companyInformation = await _context.CompanyInformation.FindAsync(id);
            if (companyInformation != null)
            {
                _context.CompanyInformation.Remove(companyInformation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyInformationExists(int id)
        {
          return (_context.CompanyInformation?.Any(e => e.CompanyId == id)).GetValueOrDefault();
        }
    }
}
