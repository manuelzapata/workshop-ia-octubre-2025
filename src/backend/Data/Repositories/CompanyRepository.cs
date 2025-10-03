using backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Data.Repositories;

public class CompanyRepository : ICompanyRepository
{
  private readonly ApplicationDbContext context;

  public CompanyRepository(ApplicationDbContext context)
  {
    this.context = context;
  }

  public Task<List<Company>> GetAllAsync(CancellationToken cancellationToken = default) =>
      context.Companies
          .Include(c => c.Industry)
          .Include(c => c.Location)
          .AsNoTracking()
          .ToListAsync(cancellationToken);

  public Task<List<Company>> GetFilteredAsync(long? industryId, long? locationId, CancellationToken cancellationToken = default)
  {
    IQueryable<Company> query = context.Companies
        .Include(c => c.Industry)
        .Include(c => c.Location)
        .AsNoTracking();

    if (industryId.HasValue)
    {
      query = query.Where(c => c.IndustryId == industryId);
    }

    if (locationId.HasValue)
    {
      query = query.Where(c => c.LocationId == locationId);
    }

    return query.ToListAsync(cancellationToken);
  }
}
