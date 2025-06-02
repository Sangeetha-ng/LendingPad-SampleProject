using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities;
using Core.Services.Product;
using WebApi.Models.Products;
using WebApi.Models.Users;

namespace WebApi.Controllers
{
    [RoutePrefix("products")]
    public class ProductController : BaseApiController
    {
        private readonly ICreateProductService _createProductService;
        private readonly IDeleteProductService _deleteProductService;
        private readonly IGetProductService _getProductService;
        private readonly IUpdateProductService _updateProductService;

        public ProductController(
            ICreateProductService createProductService,
            IDeleteProductService deleteProductService,
            IGetProductService getProductService,
            IUpdateProductService updateProductService)
        {
            _createProductService = createProductService;
            _deleteProductService = deleteProductService;
            _getProductService = getProductService;
            _updateProductService = updateProductService;
        }

        [Route("{productId:guid}/create")]
        [HttpPost]
        public HttpResponseMessage CreateProduct(Guid productId, [FromBody] ProductModel model)
        {
            var product = _getProductService.GetProduct(productId);
            if (product != null)
            {
                return Conflict();
            }
            var newproduct = _createProductService.Create(productId, model.Name, model.Description, model.Price, model.StockQuantity);
            return Found(new ProductData(newproduct));
        }

        [Route("{productId:guid}/update")]
        [HttpPut]
        public HttpResponseMessage UpdateProduct(Guid productId, [FromBody] ProductModel model)
        {
            var product = _getProductService.GetProduct(productId);
            if (product == null)
            {
                return DoesNotExist();
            }
            _updateProductService.Update(product, model.Name, model.Description, model.Price, model.StockQuantity);
            return Found(new ProductData(product));
        }

        [Route("{productId:guid}/delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteProduct(Guid productId)
        {
            var product = _getProductService.GetProduct(productId);
            if (product == null)
            {
                return DoesNotExist();
            }
            _deleteProductService.Delete(product);
            return Found();
        }

        [Route("{productId:guid}")]
        [HttpGet]
        public HttpResponseMessage GetProduct(Guid productId)
        {
            var product = _getProductService.GetProduct(productId);
            return Found(new ProductData(product));
        }

        [Route("list")]
        [HttpGet]
        public HttpResponseMessage GetProducts(int skip,
        int take, string name = null, string description = null,
        decimal? minPrice = null,
        decimal? maxPrice = null,
        int? minStockQuantity = null,
        int? maxStockQuantity = null)        
        {
            var products = _getProductService.GetProducts(name, description, minPrice, maxPrice, minStockQuantity, maxStockQuantity)
                .Skip(skip).Take(take)
                .Select(p => new ProductData(p))
                .ToList();
            return Found(products);
        }

        [Route("clear")]
        [HttpDelete]
        public HttpResponseMessage DeleteAllProducts()
        {
            _deleteProductService.DeleteAll();
            return Found();
        }
    }
}
