using AutoMapper;
using Clothify.Product.Application.DTOs;
using Clothify.Product.Domain.Entities;

namespace Clothify.Product.Application.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductEntity, ProductDto>().ReverseMap();
            CreateMap<ProductEntity, CreateProductDto>().ReverseMap();
        }
    }
}
