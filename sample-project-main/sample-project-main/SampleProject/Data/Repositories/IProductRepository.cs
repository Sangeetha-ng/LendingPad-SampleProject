using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Data.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Product Get(Guid id);
        IEnumerable<Product> Get(string name = null, string description = null,
            decimal price = 0, int stockQuantity = 0);       
        IEnumerable<object> AsQueryable();

        void DeleteAll();
    }
}
