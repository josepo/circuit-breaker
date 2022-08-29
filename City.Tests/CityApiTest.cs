using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace CityApp;

public class CityApiTest : IClassFixture<WebApplicationFactory<Program>>
{
   private readonly HttpClient _client;

   public CityApiTest(WebApplicationFactory<Program> factory)
   {
      _client = factory.CreateClient();
   }

   [Fact]
   public async Task GetByName()
   {
      var response = await _client.GetAsync("city/granada");
      response.EnsureSuccessStatusCode();

      var city = await response.Content.ReadFromJsonAsync<City>();

      city?.Name.Should().Be("Granada");
   }
}