using Common;
using Data.Repositories;
using System;
using System.Linq;

namespace Core.Services.Product
{
    [AutoRegister]
    public class GetProductService : IGetProductService
    {
        private readonly IProductRepository _productRepository;

        public GetProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public BusinessEntities.Product GetProduct(Guid id)
        {
            return _productRepository.Get(id);
        }

        public IQueryable<BusinessEntities.Product> GetProducts(
        string name = null, string description = null,
        decimal? minPrice = null,
        decimal? maxPrice = null,
        int? minStockQuantity = null,
        int? maxStockQuantity = null)
        {
            var query = _productRepository.AsQueryable().Cast<BusinessEntities.Product>();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(p => p.Name != null && p.Name.Contains(name));

            if (!string.IsNullOrEmpty(description))
                query = query.Where(p => p.Description != null && p.Description.Contains(description));

            if (minPrice.HasValue)
                query = query.Where(p => p.Price >= minPrice.Value);

            if (maxPrice.HasValue)
                query = query.Where(p => p.Price <= maxPrice.Value);

            if (minStockQuantity.HasValue)
                query = query.Where(p => p.StockQuantity >= minStockQuantity.Value);

            if (maxStockQuantity.HasValue)
                query = query.Where(p => p.StockQuantity <= maxStockQuantity.Value);

            return query.AsQueryable();
        }
    }
}
