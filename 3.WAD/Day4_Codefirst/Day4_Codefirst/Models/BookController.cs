using Day4_Codefirst.Data;
using Day4_Codefirst.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day4_Codefirst.Models
{
    public class BookController :Controller
    {
        BookDbContext db;// = new BookDbContext(); Error
        public BookController(BookDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Book>? books = db.Books.ToList();
            return View(books);   
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            if(book.Title!=null && book.Price >0)
            {
                db.Books!.Add(book);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["error"] = "Title and Price required";
                return View();
            }
        }
        public async Task<IActionResult> Search(string title)
        {
            var res = await db.Books.Where(e=>e.Title.Contains(title)).ToListAsync();
            return View("Index", res);
        }
        //[HttpGet("{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await db.Books!.SingleOrDefaultAsync(b => b.Id == id);
            return View(book);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,Book book)
        {
            db.Entry(book).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Book bo = db.Books!.First(b => b.Id == id); 
            db.Remove(bo);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
            /* Way 2
            Book? book = await db.Books!.SingleOrDefaultAsync(b => b.Id == id);
            db.Entry(book) = EntityState.Deleted;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");*/
        }
    }
}
