using backend.Models.Entities;

namespace backend.Data.Repositories;

public interface IIndustryRepository
{
  Task<List<Industry>> GetAllAsync(CancellationToken cancellationToken = default);
}
