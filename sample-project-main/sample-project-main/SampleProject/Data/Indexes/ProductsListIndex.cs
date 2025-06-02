using System.Linq;
using BusinessEntities;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;

namespace Data.Indexes
{
    public class ProductsListIndex : AbstractIndexCreationTask<Product>
    {
        public ProductsListIndex()
        {
            Map = products => from product in products
                              select new
                              {
                                  product.Name,
                                  product.Description,
                                  product.Price,
                                  product.StockQuantity
                              };

            Index(x => x.Name, FieldIndexing.Analyzed);
            Index(x => x.Description, FieldIndexing.Analyzed);
            Index(x => x.Price, FieldIndexing.NotAnalyzed);
            Index(x => x.StockQuantity, FieldIndexing.NotAnalyzed);
        }
    }
}
