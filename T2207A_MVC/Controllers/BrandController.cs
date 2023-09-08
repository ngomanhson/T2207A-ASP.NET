using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using T2207A_MVC.Entities;
using T2207A_MVC.Models;
using T2207A_MVC.Models.Brand;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace T2207A_MVC.Controllers
{
    public class BrandController : Controller
    {
        private readonly DataContext _context;

        public BrandController(DataContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var brand = _context.Brands.ToList();
            // 1. ViewData["categories"] = categories; 
            // 2. ViewBag.categories = categories;
            return View(brand); // 3.
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ViewModel model)
        {
            if (ModelState.IsValid) // Validate
            {
                _context.Brands.Add(new Brand { name = model.name });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);

        }

        public async Task<IActionResult> Edit(int id)
        {
            Brand brand = await _context.Brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            return View(new EditModel { id = brand.id, name = brand.name });
        }

        [HttpPost]
        public IActionResult Edit(EditModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Brands.Update(new Brand { id = model.id, name = model.name });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Brand brand = _context.Brands.Find(id);
            if (brand == null)
            {
                return NotFound();
            }
            _context.Brands.Remove(brand);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

