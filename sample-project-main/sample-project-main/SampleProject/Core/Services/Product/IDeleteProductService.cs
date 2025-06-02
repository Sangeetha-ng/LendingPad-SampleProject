namespace Core.Services.Product
{
    public interface IDeleteProductService
    {
        void Delete(BusinessEntities.Product product);

        void DeleteAll();
    }
}
