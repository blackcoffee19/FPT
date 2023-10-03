using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductOnion.Data;
using ProductOnion.Models;
using ProductOnion.Repositories;

namespace ProductOnion.Controllers
{
    public class ProductController : Controller
    {
        IProductRepository repo;
        IWebHostEnvironment env;
        public ProductController(IProductRepository repo, IWebHostEnvironment e) {
            this.repo = repo;
            this.env =e;
        }
        public async Task<IActionResult> Index()
        {
            var products = await repo.FindAll();
            return View(products);
        }
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductDto dto)
        {
            if (ModelState.IsValid)
            {
                string fileName = string.Empty;
                if(dto.Photo!= null)
                {
                    fileName = dto.Photo.FileName;
                    var imageFolder = Path.Combine(env.WebRootPath,"Images");
                    //Check folder Exist
                    if(!Directory.Exists(imageFolder)) { 
                        //Create new
                        Directory.CreateDirectory(imageFolder);
                    }
                    var filePath = Path.Combine(imageFolder, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create)) {
                        await dto.Photo.CopyToAsync(stream);
                    } ;
                    
                }
                dto.Image = fileName;
                await repo.Create(dto);
                return RedirectToAction("Index");
            }
            else
            {
                Console.WriteLine(ModelState);
                return View(dto);
            }
        }
        [HttpGet("Create/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            ProductDto dto = await repo.FindById(id);
            Console.WriteLine(dto.Id);
            Console.WriteLine(dto.Image);
            return View("Update",dto);
        }
        [HttpPost("Create/{id}")]
        public async Task<IActionResult> Update(int id,ProductDto dto)
        {
            if (ModelState.IsValid)
            {
                string fileName = string.Empty;
                if (dto.Photo != null)
                {
                    fileName = dto.Photo.FileName;
                    var imageFolder = Path.Combine(env.WebRootPath, "Images");
                    //Check folder Exist
                    if (!Directory.Exists(imageFolder))
                    {
                        //Create new
                        Directory.CreateDirectory(imageFolder);
                    }
                    var filePath = Path.Combine(imageFolder, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await dto.Photo.CopyToAsync(stream);
                    };
                    dto.Image = fileName;
                }
                await repo.Update(id,dto);
                return RedirectToAction("Index");
            }
            else
            {
                Console.WriteLine(ModelState);
                return View(dto);
            }
            return RedirectToAction("Index");
        }
    }
}
