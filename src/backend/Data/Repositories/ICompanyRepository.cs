using backend.Models.Entities;

namespace backend.Data.Repositories;

public interface ICompanyRepository
{
  Task<List<Company>> GetAllAsync(CancellationToken cancellationToken = default);
  Task<List<Company>> GetFilteredAsync(long? industryId, long? locationId, CancellationToken cancellationToken = default);
}
