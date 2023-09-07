using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using T2207A_MVC.Entities;

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

        public IActionResult Edit()
        {
            return View();
        }
    }
}

