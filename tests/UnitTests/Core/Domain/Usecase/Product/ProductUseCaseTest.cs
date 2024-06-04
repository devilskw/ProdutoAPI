namespace Core.Domain.Usecase.Product;

using Moq;
using Xunit;
using Core.Domain.Entity.Product;
using Core.Domain.Entity.BusinessException;

public class ProductUseCaseTest
{
  private Mock<IProductGateway> _productGateway = new Mock<IProductGateway>();
  private ProductUseCase _productUseCase;

  public ProductUseCaseTest()
  {
    this._productUseCase = new ProductUseCase(this._productGateway.Object);
  }

  [Fact]
  public async Task TestCreateProduct_ReturningSuccessfullyANewProduct() {
    var productTestId = 1L;
    var productTestName = "testando 123";
    var product = new Product(productTestId, productTestName);
    this._productGateway.Setup(g => g.CreateNewProduct(product)).Returns(product);

    var result = await this._productUseCase.CreateProduct(product);

    Assert.NotNull(result);
    Assert.Equal(productTestId, result?.Id);
    Assert.Equal(productTestName, result?.Name);
  }

  [Fact]
  public async Task TestCreateProduct_ThrowsBusinessException_WhenProductCreationFails() {
    var productTestId = 1L;
    var productTestName = "testando 123";
    var productExceptionMessage = "Teste exceção ao tentar criar um novo produto";
    var product = new Product(productTestId, productTestName);
    this._productGateway.Setup(x => x.CreateNewProduct(product)).ThrowsAsync<BusinessException>(new BusinessException(productExceptionMessage, BusinessCategoryException.CLIENT_INVALID_PARAMETER_OR_DATA, [] ));

    Assert.ThrowsAsync<BusinessException>(() => this._productUseCase.CreateProduct(product));
  }

    [Fact]
  public async Task TestFindProduct_ReturningSuccessfullyAProduct() {
    var productTestId = 1L;
    var productTestName = "testando 123";
    var product = new Product(productTestId, productTestName);
    this._productGateway.Setup(g => g.FindProductById(productTestId)).Returns(product);

    var result = await this._productUseCase.FindProduct(productTestId);

    Assert.NotNull(result);
    Assert.Equal(productTestId, result?.Id);
    Assert.Equal(productTestName, result?.Name);
  }

  [Fact]
  public async Task TestFindProduct_ThrowsBusinessException_WhenProductDoesNotExists() {
    var productTestId = 1L;
    var productExceptionMessage = "Teste exceção ao tentar encontrar um produto e não localizar";
    this._productGateway.Setup(x => x.FindProductById(productTestId)).ThrowsAsync<BusinessException>(new BusinessException(productExceptionMessage, BusinessCategoryException.CLIENT_DATA_NOT_FOUND, [] ));

    Assert.ThrowsAsync<BusinessException>(() => this._productUseCase.FindProduct(productTestId));
  }

  [Fact]
  public async Task TestUpdateProduct_ReturningSuccessfullyProductUpdate() {
    var productTestId = 1L;
    var productTestName = "testando 123";
    var product = new Product(productTestId, productTestName);
    this._productGateway.Setup(g => g.UpdateProduct(product)).Returns(product);

    var result = await this._productUseCase.UpdateProduct(product);

    Assert.NotNull(result);
    Assert.Equal(productTestId, result?.Id);
    Assert.Equal(productTestName, result?.Name);
  }

  [Fact]
  public async Task TestUpdateProduct_ThrowsBusinessException_WhenProductDoesNotExists() {
    var productTestId = 1L;
    var productTestName = "testando 123";
    var productExceptionMessage = "Teste exceção ao tentar criar um novo produto";
    var product = new Product(productTestId, productTestName);
    this._productGateway.Setup(x => x.UpdateProduct(product)).ThrowsAsync<BusinessException>(new BusinessException(productExceptionMessage, BusinessCategoryException.CLIENT_INVALID_PARAMETER_OR_DATA, [] ));

    Assert.ThrowsAsync<BusinessException>(() => this._productUseCase.UpdateProduct(product));
  }

  [Fact]
  public async Task TestDeleteProduct_ReturningSuccessfullyAction() {
    var productTestId = 1L;
    this._productGateway.Setup(g => g.DeleteProduct(productTestId));

    var result = await this._productUseCase.DeleteProduct(productTestId);

    this._productGateway.Verify(global => global.DeleteProduct(productTestId), Times.Once());
  }

  [Fact]
  public async Task TestDeleteProduct_ThrowsBusinessException_WhenProductDeletionFails() {
    var productTestId = 1L;
    var productExceptionMessage = "Teste exceção durante a tentativa de deletar um produto";
    this._productGateway.Setup(x => x.DeleteProduct(productTestId)).ThrowsAsync<BusinessException>(new BusinessException(productExceptionMessage, BusinessCategoryException.INTERNAL, [] ));

    Assert.ThrowsAsync<BusinessException>(() => this._productUseCase.DeleteProduct(productTestId));
  }

}