using System;
using Common;
using Core.Factories;
using Core.Services.Product;
using Data.Repositories;

namespace Core.Services.Products
{
    [AutoRegister]
    public class CreateProductService : ICreateProductService
    {
        private readonly IUpdateProductService _updateProductService;
        private readonly IIdObjectFactory<BusinessEntities.Product> _productFactory;
        private readonly IProductRepository _productRepository;
        public CreateProductService(IIdObjectFactory<BusinessEntities.Product> productFactory, IProductRepository productRepository
           , IUpdateProductService productUserService)
        {
            _productFactory = productFactory;
            _productRepository = productRepository;
            _updateProductService = productUserService;
        }
        public BusinessEntities.Product Create(Guid id, string name, string description, decimal price, int stockQuantity)
        {
            var product = _productFactory.Create(id);
            _updateProductService.Update(product, name, description, price, stockQuantity);
            _productRepository.Save(product);
            return product;
        }       
    }
}
