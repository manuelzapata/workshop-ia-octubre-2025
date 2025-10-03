using backend.Models.DTOs;

namespace backend.Services.Interfaces;

public interface IIndustryService
{
  Task<List<IndustryDto>> GetAllAsync(CancellationToken cancellationToken = default);
}
