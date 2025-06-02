using Common;

namespace Core.Services.Product
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class UpdateProductService : IUpdateProductService
    {
        public void Update(BusinessEntities.Product product, string name, string description, decimal price, int stockQuantity)
        {
            product.SetName(name);
            product.SetDescription(description);
            product.SetPrice(price);
            product.SetStockQuantity(stockQuantity);
        }
    }
}
