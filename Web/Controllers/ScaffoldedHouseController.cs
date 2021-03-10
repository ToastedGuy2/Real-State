using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entities;
using Repositories.Context;

namespace Web.Controllers
{
    public class ScaffoldedHouseController : Controller
    {
        private readonly RealStateDbContext _context;

        public ScaffoldedHouseController(RealStateDbContext context)
        {
            _context = context;
        }

        // GET: ScaffoldedHouse
        public async Task<IActionResult> Index()
        {
            var realStateDbContext = _context.Houses.Include(h => h.Province);
            return View(await realStateDbContext.ToListAsync());
        }

        // GET: ScaffoldedHouse/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var house = await _context.Houses
                .Include(h => h.Province)
                .FirstOrDefaultAsync(m => m.HouseId == id);
            if (house == null)
            {
                return NotFound();
            }

            return View(house);
        }

        // GET: ScaffoldedHouse/Create
        public IActionResult Create()
        {
            ViewData["ProvinceId"] = new SelectList(_context.Provinces, "ProvinceId", "Name");
            return View();
        }

        // POST: ScaffoldedHouse/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HouseId,Name,Price,Description,Bathrooms,Bedrooms,Size,IsItAvailable,ProvinceId,ImageName")] House house)
        {
            if (ModelState.IsValid)
            {
                _context.Add(house);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProvinceId"] = new SelectList(_context.Provinces, "ProvinceId", "Name", house.ProvinceId);
            return View(house);
        }

        // GET: ScaffoldedHouse/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var house = await _context.Houses.FindAsync(id);
            if (house == null)
            {
                return NotFound();
            }
            ViewData["ProvinceId"] = new SelectList(_context.Provinces, "ProvinceId", "Name", house.ProvinceId);
            return View(house);
        }

        // POST: ScaffoldedHouse/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HouseId,Name,Price,Description,Bathrooms,Bedrooms,Size,IsItAvailable,ProvinceId,ImageName")] House house)
        {
            if (id != house.HouseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(house);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HouseExists(house.HouseId))
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
            ViewData["ProvinceId"] = new SelectList(_context.Provinces, "ProvinceId", "Name", house.ProvinceId);
            return View(house);
        }

        // GET: ScaffoldedHouse/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var house = await _context.Houses
                .Include(h => h.Province)
                .FirstOrDefaultAsync(m => m.HouseId == id);
            if (house == null)
            {
                return NotFound();
            }

            return View(house);
        }

        // POST: ScaffoldedHouse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var house = await _context.Houses.FindAsync(id);
            _context.Houses.Remove(house);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HouseExists(int id)
        {
            return _context.Houses.Any(e => e.HouseId == id);
        }
    }
}
