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
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Food/Orders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.orders.Include(o => o.Customers).Include(o => o.Foodmenu);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Food/Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.orders
                .Include(o => o.Customers)
                .Include(o => o.Foodmenu)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // GET: Food/Orders/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerID", "CustomerName" , "MobileNUmber");
            ViewData["FoodId"] = new SelectList(_context.Foodmenu, "FoodId", "FoodName");
            return View();
        }

        // POST: Food/Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,OrderName,CustomerId,CustomerName,FoodId,Quantity")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                orders.OrderName = orders.OrderName.Trim();

                bool isDuplicateFound
                    =_context.orders.Any(o => o.OrderName == orders.OrderName);
                if(isDuplicateFound)
                {
                    ModelState.AddModelError("OrderName", "Duplicate ! Another category with same name exists");

                }
                else
                {
                    _context.Add(orders);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                
            }
            //ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerID", "CustomerName", orders.CustomerId);
            //ViewData["FoodId"] = new SelectList(_context.Foodmenu, "FoodId", "FoodName", orders.FoodId);
            return View(orders);
        }

        // GET: Food/Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerID", "CustomerName", orders.CustomerId);
            ViewData["FoodId"] = new SelectList(_context.Foodmenu, "FoodId", "FoodName", orders.FoodId);
            return View(orders);
        }

        // POST: Food/Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,OrderName,CustomerId,CustomerName,FoodId,Quantity")] Orders orders)
        {
            if (id != orders.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersExists(orders.OrderId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerID", "CustomerName", orders.CustomerId);
            ViewData["FoodId"] = new SelectList(_context.Foodmenu, "FoodId", "FoodName", orders.FoodId);
            return View(orders);
        }

        // GET: Food/Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.orders
                .Include(o => o.Customers)
                .Include(o => o.Foodmenu)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // POST: Food/Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orders = await _context.orders.FindAsync(id);
            _context.orders.Remove(orders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersExists(int id)
        {
            return _context.orders.Any(e => e.OrderId == id);
        }
    }
}
