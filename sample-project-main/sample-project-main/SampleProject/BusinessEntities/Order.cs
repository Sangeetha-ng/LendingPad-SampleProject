using System;
using System.Collections.Generic;


namespace BusinessEntities
{
    public class Order : IdObject
    {
        private DateTime _orderDate;
        private Guid _productId; 
        private decimal _totalAmount;
        private string _customerName;
        private string _customerEmail;
        private string _customerPhone;       
        private string _customerAddress;

        /// <summary>
        /// Date when the order was placed
        /// </summary>
        public DateTime OrderDate 
        { 
            get => _orderDate; 
            private set => _orderDate = value;
        }

        /// <summary>
        /// List of products in the order
        /// </summary>
        public Guid ProductID
        { 
            get => _productId; 
            private set => _productId = value;
        }

        /// <summary>
        /// Total amount for the order
        /// </summary>
        public decimal TotalAmount 
        { 
            get => _totalAmount;   
            private set => _totalAmount = value; 
        }

        /// <summary>
        /// Name of the customer who placed the order
        /// </summary>
        public string CustomerName 
        { 
            get => _customerName; 
            private set => _customerName = value; 
        }

        /// <summary>
        /// Email of the customer who placed the order
        /// </summary>
        public string CustomerEmail
        { 
            get => _customerEmail;  
            private set => _customerEmail = value;
        }

        /// <summary>
        /// Phone number of the customer who placed the order
        /// </summary>
        public string CustomerPhone
        { 
            get => _customerPhone; 
            private set => _customerPhone = value; 
        }

        /// <summary>
        /// Address of the customer who placed the order
        /// </summary>
        public string CustomerAddress 
        { 
            get => _customerAddress;
            private set => _customerAddress = value;
        }
       
        /// <summary>
        /// Sets the order date.
        /// </summary>
        /// <param name="orderDate"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetOrderDate(DateTime orderDate)
        {
            _orderDate = (orderDate == default) ? throw new ArgumentNullException("Order date was not provided.")
                                                : orderDate;
        }

        /// <summary>
        /// Sets the list of products in the order.
        /// </summary>
        /// <param name="product"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetProducts(Guid product)
        {
            _productId = (product == default)
                ? throw new ArgumentNullException("Product was not provided.")
                : product;
        }

        /// <summary>
        /// Sets the total amount for the order. Throws an exception if the amount is negative.
        /// </summary>
        /// <param name="totalAmount"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetTotalAmount(decimal totalAmount)
        {
            _totalAmount = (totalAmount < 0) ? throw new ArgumentOutOfRangeException("Total amount cannot be negative.")
                                              : totalAmount;
        }

        /// <summary>
        /// Sets the name of the customer who placed the order. Throws an exception if the name is null or empty.
        /// </summary>
        /// <param name="customerName"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetCustomerName(string customerName)
        {
            _customerName = string.IsNullOrEmpty(customerName) ? throw new ArgumentNullException("Customer name was not provided.")
                                                               : customerName;
        }

        /// <summary>
        /// Sets the email of the customer who placed the order. Throws an exception if the email is null or empty.
        /// </summary>
        /// <param name="customerEmail"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetCustomerEmail(string customerEmail)
        {
            _customerEmail = string.IsNullOrEmpty(customerEmail) ? throw new ArgumentNullException("Customer email was not provided.")
                                                                : customerEmail;
        }

        /// <summary>
        /// Sets the phone number of the customer who placed the order. Throws an exception if the phone number is null or empty.
        /// </summary>
        /// <param name="customerPhone"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetCustomerPhone(string customerPhone)
        {
            _customerPhone = string.IsNullOrEmpty(customerPhone) ? throw new ArgumentNullException("Customer phone was not provided.")
                                                                : customerPhone;
        }

        /// <summary>
        /// Sets the address of the customer who placed the order. Throws an exception if the address is null or empty.
        /// </summary>
        /// <param name="customerAddress"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetCustomerAddress(string customerAddress)
        {
            _customerAddress = string.IsNullOrEmpty(customerAddress) ? throw new ArgumentNullException("Customer address was not provided.")
                                                                    : customerAddress;
        }
    }
}
