using backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
  private readonly ApplicationDbContext db;
  private readonly ILogger<HealthController> logger;

  public HealthController(ApplicationDbContext db, ILogger<HealthController> logger)
  {
    this.db = db;
    this.logger = logger;
  }

  [HttpGet]
  [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
  public async Task<IActionResult> Get(CancellationToken cancellationToken)
  {
    var canConnect = await db.Database.CanConnectAsync(cancellationToken);
    logger.LogInformation("Health check requested. DB connectivity: {CanConnect}", canConnect);

    return Ok(new
    {
      status = "ok",
      environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Unknown",
      database = new { connected = canConnect }
    });
  }
}
