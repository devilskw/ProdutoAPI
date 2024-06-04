
namespace Core.Domain.Usecase.Product;

using Core.Domain.Entity.Product;

public class ProductUseCase: IProductUseCase
{
  private IProductGateway _productGateway;

  public ProductUseCase(IProductGateway productGateway)
  {
    this._productGateway = productGateway;
  }

    public Product CreateProduct(Product product)
    {
      return this._productGateway.CreateNewProduct(product);
    }

    public Product FindProduct(long id)
    {
      return this._productGateway.FindProductById(id);
    }

    public Product UpdateProduct(Product product)
    {
      return this._productGateway.UpdateProduct(product);
    }

    public void DeleteProduct(long id)
    {
      this._productGateway.DeleteProduct(id);
    }
}