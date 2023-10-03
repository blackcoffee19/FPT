using Microsoft.EntityFrameworkCore;
using ProductOnion.Data;
using ProductOnion.Models;
using System.Linq;


namespace ProductOnion.Repositories
{
    public class ProductRepository : IProductRepository
    {
        ProductDbContext _db;
        public ProductRepository(ProductDbContext db)
        {
            this._db = db;
        }
        public async Task<List<ProductDto>> FindAll() { 
            var products = await _db.Products!.ToListAsync();
            return products.Select(pro => new ProductDto { Id = pro.Id, Name = pro.Name, Price = pro.Price, Image = pro.Image }).ToList();
        }
        public async Task<ProductDto> Create(ProductDto dto)
        {
            Product p = new Product { Id = dto.Id, Name = dto.Name, Price = dto.Price, Image = dto.Image };
            _db.Entry(p).State = EntityState.Added;
            await _db.SaveChangesAsync();
            return dto;
        }
        public async Task<ProductDto> FindById(int id)
        {
            Product p = await _db.Products!.FirstOrDefaultAsync(x => x.Id == id);
            if(p != null)
            {
                return new ProductDto{ Id = p.Id, Name = p.Name, Price = p.Price, Image = p.Image };
            }
            return null;
        }
        public async Task<ProductDto> Update(int id,ProductDto dto)
        {
            Product pro = await _db.Products!.FirstOrDefaultAsync(p => p.Id == id);
            pro.Name = dto.Name;
            pro.Price = dto.Price;

            if(dto.Image!=null && dto.Image != string.Empty)
            {
                pro.Image = dto.Image;
            }
            _db.Entry(pro).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return dto;
        }
    }
}
