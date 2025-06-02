using System;
using System.Collections.Generic;
using BusinessEntities;
using Common;
using Data.Repositories;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class GetOrderService : IGetOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order GetOrder(Guid id)
        {
            return _orderRepository.Get(id);
        }

        public IEnumerable<BusinessEntities.Order> GetOrders(DateTime orderDate = default,
            Guid productIds = default,
            decimal totalAmount = 0,
            string customerName = null, string customerEmail = null, string customerPhone = null, string customerAddress = null)
        {
            return _orderRepository.Get(orderDate, productIds, totalAmount, customerName, customerEmail, customerPhone, customerAddress);
        }
    }
}
