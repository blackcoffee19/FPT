using ProductOnion.Models;

namespace ProductOnion.Repositories
{
    public interface IProductRepository 
    {
        public Task<List<ProductDto>> FindAll();
        public Task<ProductDto> Create(ProductDto dto);
        public Task<ProductDto> FindById(int id);
        public Task<ProductDto> Update(int id, ProductDto dto);
    }
}
