using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities;
using Core.Services.Orders;
using WebApi.Models.Orders;

namespace WebApi.Controllers
{
    [RoutePrefix("orders")]
    public class OrderController : BaseApiController
    {
        private readonly ICreateOrderService _createOrderService;
        private readonly IDeleteOrderService _deleteOrderService;
        private readonly IGetOrderService _getOrderService;
        private readonly IUpdateOrderService _updateOrderService;

        public OrderController(
            ICreateOrderService createOrderService,
            IDeleteOrderService deleteOrderService,
            IGetOrderService getOrderService,
            IUpdateOrderService updateOrderService)
        {
            _createOrderService = createOrderService;
            _deleteOrderService = deleteOrderService;
            _getOrderService = getOrderService;
            _updateOrderService = updateOrderService;
        }

        [Route("{orderId:guid}/create")]
        [HttpPost]
        public HttpResponseMessage CreateOrder(Guid orderId, [FromBody] OrderModel model)
        {
            var order = _getOrderService.GetOrder(orderId);
            if (order != null)
            {
                return Conflict();
            }
            var neworder = _createOrderService.Create(orderId, model.OrderDate, model.ProductIds, model.TotalAmount, model.CustomerName,
                model.CustomerEmail, model.CustomerPhone, model.CustomerAddress);
            return Found(new OrderData(neworder));
        }

        [Route("{orderId:guid}/update")]
        [HttpPut]
        public HttpResponseMessage UpdateOrder(Guid orderId, [FromBody] OrderModel model)
        {
            var order = _getOrderService.GetOrder(orderId);
            if (order == null)
            {
                return DoesNotExist();
            }
            _updateOrderService.Update(order, model.OrderDate, model.ProductIds, model.TotalAmount, model.CustomerName,
                model.CustomerEmail, model.CustomerPhone, model.CustomerAddress);
            return Found(new OrderData(order));
        }

        [Route("{orderId:guid}/delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteOrder(Guid orderId)
        {
            var order = _getOrderService.GetOrder(orderId);
            if (order == null)
            {
                return DoesNotExist();
            }
            _deleteOrderService.Delete(order);
            return Found();
        }

        [Route("{orderId:guid}")]
        [HttpGet]
        public HttpResponseMessage GetOrder(Guid orderId)
        {
            var order = _getOrderService.GetOrder(orderId);
            return Found(new OrderData(order));
        }

        [Route("list")]
        [HttpGet]
        public HttpResponseMessage GetOrders(
        int skip, int take,
        DateTime? orderDate = null,
        Guid? productIds = null,
        decimal? totalAmount = null,
        string customerName = null, string customerEmail = null,
        string customerPhone = null, string customerAddress = null)
        {
            var orders = _getOrderService.GetOrders(
                orderDate ?? default,
                productIds ?? default,
                totalAmount ?? 0,
                customerName, customerEmail, customerPhone, customerAddress)
                .Skip(skip).Take(take)
                .Select(o => new OrderData(o))
                .ToList();
            return Found(orders);
        }


        [Route("clear")]
        [HttpDelete]
        public HttpResponseMessage DeleteAllOrders()
        {
            _deleteOrderService.DeleteAll();
            return Found();
        }
    }
}
