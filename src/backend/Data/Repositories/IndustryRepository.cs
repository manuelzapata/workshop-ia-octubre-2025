using backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Data.Repositories;

public class IndustryRepository : IIndustryRepository
{
  private readonly ApplicationDbContext context;

  public IndustryRepository(ApplicationDbContext context)
  {
    this.context = context;
  }

  public Task<List<Industry>> GetAllAsync(CancellationToken cancellationToken = default) =>
      context.Industries
          .AsNoTracking()
          .OrderBy(i => i.Name)
          .ToListAsync(cancellationToken);
}
