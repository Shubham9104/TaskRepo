using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant.web.Data;
using Restaurant.web.Models;

namespace Restaurant.web.Areas.Food.Controllers
{
    [Area("Food")]
    public class FoodCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FoodCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Food/FoodCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.FoodCategory.ToListAsync());
        }

        // GET: Food/FoodCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodCategory = await _context.FoodCategory
                .FirstOrDefaultAsync(m => m.FoodcategoryId == id);
            if (foodCategory == null)
            {
                return NotFound();
            }

            return View(foodCategory);
        }

        // GET: Food/FoodCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Food/FoodCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FoodcategoryId,FoodcategoryName")] FoodCategory foodCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foodCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(foodCategory);
        }

        // GET: Food/FoodCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodCategory = await _context.FoodCategory.FindAsync(id);
            if (foodCategory == null)
            {
                return NotFound();
            }
            return View(foodCategory);
        }

        // POST: Food/FoodCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FoodcategoryId,FoodcategoryName")] FoodCategory foodCategory)
        {
            if (id != foodCategory.FoodcategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodCategoryExists(foodCategory.FoodcategoryId))
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
            return View(foodCategory);
        }

        // GET: Food/FoodCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodCategory = await _context.FoodCategory
                .FirstOrDefaultAsync(m => m.FoodcategoryId == id);
            if (foodCategory == null)
            {
                return NotFound();
            }

            return View(foodCategory);
        }

        // POST: Food/FoodCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foodCategory = await _context.FoodCategory.FindAsync(id);
            _context.FoodCategory.Remove(foodCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodCategoryExists(int id)
        {
            return _context.FoodCategory.Any(e => e.FoodcategoryId == id);
        }
    }
}
