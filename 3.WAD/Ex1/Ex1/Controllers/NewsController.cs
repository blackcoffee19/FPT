using Ex1.Models;
using Ex1.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Ex1.Controllers
{
    public class NewsController : Controller
    {
        NewsRepository news;
        AdminRepository admins;
        public NewsController(AdminRepository admins, NewsRepository news)
        {
            this.admins = admins;
            this.news = news;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(IFormCollection user)
        {
            string userName = user["username"];
            string password = user["password"];
            bool check = await admins.Login(userName, password);
            if (check)
            {
                return RedirectToAction("Admin");
            }
            else
            {
                return View("Index");
            }
        }
        public async Task<IActionResult> ListNews()
        {
            IEnumerable<NewsDto> list = await news.FindAll();
            return View(list);
        }
        public IActionResult Admin()
        {
            return View("Admin");
        }
        public IActionResult CreateNews() {
            return View("CreateNews");
        }
        [HttpPost]
        public async Task<IActionResult> CreateNews(NewsDto ne)
        {
            try
            {
                await news.Create(ne);
            }catch(Exception err)
            {
                return View(ne);
            }
            return RedirectToAction("ListNews");
        }
        [HttpGet("EditNews/{id}")]
        public async Task<IActionResult> EditNews(int id) {
            NewsDto? newsEdit = await news.FindById(id);
            if (newsEdit != null)
            {
                return View("EditNews",newsEdit);
            }
            else
            {
                return View("ListNews");
            }
        }
        [HttpPost]
        public async Task<IActionResult> EditNews(NewsDto newsEdit)
        {
            try
            {
                await news.Edit(newsEdit);
            }catch(Exception err)
            {
                return View(newsEdit);
            }
            return RedirectToAction("ListNews");
        }
    }
}
