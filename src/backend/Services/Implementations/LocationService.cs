using backend.Data.Repositories;
using backend.Models.DTOs;
using backend.Services.Interfaces;

namespace backend.Services.Implementations;

public class LocationService : ILocationService
{
  private readonly ILocationRepository repository;

  public LocationService(ILocationRepository repository)
  {
    this.repository = repository;
  }

  public async Task<List<LocationDto>> GetAllAsync(CancellationToken cancellationToken = default)
  {
    var locations = await repository.GetAllAsync(cancellationToken);
    return locations.Select(l => new LocationDto
    {
      Id = l.Id,
      City = l.City,
      State = l.State,
      Country = l.Country
    }).ToList();
  }
}
