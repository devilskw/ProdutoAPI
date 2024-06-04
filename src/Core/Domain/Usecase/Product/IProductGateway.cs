namespace Core.Domain.Usecase.Product;

using Core.Domain.Entity.Product;

public interface IProductGateway
{
    Product CreateNewProduct(Product product);
    Product FindProductById(long id);
    Product UpdateProduct(Product product);
    void DeleteProduct(long id);
}