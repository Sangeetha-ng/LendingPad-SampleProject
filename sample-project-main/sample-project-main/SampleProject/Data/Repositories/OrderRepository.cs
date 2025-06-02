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
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly IDocumentSession _documentSession;

        public OrderRepository(IDocumentSession documentSession) : base(documentSession)
        {
            _documentSession = documentSession;
        }

        public Order Get(Guid id)
        {
            return _documentSession.Load<Order>(id);
        }

        public IEnumerable<Order> Get(DateTime? orderDate = null, Guid? productIds = null, decimal totalAmount = 0,
            string customerName = null, string customerEmail = null, string customerPhone = null, string customerAddress = null)
        {
            var query = _documentSession.Advanced.DocumentQuery<Order, OrdersListIndex>();

            var hasFirstParameter = false;
            if (!string.IsNullOrEmpty(customerName))
            {
                query = query.WhereEquals("CustomerName", customerName);
                hasFirstParameter = true;
            }

            if (orderDate != null)
            {
                if (hasFirstParameter)
                {
                    query = query.AndAlso();
                }
                else
                {
                    hasFirstParameter = true;
                }
                query = query.WhereEquals("OrderDate", orderDate);
            }

            if (totalAmount != null)
            {
                if (hasFirstParameter)
                {
                    query = query.AndAlso();
                }
                query = query.WhereEquals("TotalAmount", totalAmount);
            }
            if (productIds != null)
            {
                if (hasFirstParameter)
                {
                    query = query.AndAlso();
                }
                query = query.WhereEquals("ProductID", productIds);
            }
            if (!string.IsNullOrEmpty(customerEmail))
            {
                if (hasFirstParameter)
                {
                    query = query.AndAlso();
                }
                query = query.WhereEquals("CustomerEmail", customerEmail);
            }
            if (!string.IsNullOrEmpty(customerPhone))
            {
                if (hasFirstParameter)
                {
                    query = query.AndAlso();
                }
                query = query.WhereEquals("CustomerPhone", customerPhone);
            }
            if (!string.IsNullOrEmpty(customerAddress))
            {
                if (hasFirstParameter)
                {
                    query = query.AndAlso();
                }
                query = query.WhereEquals("CustomerAddress", customerAddress);
            }


            return query.ToList();
        }

        public void DeleteAll()
        {
            base.DeleteAll<OrdersListIndex>();
        }
    }
}
