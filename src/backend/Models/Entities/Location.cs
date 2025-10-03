namespace backend.Models.Entities;

public class Location : BaseAuditableEntity
{
  public long Id { get; set; }
  public string City { get; set; } = string.Empty;
  public string? State { get; set; }
  public string Country { get; set; } = string.Empty;

  public ICollection<Company> Companies { get; set; } = new List<Company>();
}
