namespace Core.Domain.Usecase.Product;

using Core.Domain.Entity.Product;

public interface IProductUseCase
{
    Product CreateProduct(Product product);
    Product FindProduct(long id);
    Product UpdateProduct(Product product);
    void DeleteProduct(long id);
}