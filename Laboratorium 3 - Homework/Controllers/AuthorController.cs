using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Laboratorium_3___Homework.Models;
using Microsoft.AspNetCore.Authorization;
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

        public async Task<IActionResult> Index()
        {
              return _context.Authors != null ? 
                          View(await _context.Authors.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Authors'  is null.");
        }

        [Authorize(Roles = "admin,user,guest")]
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

        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Create(AuthorEntity authorEntity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(authorEntity);
                    _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return View(authorEntity);
        }

        /*
        [HttpPost]
        public IActionResult Create(Photo model)
        {
            if (ModelState.IsValid)
            {
                _photoService.Add(model);
                return RedirectToAction("PagedIndex");

            }
            model.AuthorsList = CreateAuthorList();
            return View();
        }
        */

        [Authorize(Roles = "admin")]
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

        [Authorize(Roles = "admin")]
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

        [Authorize(Roles = "admin")]
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

        public IActionResult DeleteError()
        {
            return View();
        }


        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
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
            catch (Exception ex)
            {
                return RedirectToAction("DeleteError");
            }
        }

        private bool AuthorEntityExists(int id)
        {
          return (_context.Authors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
