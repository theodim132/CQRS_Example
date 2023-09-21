using CQRS_Example.Domain.Entities;
using CQRS_Example.Domain.Interfaces;
using CQRS_Example.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Example.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) => _context = context;

        public async Task<Product> AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProductAsync(int Id)
        {
            var productFromDb = await _context.Products.FirstOrDefaultAsync(x => x.Id == Id);
            if (productFromDb != null)
            {
                _context.Products.Remove(productFromDb);
                return true;
            }
            return false;
        }

        public async Task<Product> GetProductByIdAsync(int Id)
        {
            var productFromDb = await _context.Products.FirstOrDefaultAsync(x => x.Id == Id);
            if (productFromDb != null)
            {
                return productFromDb;
            }
            return new Product();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var productList = await _context.Products.ToListAsync();
            return productList;
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            var productFromDb = await _context.Products.FirstOrDefaultAsync(x => x.Id == product.Id);
            if (productFromDb != null)
            {
                productFromDb.Name = product.Name;
                _context.Update(productFromDb);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
