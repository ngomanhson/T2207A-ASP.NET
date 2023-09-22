using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using T2207A_API.Entities;
using T2207A_API.DTOs;
using T2207A_API.Models.Category;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace T2207A_API.Controllers
{
    [ApiController]
    [Route("/api/category")]
    public class CategoryController : Controller
    {
        private readonly T2207aApiContext _context;

        public CategoryController(T2207aApiContext context) // reflection
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Category> categories = _context.Categories.ToList();

            List<CategoryDTO> data = new List<CategoryDTO>();
            foreach (Category c in categories)
            {
                data.Add(new CategoryDTO { id = c.Id, name = c.Name });
            }
            return Ok(data);
        }

        [HttpGet]
        [Route("get-by-id")]
        public IActionResult Get(int id)
        {
            try
            {
                Category c = _context.Categories.Find(id);
                if (c != null)
                {
                    return Ok(new CategoryDTO { id = c.Id, name = c.Name });
                }
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return NotFound();
        }


        [HttpPost]
        public IActionResult Create(CreateCategory model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Category data = new Category { Name = model.name };
                    _context.Categories.Add(data);
                    _context.SaveChanges();
                    return Created($"get-by-id?id={data.Id}", new CategoryDTO { id = data.Id, name = data.Name});
                } catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            var msgs = ModelState.Values.SelectMany(v => v.Errors).Select(v => v.ErrorMessage);
            return BadRequest(string.Join(" | ", msgs));
        }

        [HttpPut]
        public IActionResult Update(EditCategory model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Category category = new Category { Id = model.id, Name = model.name };
                    if (category != null)
                    {
                        _context.Categories.Update(category);
                        _context.SaveChanges();
                        return NoContent();
                    }
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);

                }

            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                Category category = _context.Categories.Find(id);
                if (category == null)
                    return NotFound();
                _context.Categories.Remove(category);
                _context.SaveChanges();
                return NoContent();
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

