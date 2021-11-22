using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP_Praktikum.Models;

namespace UCP_Praktikum.Controllers
{
    public class BorrowsController : Controller
    {
        private readonly TugasAkhirContext _context;

        public BorrowsController(TugasAkhirContext context)
        {
            _context = context;
        }

        // GET: Borrows
        public async Task<IActionResult> Index()
        {
            var tugasAkhirContext = _context.Borrows.Include(b => b.IdBukuNavigation).Include(b => b.IdPersonNavigation);
            return View(await tugasAkhirContext.ToListAsync());
        }

        // GET: Borrows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrow = await _context.Borrows
                .Include(b => b.IdBukuNavigation)
                .Include(b => b.IdPersonNavigation)
                .FirstOrDefaultAsync(m => m.IdBorrow == id);
            if (borrow == null)
            {
                return NotFound();
            }

            return View(borrow);
        }

        // GET: Borrows/Create
        public IActionResult Create()
        {
            ViewData["IdBuku"] = new SelectList(_context.Bukus, "IdBuku", "IdBuku");
            ViewData["IdPerson"] = new SelectList(_context.People, "IdPerson", "IdPerson");
            return View();
        }

        // POST: Borrows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBorrow,BorrowDate,DueDate,ReturnDate,IdBuku,IdPerson")] Borrow borrow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(borrow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBuku"] = new SelectList(_context.Bukus, "IdBuku", "IdBuku", borrow.IdBuku);
            ViewData["IdPerson"] = new SelectList(_context.People, "IdPerson", "IdPerson", borrow.IdPerson);
            return View(borrow);
        }

        // GET: Borrows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrow = await _context.Borrows.FindAsync(id);
            if (borrow == null)
            {
                return NotFound();
            }
            ViewData["IdBuku"] = new SelectList(_context.Bukus, "IdBuku", "IdBuku", borrow.IdBuku);
            ViewData["IdPerson"] = new SelectList(_context.People, "IdPerson", "IdPerson", borrow.IdPerson);
            return View(borrow);
        }

        // POST: Borrows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBorrow,BorrowDate,DueDate,ReturnDate,IdBuku,IdPerson")] Borrow borrow)
        {
            if (id != borrow.IdBorrow)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(borrow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BorrowExists(borrow.IdBorrow))
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
            ViewData["IdBuku"] = new SelectList(_context.Bukus, "IdBuku", "IdBuku", borrow.IdBuku);
            ViewData["IdPerson"] = new SelectList(_context.People, "IdPerson", "IdPerson", borrow.IdPerson);
            return View(borrow);
        }

        // GET: Borrows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrow = await _context.Borrows
                .Include(b => b.IdBukuNavigation)
                .Include(b => b.IdPersonNavigation)
                .FirstOrDefaultAsync(m => m.IdBorrow == id);
            if (borrow == null)
            {
                return NotFound();
            }

            return View(borrow);
        }

        // POST: Borrows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var borrow = await _context.Borrows.FindAsync(id);
            _context.Borrows.Remove(borrow);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BorrowExists(int id)
        {
            return _context.Borrows.Any(e => e.IdBorrow == id);
        }
    }
}
