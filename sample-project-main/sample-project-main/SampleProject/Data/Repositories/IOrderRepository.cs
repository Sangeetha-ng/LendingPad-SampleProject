using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Data.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {  
        Order Get(Guid id);
        IEnumerable<Order> Get(DateTime? orderDate = null, Guid? productIds = null, decimal totalAmount = 0,
            string customerName = null, string customerEmail = null, string customerPhone = null, string customerAddress = null);
        void DeleteAll();
    }
}
