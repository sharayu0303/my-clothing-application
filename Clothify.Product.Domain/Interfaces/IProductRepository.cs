using Clothify.Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothify.Product.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductEntity>> GetAllProductsAsync();
        Task<ProductEntity> GetProductByIdAsync(Guid id);
        Task<ProductEntity> AddProductAsync(ProductEntity product);
        Task<bool> UpdateProductAsync(ProductEntity product);
        Task<bool> DeleteProductByIdAsync(Guid id);
    }
}
