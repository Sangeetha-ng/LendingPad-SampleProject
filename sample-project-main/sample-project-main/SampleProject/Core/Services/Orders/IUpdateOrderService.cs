using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Core.Services.Orders
{
    public interface IUpdateOrderService
    {
        void Update(
            Order order,
            DateTime orderDate,
            Guid productIds,
            decimal totalAmount,
            string customerName, string customerEmail, string customerPhone, string customerAddress
        );
    }
}
