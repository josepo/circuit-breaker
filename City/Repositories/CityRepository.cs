using LanguageExt;
using Polly.CircuitBreaker;

namespace CityApp;

public interface ICityRepository
{
   Task<Option<City>> Get(string name);
}

public class CityRepository : ICityRepository
{
   private readonly IWeatherHttpClient _weatherClient;

   private readonly List<City> _cities = new List<City>
   {
      new City { Id = 4, Name = "Granada" },
      new City { Id = 7, Name = "Madrid" }
   };

   public CityRepository(IWeatherHttpClient weatherClient)
   {
      _weatherClient = weatherClient;
   }

   public async Task<Option<City>> Get(string name)
   {
      var city =
         _cities.FirstOrDefault(c => c.Name.ToLower() == name.ToLower());

      if (city == null)
         return Option<City>.None;

      try
      {
         var response = await _weatherClient.Get(name);

         if (response.IsSuccessStatusCode)
            city.WeatherForecast = await ReadForecast(response.Content);
      }
      catch (BrokenCircuitException) { }

      return city;
   }

   private async Task<WeatherForecast> ReadForecast(HttpContent content)
   {
      var forecast = await content.ReadFromJsonAsync<WeatherForecast>();

      return forecast ?? new WeatherForecast();
   }
}