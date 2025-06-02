using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Core.Services.Orders
{
    public interface ICreateOrderService
    {
        Order Create(Guid id, DateTime orderDate, Guid productIds, decimal totalAmount, string customerName,
            string customerEmail,string customerPhone, string customerAddress);
    }
}
