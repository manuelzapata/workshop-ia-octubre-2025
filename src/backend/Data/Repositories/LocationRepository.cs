using backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Data.Repositories;

public class LocationRepository : ILocationRepository
{
  private readonly ApplicationDbContext context;

  public LocationRepository(ApplicationDbContext context)
  {
    this.context = context;
  }

  public Task<List<Location>> GetAllAsync(CancellationToken cancellationToken = default) =>
      context.Locations
          .AsNoTracking()
          .OrderBy(l => l.Country).ThenBy(l => l.State).ThenBy(l => l.City)
          .ToListAsync(cancellationToken);
}
