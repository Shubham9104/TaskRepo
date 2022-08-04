using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Training1.web.Data;
using Training1.web.Models;

namespace Training1.web.Areas.Products.Controllers
{
    [Area("Products")]
    public class CategoriesController : Controller
    {
        private readonly PracticeContex _context;

        public CategoriesController(PracticeContex context)
        {
            _context = context;
        }

        // GET: Products/Categories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // GET: Products/Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Products/Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                // Sanitize the data before consumption
                category.CategoryName = category.CategoryName.Trim();

                // Check for Duplicate CategoryName
                bool isDuplicateFound
                    = _context.Categories.Any(c => c.CategoryName == category.CategoryName);
                if (isDuplicateFound)
                {
                    ModelState.AddModelError("CategoryName", "Duplicate! Another category with same name exists");
                }
                else
                {
                    // Save the changes 
                    _context.Add(category);
                    await _context.SaveChangesAsync();              // update the database
                    return RedirectToAction(nameof(Index));
                }
            }

            // Something must have gone wrong, so return the View with the model error(s).
            return View(category);
        }



        // GET: Products/Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Products/Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("CategoryId,CategoryName")] Category categoryInputModel)
        {
            if (id != categoryInputModel.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Sanitize the data before consumption
                categoryInputModel.CategoryName = categoryInputModel.CategoryName.Trim();

                // Check for duplicate Category
                bool isDuplicateFound
                    = _context.Categories.Any(c => c.CategoryName == categoryInputModel.CategoryName
                                                   && c.CategoryId != categoryInputModel.CategoryId);
                if (isDuplicateFound)
                {
                    ModelState.AddModelError("CategoryName", "A Duplicate Category was found!");
                }
                else
                {
                    try
                    {
                        // Save the changes to the database.
                        _context.Update(categoryInputModel);
                        await _context.SaveChangesAsync();

                        return RedirectToAction(nameof(Index));
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CategoryExists(categoryInputModel.CategoryId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
            }

            // Something must wrong.  Return the View with the ErrorModels
            return View(categoryInputModel);
        }

        // GET: Products/Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Products/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryId == id);
        }
    }
}
