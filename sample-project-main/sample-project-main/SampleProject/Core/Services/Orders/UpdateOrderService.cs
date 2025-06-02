using System;
using System.Collections.Generic;
using BusinessEntities;
using Common;

namespace Core.Services.Orders
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class UpdateOrderService : IUpdateOrderService
    {
        public void Update(
            Order order,
            DateTime orderDate,
            Guid productIds,
            decimal totalAmount,
            string customerName, string customerEmail, string customerPhone, string customerAddress)
        {
            order.SetOrderDate(orderDate);
            order.SetProducts(productIds);
            order.SetTotalAmount(totalAmount);
            order.SetCustomerName(customerName);
            order.SetCustomerEmail(customerEmail);
            order.SetCustomerPhone(customerPhone);
            order.SetCustomerAddress(customerAddress);
        }
    }
}
