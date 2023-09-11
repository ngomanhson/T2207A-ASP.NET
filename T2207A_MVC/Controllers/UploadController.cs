using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace T2207A_MVC.Controllers
{
    public class UploadController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormFile image)
        {
            if (image == null)
            {
                return BadRequest("Vui lòng chọn file");
            }
            string path = "wwwroot/uploads";
            string fileName = Guid.NewGuid().ToString()
                    + Path.GetExtension(image.FileName);
            var upload = Path.Combine(Directory.GetCurrentDirectory(),
                path, fileName);
            image.CopyTo(new FileStream(upload, FileMode.Create));
            string url = $"{Request.Scheme}://{Request.Host}/uploads/{fileName}";
            return Ok(url);
        }
    }
}

