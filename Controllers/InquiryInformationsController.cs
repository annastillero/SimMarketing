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
    public class InquiryInformationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InquiryInformationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InquiryInformations
        public async Task<IActionResult> Index()
        {
              return _context.InquiryInformation != null ? 
                          View(await _context.InquiryInformation.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.InquiryInformation'  is null.");
        }

        // GET: InquiryInformations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InquiryInformation == null)
            {
                return NotFound();
            }

            var inquiryInformation = await _context.InquiryInformation
                .FirstOrDefaultAsync(m => m.InquiryInformationId == id);
            if (inquiryInformation == null)
            {
                return NotFound();
            }

            return View(inquiryInformation);
        }

        // GET: InquiryInformations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InquiryInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InquiryInformationId,Firstname,Lastname,Middlename,Email,MobilePhone,PhoneNumber,InquiryInformation1,Department,Position")] InquiryInformation inquiryInformation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inquiryInformation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inquiryInformation);
        }

        // GET: InquiryInformations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InquiryInformation == null)
            {
                return NotFound();
            }

            var inquiryInformation = await _context.InquiryInformation.FindAsync(id);
            if (inquiryInformation == null)
            {
                return NotFound();
            }
            return View(inquiryInformation);
        }

        // POST: InquiryInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InquiryInformationId,Firstname,Lastname,Middlename,Email,MobilePhone,PhoneNumber,InquiryInformation1,Department,Position")] InquiryInformation inquiryInformation)
        {
            if (id != inquiryInformation.InquiryInformationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inquiryInformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InquiryInformationExists(inquiryInformation.InquiryInformationId))
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
            return View(inquiryInformation);
        }

        // GET: InquiryInformations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InquiryInformation == null)
            {
                return NotFound();
            }

            var inquiryInformation = await _context.InquiryInformation
                .FirstOrDefaultAsync(m => m.InquiryInformationId == id);
            if (inquiryInformation == null)
            {
                return NotFound();
            }

            return View(inquiryInformation);
        }

        // POST: InquiryInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InquiryInformation == null)
            {
                return Problem("Entity set 'ApplicationDbContext.InquiryInformation'  is null.");
            }
            var inquiryInformation = await _context.InquiryInformation.FindAsync(id);
            if (inquiryInformation != null)
            {
                _context.InquiryInformation.Remove(inquiryInformation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InquiryInformationExists(int id)
        {
          return (_context.InquiryInformation?.Any(e => e.InquiryInformationId == id)).GetValueOrDefault();
        }
    }
}
