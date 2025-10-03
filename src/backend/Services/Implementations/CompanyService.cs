using backend.Data.Repositories;
using backend.Models.DTOs;
using Microsoft.Extensions.Logging;
using backend.Services.Interfaces;

namespace backend.Services.Implementations;

public class CompanyService : ICompanyService
{
  private readonly ICompanyRepository repository;
  private readonly ILogger<CompanyService> logger;

  public CompanyService(ICompanyRepository repository, ILogger<CompanyService> logger)
  {
    this.repository = repository;
    this.logger = logger;
  }

  public async Task<List<CompanyDto>> GetAllAsync(CancellationToken cancellationToken = default)
  {
    var companies = await repository.GetAllAsync(cancellationToken);
    return companies.Select(MapToDto).ToList();
  }

  public async Task<List<CompanyDto>> GetFilteredAsync(long? industryId, long? locationId, CancellationToken cancellationToken = default)
  {
    if (industryId.HasValue)
    {
      logger.LogInformation("Filtering companies by IndustryId={IndustryId}", industryId);
    }
    if (locationId.HasValue)
    {
      logger.LogInformation("Filtering companies by LocationId={LocationId}", locationId);
    }

    var companies = await repository.GetFilteredAsync(industryId, locationId, cancellationToken);
    return companies.Select(MapToDto).ToList();
  }

  private static CompanyDto MapToDto(backend.Models.Entities.Company c) => new()
  {
    Id = c.Id,
    Name = c.Name,
    Products = c.Products,
    FoundingYear = c.FoundingYear,
    TotalFunding = c.TotalFunding,
    Arr = c.Arr,
    Valuation = c.Valuation,
    Employees = c.Employees,
    G2Rating = c.G2Rating,
    IndustryId = c.IndustryId,
    IndustryName = c.Industry?.Name,
    LocationId = c.LocationId,
    LocationDisplayName = c.Location is null
          ? null
          : string.IsNullOrWhiteSpace(c.Location.State)
              ? $"{c.Location.City}, {c.Location.Country}"
              : $"{c.Location.City}, {c.Location.State}, {c.Location.Country}"
  };
}
