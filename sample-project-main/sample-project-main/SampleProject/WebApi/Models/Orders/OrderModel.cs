using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Orders
{
    public class OrderModel
    {
        [Required(ErrorMessage = "Order date is required.")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Product is required.")]
        public Guid ProductIds { get; set; }

        [Required(ErrorMessage = "Total amount is required.")]
        public decimal TotalAmount { get; set; }

        [Required(ErrorMessage = "Customer Name is required.")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Customer email is required.")]
        public string CustomerEmail { get; set; }

        [Required(ErrorMessage = "Customer contact no is required.")]
        public string CustomerPhone { get; set; }

        [Required(ErrorMessage = "Customer address is required.")]
        public string CustomerAddress { get; set; }
    }
}
