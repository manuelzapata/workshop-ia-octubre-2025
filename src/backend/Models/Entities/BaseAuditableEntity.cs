namespace backend.Models.Entities;

public abstract class BaseAuditableEntity
{
  public DateTimeOffset CreatedAt { get; set; }
  public string? CreatedBy { get; set; }
  public DateTimeOffset UpdatedAt { get; set; }
  public string? UpdatedBy { get; set; }
}
