using AutoMapper;
using Clothify.Product.Application.DTOs;
using Clothify.Product.Application.Interfaces;
using Clothify.Product.Domain.Entities;
using Clothify.Product.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothify.Product.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _repository.GetAllProductsAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            var product = await _repository.GetProductByIdAsync(id);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> AddAsync(CreateProductDto dto)
        {
            var newProduct = _mapper.Map<ProductEntity>(dto);   // Get data from UI and store it in DB
            var saveProduct = await _repository.AddProductAsync(newProduct); // Saving Data / Storing Data
            return _mapper.Map<ProductDto>(newProduct); // Sending back the response with the created product
        }

        public async Task<bool> UpdateAsync(Guid id, CreateProductDto dto)
        {
            var product = _mapper.Map<ProductEntity>(dto);
            product.Id = id;
            return await _repository.UpdateProductAsync(product);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteProductByIdAsync(id);
        }

        

        
    }
}
