using System;
using System.Collections.Generic;
using System.Linq;
using BusinessEntities;

namespace WebApi.Models.Orders
{
    public class OrderData : IdObjectData
    {
        public OrderData(Order order) : base(order)
        {
            OrderDate = order.OrderDate;
            ProductID = order.ProductID;
            TotalAmount = order.TotalAmount;
            CustomerName = order.CustomerName;
            CustomerEmail = order.CustomerEmail;
            CustomerPhone = order.CustomerPhone;
            CustomerAddress = order.CustomerAddress;
        }

        public DateTime OrderDate { get; set; }
        public Guid ProductID { get; set; }
        public decimal TotalAmount { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
    }
}
