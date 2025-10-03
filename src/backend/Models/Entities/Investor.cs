namespace backend.Models.Entities;

public class Investor : BaseAuditableEntity
{
  public long Id { get; set; }
  public string Name { get; set; } = string.Empty;

  public ICollection<CompanyInvestor> CompanyInvestments { get; set; } = new List<CompanyInvestor>();
}
