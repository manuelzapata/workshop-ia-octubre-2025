namespace backend.Models.Entities;

public class CompanyInvestor
{
  public long CompanyId { get; set; }
  public Company Company { get; set; } = default!;

  public long InvestorId { get; set; }
  public Investor Investor { get; set; } = default!;
}
