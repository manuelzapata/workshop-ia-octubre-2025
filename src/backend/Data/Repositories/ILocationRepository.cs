using backend.Models.Entities;

namespace backend.Data.Repositories;

public interface ILocationRepository
{
  Task<List<Location>> GetAllAsync(CancellationToken cancellationToken = default);
}
