using Humanizer;
using Microsoft.AspNetCore.Mvc;
using TestAdminCRUD.Data;
using TestAdminCRUD.Models;
using TestAdminCRUD.Respository;

namespace TestAdminCRUD.Controllers
{
    public class AdminController : Controller
    {
        IAdminRespository repo;
        IWebHostEnvironment env;
        public AdminController(IAdminRespository repo, IWebHostEnvironment e)
        {
            this.repo = repo;
            this.env = e;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormCollection user) { 
            AccountModel acc= await repo.Login(user["email"], user["password"]);
            if (acc != null && acc.Role == "admin")
            {
                return RedirectToAction("AdminSite");
            }else if (acc != null && acc.Role == "customer") {
                return View("CustomerSite", acc);
            }
            else
            {
                return View();
            }
            
        }
        public async Task<IActionResult> AdminSite()
        {
            IEnumerable<AccountModel>? accs = await repo.ListAccounts();
            return View("AdminSite", accs);
        }
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(AccountModel acc) {
            string fileName = string.Empty;
            Console.WriteLine(acc);
            if (acc.Photo != null)
            {
                fileName = acc.Photo.FileName;
                Console.WriteLine(fileName);
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
                    await acc.Photo.CopyToAsync(stream);
                };

            }
            acc.Image = fileName;
            if (ModelState.IsValid)
            {
                Console.WriteLine(acc);
                AccountModel? a = await repo.Signup(acc);
                if (a != null)
                {
                    return RedirectToAction("CustomerSite", a);
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(acc);
            }
            
        }
        public IActionResult CustomerSite(AccountModel acc)
        {
            return View("CustomerSite", acc);
        }
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public async Task<IActionResult> Create(AccountModel acc)
        {
            string fileName = string.Empty;
            if (acc.Photo != null)
            {
                fileName = acc.Photo.FileName;
                Console.WriteLine(fileName);
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
                    await acc.Photo.CopyToAsync(stream);
                };

            }
            acc.Image = fileName;
            if (ModelState.IsValid)
            {
                AccountModel? a = await repo.Signup(acc);
                if (a != null)
                {
                    return RedirectToAction("AdminSite", a);
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(acc);
            }
        }
    }
}
