namespace backend.Models.Entities;

public class Industry : BaseAuditableEntity
{
  public long Id { get; set; }
  public string Name { get; set; } = string.Empty;

  public ICollection<Company> Companies { get; set; } = new List<Company>();
}
