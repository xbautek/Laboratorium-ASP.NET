using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectData;
using ProjectData.Entities;

namespace Laboratorium_3___Homework.Controllers
{
    public class AuthorController : Controller
    {
        private readonly AppDbContext _context;

        public AuthorController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Author
        public async Task<IActionResult> Index()
        {
              return _context.Authors != null ? 
                          View(await _context.Authors.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Authors'  is null.");
        }

        // GET: Author/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }

            var authorEntity = await _context.Authors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (authorEntity == null)
            {
                return NotFound();
            }

            return View(authorEntity);
        }

        // GET: Author/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Email")] AuthorEntity authorEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(authorEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(authorEntity);
        }

        // GET: Author/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }

            var authorEntity = await _context.Authors.FindAsync(id);
            if (authorEntity == null)
            {
                return NotFound();
            }
            return View(authorEntity);
        }

        // POST: Author/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Email")] AuthorEntity authorEntity)
        {
            if (id != authorEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(authorEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorEntityExists(authorEntity.Id))
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
            return View(authorEntity);
        }

        // GET: Author/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }

            var authorEntity = await _context.Authors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (authorEntity == null)
            {
                return NotFound();
            }

            return View(authorEntity);
        }

        // POST: Author/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Authors == null)
            {
                return Problem("Entity set 'AppDbContext.Authors'  is null.");
            }
            var authorEntity = await _context.Authors.FindAsync(id);
            if (authorEntity != null)
            {
                _context.Authors.Remove(authorEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorEntityExists(int id)
        {
          return (_context.Authors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
