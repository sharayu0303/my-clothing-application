using System;

namespace Clothify.Product.Domain.Entities
{
    public class ProductSizeEntity
    {
        public Guid Id { get; set; }
        public string Size { get; set; } = string.Empty;  // "M", "S", "L"
        public Guid ProductId { get; set; }
        public ProductEntity ProductEntity { get; set; }

    }
}