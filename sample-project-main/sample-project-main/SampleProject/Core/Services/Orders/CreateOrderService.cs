using System;
using System.Collections.Generic;
using BusinessEntities;
using Common;
using Core.Factories;
using Core.Services.Orders;
using Data.Repositories;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class CreateOrderService : ICreateOrderService
    {
        private readonly IUpdateOrderService _updateOrderService;
        private readonly IIdObjectFactory<Order> _orderFactory;
        private readonly IOrderRepository _orderRepository;

        public CreateOrderService(
            IIdObjectFactory<Order> orderFactory,
            IOrderRepository orderRepository,
            IUpdateOrderService updateOrderService)
        {
            _orderFactory = orderFactory;
            _orderRepository = orderRepository;
            _updateOrderService = updateOrderService;
        }

        public Order Create(
            Guid id,
            DateTime orderDate,
            Guid productIds,
            decimal totalAmount,
            string customerName, string customerEmail, string customerPhone, string customerAddress)
        {
            var order = _orderFactory.Create(id);
            _updateOrderService.Update(order, orderDate, productIds, totalAmount, customerName, customerEmail, 
                customerPhone, customerAddress);
            _orderRepository.Save(order);
            return order;
        }
    }
}
