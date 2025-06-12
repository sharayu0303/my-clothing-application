using Clothify.Product.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothify.Product.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(Guid id);
        Task<ProductDto> AddAsync(CreateProductDto dto);
        Task<bool> UpdateAsync(Guid id, CreateProductDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
