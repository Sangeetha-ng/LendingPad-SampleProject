using System;

namespace BusinessEntities
{
    public class Product : IdObject
    {
        private string _name;
        private string _description;        
        private decimal _price;
        private int _stockQuantity;

        /// <summary>
        /// Name of the product
        /// </summary>
        public string Name
        {
            get => _name;
            private set => _name = value;
        }

        /// <summary>
        /// Description of the product
        /// </summary>
        public string Description
        {
            get => _description;
            private set => _description = value;
        }

        /// <summary>
        /// Price of the product
        /// </summary>
        public decimal Price
        {
            get => _price;
            private set => _price = value;
        }

        /// <summary>
        /// Available stock
        /// </summary>
        public int StockQuantity
        {
            get => _stockQuantity;
            private set => _stockQuantity = value;
        }

        /// <summary>
        /// Sets the name of the product. Throws an exception if the name is null or empty.
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetName(string name)
        {
            _name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException("Name was not provided.")
                                               : name;
        }

        /// <summary>
        /// Sets the description of the product. Throws an exception if the description is null or empty.
        /// </summary>
        /// <param name="description"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetDescription(string description)
        {
            _description = string.IsNullOrEmpty(description) ? throw new ArgumentNullException("Description was not provided.")
                                               : description;
        }

        /// <summary>
        /// Sets the price of the product. Throws an exception if the price is negative.
        /// </summary>
        /// <param name="price"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetPrice(decimal price)
        {
            _price = (price < 0) ? throw new ArgumentOutOfRangeException(nameof(price), "Price cannot be negative.")
                                 : price;
        }

        /// <summary>
        /// Sets the available stock quantity. Throws an exception if the quantity is negative.
        /// </summary>
        /// <param name="quantity"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetStockQuantity(int quantity)
        {
            _stockQuantity = (quantity < 0) ? throw new ArgumentOutOfRangeException(nameof(quantity), "Stock quantity cannot be negative.")
                                            : quantity;
        }
    }
}
