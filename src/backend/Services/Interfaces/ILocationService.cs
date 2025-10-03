using backend.Models.DTOs;

namespace backend.Services.Interfaces;

public interface ILocationService
{
  Task<List<LocationDto>> GetAllAsync(CancellationToken cancellationToken = default);
}
