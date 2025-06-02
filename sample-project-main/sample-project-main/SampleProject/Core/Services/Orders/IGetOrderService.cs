using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Core.Services.Orders
{
    public interface IGetOrderService
    {
        Order GetOrder(Guid id);

        IEnumerable<Order> GetOrders(DateTime orderDate = default,
            Guid productIds = default,
            decimal totalAmount = 0,
            string customerName = null, string customerEmail = null, string customerPhone = null, string customerAddress = null);
    }
}
