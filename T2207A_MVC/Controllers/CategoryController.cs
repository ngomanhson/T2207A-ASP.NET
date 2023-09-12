using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using T2207A_MVC.Entities;
using T2207A_MVC.Models;
using static System.Net.Mime.MediaTypeNames;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace T2207A_MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DataContext _context;

        public CategoryController(DataContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            // 1. ViewData["categories"] = categories; 
            // 2. ViewBag.categories = categories;
            return View(categories); // 3.
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(CategoryViewModel model)
        {
            if (ModelState.IsValid) // Viladate
            {
                _context.Categories.Add(new Category
                {
                    name = model.name
                });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }


        public async Task<IActionResult> Edit(int id)
        {
            Category category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(new CategoryEditModel { id = category.id, name = category.name});
        }

        [HttpPost]
        public IActionResult Edit(CategoryEditModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(new Category { id = model.id, name = model.name });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Category category = _context.Categories.Find(id);
            if(category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Soft delete

    }
}

