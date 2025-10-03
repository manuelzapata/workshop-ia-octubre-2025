using backend.Data.Repositories;
using backend.Models.DTOs;
using backend.Services.Interfaces;

namespace backend.Services.Implementations;

public class IndustryService : IIndustryService
{
  private readonly IIndustryRepository repository;

  public IndustryService(IIndustryRepository repository)
  {
    this.repository = repository;
  }

  public async Task<List<IndustryDto>> GetAllAsync(CancellationToken cancellationToken = default)
  {
    var industries = await repository.GetAllAsync(cancellationToken);
    return industries.Select(i => new IndustryDto { Id = i.Id, Name = i.Name }).ToList();
  }
}
