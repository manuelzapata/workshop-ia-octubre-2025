using backend.Models.DTOs;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompaniesController : ControllerBase
{
  private readonly ICompanyService service;
  private readonly ILogger<CompaniesController> logger;

  public CompaniesController(ICompanyService service, ILogger<CompaniesController> logger)
  {
    this.service = service;
    this.logger = logger;
  }

  [HttpGet]
  [ProducesResponseType(typeof(List<CompanyDto>), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  public async Task<IActionResult> Get([FromQuery] long? industry, [FromQuery] long? location, CancellationToken cancellationToken)
  {
    if (industry.HasValue && industry.Value <= 0)
    {
      return BadRequest("industry must be a positive id");
    }
    if (location.HasValue && location.Value <= 0)
    {
      return BadRequest("location must be a positive id");
    }

    try
    {
      if (!industry.HasValue && !location.HasValue)
      {
        var all = await service.GetAllAsync(cancellationToken);
        return Ok(all);
      }
      else
      {
        var filtered = await service.GetFilteredAsync(industry, location, cancellationToken);
        return Ok(filtered);
      }
    }
    catch (Exception ex)
    {
      logger.LogError(ex, "Error getting companies list");
      return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
    }
  }
}
