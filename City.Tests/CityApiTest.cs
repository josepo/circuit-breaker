using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace CityApp;

public class CityApiTest : IClassFixture<WebApplicationFactory<Program>>, IDisposable
{
   private readonly HttpClient _client;
   private readonly WireMockServer _server;

   public CityApiTest(WebApplicationFactory<Program> factory)
   {
      _client = factory.CreateClient();
      _server = WireMockServer.Start(5216);
   }

   public void Dispose()
   {
      _server.Stop();
   }

   [Fact]
   public async Task GetByName()
   {
      _server
         .Given(
            Request
            .Create()
            .WithPath("/api/weather/granada").UsingGet())
         .RespondWith(
            Response
            .Create()
            .WithStatusCode(200)
            .WithBodyAsJson(new WeatherForecast
            {
               Temperature = 25,
               ChanceOfRain = 10
            }));

      var response = await _client.GetAsync("api/city/granada");
      response.EnsureSuccessStatusCode();

      var city = await response.Content.ReadFromJsonAsync<City>();

      city?.Name.Should().Be("Granada");

      var forecast = city?.WeatherForecast;

      forecast.Should().NotBeNull();

      forecast?.Temperature.Should().Be(25);
      forecast?.ChanceOfRain.Should().Be(10);
   }
}