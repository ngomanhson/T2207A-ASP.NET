using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using T2207A_MVC.Entities;
using T2207A_MVC.Models.Product;
using T2207A_MVC.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace T2207A_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataContext _context;

        public ProductController(DataContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Product> products = _context.Products.Include(p => p.category).ToList();

            // ===== Search ===== //
            //List<Product> products = _context.Products
            //.Where(p => p.name.Equals("Apple").ToList();
            //.Where(p => p.name.Contains("Apple") || p.name.Conatains("iPhone").ToList();
            //.Take(10)
            //.Skip(10)
            //.Include(p => p.category)
            //.OrderBy(p => p.name) //asc
            //.OrderByDescending(p => p.name) // desc
            //.ToList();
            return View(products); 
        }

        public IActionResult Create()
        {

            var categories = _context.Categories.ToList();
            ViewBag.category = new SelectList(categories, "id", "name");

            var brands = _context.Brands.ToList();
            ViewBag.brands = new SelectList(brands, "id", "name");

            var viewModel = new ViewModel(); 
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(ViewModel model, IFormFile image)
        {
            var categories = _context.Categories.ToList();
            ViewBag.category = new SelectList(categories, "id", "name");

            var brands = _context.Brands.ToList();
            ViewBag.brand = new SelectList(brands, "id", "name");

            if (image == null)
            {
                return BadRequest("Please select file");
            }

            string path = "wwwroot/uploads";
            string fileName = Guid.NewGuid().ToString()
                    + Path.GetExtension(image.FileName);
            var upload = Path.Combine(Directory.GetCurrentDirectory(),
                path, fileName);
            image.CopyTo(new FileStream(upload, FileMode.Create));
            string url = $"{Request.Scheme}://{Request.Host}/uploads/{fileName}";

            if (!string.IsNullOrEmpty(model.category) && !string.IsNullOrEmpty(model.brand))
            {
                var product = new Product
                {
                    name = model.name,
                    price = model.price,
                    category_id = int.Parse(model.category),
                    brand_id = int.Parse(model.brand),
                    description = model.description,
                    image = url
                };

                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

           

            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Product product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }
            return View(new EditModel { id = product.id, name = product.name, price = product.price, description = product.description });
        }

        public IActionResult Delete(int id)
        {
            Product product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}

