using CQRS_Example.Domain.Entities;

namespace CQRS_Example.Domain.Interfaces
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetAllProductsAsync();
        public Task<Product> GetProductByIdAsync(int Id);
        public Task<Product> AddProductAsync(Product product);
        public Task<bool> UpdateProductAsync(Product product);
        public Task<bool> DeleteProductAsync(int Id);
    }
}
