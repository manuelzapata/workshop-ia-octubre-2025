using backend.Models.DTOs;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationsController : ControllerBase
{
  private readonly ILocationService service;

  public LocationsController(ILocationService service)
  {
    this.service = service;
  }

  [HttpGet]
  [ProducesResponseType(typeof(List<LocationDto>), StatusCodes.Status200OK)]
  public async Task<IActionResult> Get(CancellationToken cancellationToken)
  {
    var data = await service.GetAllAsync(cancellationToken);
    return Ok(data);
  }
}
