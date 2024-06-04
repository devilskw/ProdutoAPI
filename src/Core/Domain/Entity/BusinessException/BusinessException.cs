namespace Core.Domain.Entity.BusinessException;

public class BusinessException : Exception
{
  public BusinessCategoryException category { get; set; }
  public Object[] args { get; set; }

  public BusinessException(string message, BusinessCategoryException category, Object[] args) : base(message)
  {
    this.category = category;
    this.args = args;
  }
}