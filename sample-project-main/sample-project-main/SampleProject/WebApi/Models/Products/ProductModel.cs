using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Products
{
    public class ProductModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        public int StockQuantity { get; set; }
    }
}
