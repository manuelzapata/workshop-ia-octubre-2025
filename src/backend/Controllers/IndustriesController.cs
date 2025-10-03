using backend.Models.DTOs;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IndustriesController : ControllerBase
{
  private readonly IIndustryService service;

  public IndustriesController(IIndustryService service)
  {
    this.service = service;
  }

  [HttpGet]
  [ProducesResponseType(typeof(List<IndustryDto>), StatusCodes.Status200OK)]
  public async Task<IActionResult> Get(CancellationToken cancellationToken)
  {
    var data = await service.GetAllAsync(cancellationToken);
    return Ok(data);
  }
}
