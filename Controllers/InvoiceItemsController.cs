using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleCRUD.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleCRUD.Controllers
{
    public class InvoiceItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InvoiceItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InvoiceItem
        public async Task<IActionResult> Index()
        {
            return View(await _context.InvoiceItems.ToListAsync());
        }

        // GET: InvoiceItem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceItem = await _context.InvoiceItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoiceItem == null)
            {
                return NotFound();
            }

            return View(invoiceItem);
        }

        // GET: InvoiceItem/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InvoiceItem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Quantity,UnitPrice,InvoiceId")] InvoiceItem invoiceItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoiceItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invoiceItem);
        }

        // GET: InvoiceItem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceItem = await _context.InvoiceItems.FindAsync(id);
            if (invoiceItem == null)
            {
                return NotFound();
            }
            return View(invoiceItem);
        }

        // POST: InvoiceItem/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Quantity,UnitPrice,InvoiceId")] InvoiceItem invoiceItem)
        {
            if (id != invoiceItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoiceItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceItemExists(invoiceItem.Id))
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
            return View(invoiceItem);
        }

        // GET: InvoiceItem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceItem = await _context.InvoiceItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoiceItem == null)
            {
                return NotFound();
            }

            return View(invoiceItem);
        }

        // POST: InvoiceItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoiceItem = await _context.InvoiceItems.FindAsync(id);
            if (invoiceItem != null)
            {
                _context.InvoiceItems.Remove(invoiceItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceItemExists(int id)
        {
            return _context.InvoiceItems.Any(e => e.Id == id);
        }
    }
}
