namespace backend.Models.DTOs;

public class CompanyDto
{
  public long Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public string? Products { get; set; }
  public int? FoundingYear { get; set; }
  public long? TotalFunding { get; set; }
  public long? Arr { get; set; }
  public long? Valuation { get; set; }
  public int? Employees { get; set; }
  public float? G2Rating { get; set; }

  public long? IndustryId { get; set; }
  public string? IndustryName { get; set; }

  public long? LocationId { get; set; }
  public string? LocationDisplayName { get; set; }
}
