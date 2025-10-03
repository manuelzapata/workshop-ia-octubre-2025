using backend.Models.DTOs;

namespace backend.Services.Interfaces;

public interface ICompanyService
{
  Task<List<CompanyDto>> GetAllAsync(CancellationToken cancellationToken = default);
  Task<List<CompanyDto>> GetFilteredAsync(long? industryId, long? locationId, CancellationToken cancellationToken = default);
}
