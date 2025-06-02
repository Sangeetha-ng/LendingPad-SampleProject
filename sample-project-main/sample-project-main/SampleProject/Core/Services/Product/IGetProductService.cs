using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Services.Product
{
    public interface IGetProductService
    {
        BusinessEntities.Product GetProduct(Guid id);

        IQueryable<BusinessEntities.Product> GetProducts(
        string name = null,
        string description = null,
        decimal? minPrice = null,
        decimal? maxPrice = null,
        int? minStockQuantity = null,
        int? maxStockQuantity = null
    );
    }
}
