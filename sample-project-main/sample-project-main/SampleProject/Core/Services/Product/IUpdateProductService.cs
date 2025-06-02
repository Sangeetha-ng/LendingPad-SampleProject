using BusinessEntities;

namespace Core.Services.Product
{
    public interface IUpdateProductService
    {
        void Update(BusinessEntities.Product product, string name, string description, decimal price, int stockQuantity);
    }
}
