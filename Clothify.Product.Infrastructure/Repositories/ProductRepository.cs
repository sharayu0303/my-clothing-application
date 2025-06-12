using Clothify.Product.Application.Interfaces;
using Clothify.Product.Domain.Entities;
using Clothify.Product.Domain.Interfaces;
using Clothify.Product.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothify.Product.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductEntity>> GetAllProductsAsync()
        {
            //return await _context.Products.ToListAsync();   // This will load Products only 
            return await _context.Products.Include(p => p.Sizes).ToListAsync();  //This will load Products with their sizes
        }

        public async Task<ProductEntity> GetProductByIdAsync(Guid id)
        {
            return await _context.Products.Include(p => p.Sizes).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ProductEntity> AddProductAsync(ProductEntity product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> UpdateProductAsync(ProductEntity product)
        {
            _context.Products.Update(product);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteProductByIdAsync(Guid id)
        {
            var existing = await _context.Products.FindAsync(id);
            if (existing == null)
            {
                return false;
            }

            _context.Products.Remove(existing);
            return await _context.SaveChangesAsync() > 0;
        }

        
        
    }
}
