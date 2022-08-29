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
   }
}