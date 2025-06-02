using System;
using System.Collections.Generic;
using System.Linq;
using BusinessEntities;
using Common;
using Data.Indexes;
using Raven.Client;

namespace Data.Repositories
{
    [AutoRegister]
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly IDocumentSession _documentSession;

        public ProductRepository(IDocumentSession documentSession) : base(documentSession)
        {
            _documentSession = documentSession;
        }

        public Product Get(Guid id)
        {
            return _documentSession.Load<Product>(id);
        }

        public IEnumerable<Product> Get(string name = null, string description = null, decimal price = 0, int stockQuantity = 0)
        {
            var query = _documentSession.Advanced.DocumentQuery<Product, ProductsListIndex>();

            var hasFirstParameter = false;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where($"Name:*{name}*");
                hasFirstParameter = true;
            }

            if (!string.IsNullOrEmpty(description))
            {
                if (hasFirstParameter)
                    query = query.AndAlso();
                else
                    hasFirstParameter = true;

                query = query.Where($"Description:*{description}*");
            }

            if (price > 0)
            {
                if (hasFirstParameter)
                    query = query.AndAlso();
                else
                    hasFirstParameter = true;

                query = query.WhereEquals("Price", price);
            }

            if (stockQuantity > 0)
            {
                if (hasFirstParameter)
                    query = query.AndAlso();

                query = query.WhereEquals("StockQuantity", stockQuantity);
            }

            return query.ToList();
        }
        public IEnumerable<object> AsQueryable()
        {
            return _documentSession.Query<Product>();
        }
        public void DeleteAll()
        {
            base.DeleteAll<ProductsListIndex>();
        }
    }
}
