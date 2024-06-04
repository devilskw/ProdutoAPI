namespace Core.Domain.Entity.Product;
public class Product
{
  public long id { get; private set; }
  public string? name { get; private set; }

  public Product(long id, string name)
  {
    this.id = id;
    this.name = name;
  }
}
