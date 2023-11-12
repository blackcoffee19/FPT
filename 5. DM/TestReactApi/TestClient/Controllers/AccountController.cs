using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestClient.Models;
using TestClient.Services;

namespace TestClient.Controllers
{
    public class AccountController : Controller
    {
        IAccountService service;
        IWebHostEnvironment env;
        public AccountController (IAccountService service, IWebHostEnvironment env)
        {
            this.service = service;
            this.env = env;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AccountDto acc)
        {
            AccountDto? account = await service.CheckLogin(acc.Email, acc.Password);
            if (account == null)
            {
                return View();
            }else
            {
                if (account.Admin.Value== true)
                {
                    return RedirectToAction("ListAccount");
                }
                else
                {
                    return RedirectToAction("AccountDetail", new {id = account.Id});
                }
            }
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AccountDto acc) {
            string filename;
            if (!ModelState.IsValid) {
                return View(acc); }
            else
            {
                if (acc.Photo != null)
                {
                    filename = acc.Photo.FileName;
                    var imageFolder = Path.Combine(env.WebRootPath, "Images");
                    //Check folder Exist
                    if (!Directory.Exists(imageFolder))
                    {
                        //Create new
                        Directory.CreateDirectory(imageFolder);
                    }
                    var filePath = Path.Combine(imageFolder, filename);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await acc.Photo.CopyToAsync(stream);
                    };
                    acc.Image = filename;
                }
                string? submited = await service.Create(acc);
                Console.WriteLine(submited);
                if (submited!=null)
                {
                    return RedirectToAction("ListAccount");
                }
                else
                {
                    Console.WriteLine("Error");
                    Console.WriteLine(acc);
                }
            }
            return View(acc);
        }
        [HttpGet]
        [Route("AccountDetail/{id}")]
        public async Task<IActionResult> AccountDetail(int? id)
        {
            if (id == null) { return RedirectToAction("Index"); }
            else
            {
                AccountDto? acc = await service.FindById((int)id);
                
                return View(acc);
            }
        }
        public async Task<IActionResult> ListAccount([FromQuery(Name = "search")] string? search) {
            IEnumerable<AccountDto>? list = await service.ListAccount(search);
            return View(list);
        }
        [HttpGet]
        [Route("UpdateAccount/{id}")]
        public async Task<IActionResult> UpdateAccount(int id)
        {
            AccountDto? acc = await service.FindById(id);
            return View(acc);
        }
        [HttpPost]
        [Route("UpdateAccount/{id}")]
        public async Task<IActionResult> UpdateAccount(int id,AccountDto acc)
        {
            string filename = String.Empty;
            if (acc == null || !ModelState.IsValid) { return View(acc); }
            else
            {
                if(acc.Photo!= null)
                {
                    filename = acc.Photo.FileName;
                    var imageFolder = Path.Combine(env.WebRootPath, "Images");
                    //Check folder Exist
                    if (!Directory.Exists(imageFolder))
                    {
                        //Create new
                        Directory.CreateDirectory(imageFolder);
                    }
                    var filePath = Path.Combine(imageFolder, filename);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await acc.Photo.CopyToAsync(stream);
                    };
                    acc.Image = filename;
                }
                bool submited = await service.Update(id,acc);
                if (submited)
                {
                    return RedirectToAction("ListAccount");
                }
                else
                {
                    Console.WriteLine("Error");
                    Console.WriteLine(acc);
                }
            }
            return View(acc);
        }
        
    }   
}
