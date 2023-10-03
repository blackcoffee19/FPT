using Ex3.Models;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ex3.Controllers
{
    public class StockController : Controller
    {
        public StockDbContext ctx;
        IWebHostEnvironment env;
        public StockController(StockDbContext ctx, IWebHostEnvironment env)
        {
            this.ctx = ctx;
            this.env = env;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Account acc) {
            if (ModelState.IsValid)
            {
                var check = await ctx.Accounts.FirstOrDefaultAsync(x => x.Username == acc.Username && x.Password == acc.Password);
                if (check == null)
                {
                    return RedirectToAction("Index",acc);
                }
                else
                {
                    if (check.Role)
                    {
                        return RedirectToAction("Listitem");
                    }else
                    {
                        return View("Profile",check);
                    }
                }
            }
            return RedirectToAction("Index", acc);
        }
        public async Task<IActionResult> Listitem()
        {
            List<Item> items = await ctx.Items.ToListAsync();
            ViewData["items"] = items;
            foreach (var i in items)
            {
                Console.WriteLine(i);
            }
            return View();
        }
        [HttpGet("Profile/{id}")]
        public async Task<IActionResult> Profile(int id)
        {
            Account? acc = await ctx.Accounts.FirstOrDefaultAsync(y => y.Id == id);
            if(acc != null)
            {
                return View(acc);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(AccountDto acc)
        {
            if (ModelState.IsValid)
            {
                if (acc.Password != acc.ConfirmPassword)
                {
                    return RedirectToAction("CreateUser");
                }
                var filename = String.Empty;
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
                }
                Account? account = new Account { Username = acc.Username, Password = acc.Password, Role = false, Image = filename };
                try
                {
                    ctx.Accounts.Add(account);
                    await ctx.SaveChangesAsync();
                }catch(Exception err)
                {
                    Console.WriteLine(err);
                    return View();
                }
                return RedirectToAction("Profile",account);

            }
            else
            {
                return RedirectToAction("CreateUser");
            }
        }
        public ActionResult CreateItem() {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateItem(ItemDto itemdto)
        {

            if (ModelState.IsValid)
            {
                var filename = String.Empty;
                if (itemdto.Photo != null)
                {
                    filename = itemdto.Photo.FileName;
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
                        await itemdto.Photo.CopyToAsync(stream);
                    };
                }
                Item? item = new Item() { Image=filename,ItemCode=itemdto.ItemCode,ItemName=itemdto.ItemName,Price=itemdto.Price};
                Console.WriteLine(item);
                try
                {
                    ctx.Items!.Add(item);
                    await ctx.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                return RedirectToAction("Listitem");
            }
            else
            {
                var invalidItems = ModelState.Where(ms => ms.Value.Errors.Any()).ToList();

                foreach (var item in invalidItems)
                {
                    Console.WriteLine(item);
                    // Here you have access to item.Key which is name of the property
                    // And value which is current model state for property 
                }
                return View("Error",invalidItems);   
            }
        }
        [HttpGet("EditItem/{id}")]
        public async Task<IActionResult> EditItem(int id)
        {
            Item? item = await ctx.Items.FirstOrDefaultAsync(x=>x.Id==id);
            ItemDto? ite = new ItemDto() { Id = id ,ItemCode=item.ItemCode,ItemName=item.ItemName,Price=item.Price,Image=item.Image};
            return View(ite);
        }
        [HttpPost("EditItem/{id}")]
        public async Task<IActionResult> EditItem(int id,ItemDto item)
        {
            if (ModelState.IsValid)
            {
                Item? items = await ctx.Items.FirstOrDefaultAsync(x=>x.Id==id);
                if (items != null)
                {
                    var filename = String.Empty;
                    if (item.Photo != null)
                    {
                        filename = item.Photo.FileName;
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
                            await item.Photo.CopyToAsync(stream);
                        };
                    }
                    items.Image = filename!=String.Empty?filename:items.Image;
                    items.ItemCode = items.ItemCode != item.ItemCode ? item.ItemCode : items.ItemCode;
                    items.ItemName= item.ItemName!= items.ItemName? item.ItemName : items.ItemName;
                    items.Price = item.Price != items.Price ? item.Price : items.Price;
                    try
                    {
                        ctx.Entry(items).State = EntityState.Modified;
                        await ctx.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    return RedirectToAction("Listitem");

                }

            }
            return View(item);
        }
        [HttpGet("DeleteItem/{id}")]
        public async Task<IActionResult> DeleteItem(int id) {
            Item? item = await ctx.Items.FirstOrDefaultAsync(x => x.Id == id);
            if (item != null)
            {
                ctx.Entry(item).State = EntityState.Deleted;
                await ctx.SaveChangesAsync();
            }
            return RedirectToAction("Listitem");
        }
    }
}
