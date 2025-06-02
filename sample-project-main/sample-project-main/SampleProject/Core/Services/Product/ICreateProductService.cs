using System;
using BusinessEntities;


namespace Core.Services.Product
{
    public interface ICreateProductService
    {
        BusinessEntities.Product Create(Guid id, string name, string description, decimal price,
            int stockQuantity);
    }
}
