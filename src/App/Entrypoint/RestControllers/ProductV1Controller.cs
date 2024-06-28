using Microsoft.AspNetCore.Mvc;

namespace Entrypoint.Controllers;

[ApiController]
[Route("[product/v1]")]
public class ProductV1Controller : ControllerBase
{
    private readonly ILogger<ProductV1Controller> _logger;

    public ProductV1Controller(ILogger<ProductV1Controller> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetProduct")]
    public IEnumerable<Product> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Product(index, $"Product {index}"))
        .ToArray();
    }
}
