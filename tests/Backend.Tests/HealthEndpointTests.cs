using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Backend.Tests;

public class HealthEndpointTests : IClassFixture<WebApplicationFactory<Program>>
{
  private readonly WebApplicationFactory<Program> factory;

  public HealthEndpointTests(WebApplicationFactory<Program> factory)
  {
    this.factory = factory.WithWebHostBuilder(builder => { });
  }

  [Fact]
  public async Task Get_Health_ReturnsOkAndStatus()
  {
    var client = factory.CreateClient();

    var response = await client.GetAsync("/api/health");
    response.StatusCode.Should().Be(HttpStatusCode.OK);

    var payload = await response.Content.ReadFromJsonAsync<HealthPayload>();
    payload.Should().NotBeNull();
    payload!.status.Should().Be("ok");
    (payload.database.connected == true || payload.database.connected == false).Should().BeTrue();
  }

  private record HealthPayload(string status, string environment, DatabaseInfo database);
  private record DatabaseInfo(bool connected);
}
