using System.Linq;
using BusinessEntities;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;

namespace Data.Indexes
{
    public class OrdersListIndex : AbstractIndexCreationTask<Order>
    {
        public OrdersListIndex()
        {
            Map = orders => from order in orders
                            select new
                            {
                                order.OrderDate,
                                order.ProductID,
                                order.TotalAmount,
                                order.CustomerName,
                                order.CustomerEmail, order.CustomerPhone,order.CustomerAddress
                            };

            Index(x => x.CustomerName, FieldIndexing.Analyzed);
            Index(x => x.CustomerEmail, FieldIndexing.NotAnalyzed);
            Index(x => x.CustomerPhone, FieldIndexing.NotAnalyzed);
            Index(x => x.CustomerAddress, FieldIndexing.Analyzed);
            Index(x => x.ProductID, FieldIndexing.NotAnalyzed);
            Index(x => x.OrderDate, FieldIndexing.NotAnalyzed);
            Index(x => x.TotalAmount, FieldIndexing.NotAnalyzed);
        }
    }
}
