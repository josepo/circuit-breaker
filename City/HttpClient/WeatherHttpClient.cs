namespace CityApp;

public interface IWeatherHttpClient
{
   Task<HttpResponseMessage> Get(string cityName);
}

public class WeatherHttpClient : IWeatherHttpClient
{
   private readonly HttpClient _httpClient;

   public WeatherHttpClient(HttpClient httpClient)
   {
      _httpClient = httpClient;
   }

   public async Task<HttpResponseMessage> Get(string cityName)
   {
      return await _httpClient.GetAsync($"weather/{cityName}");
   }
}