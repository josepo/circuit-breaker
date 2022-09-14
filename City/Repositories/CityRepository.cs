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
      new City { Id = 4, Name = "Granada", Population = "300k" },
      new City { Id = 7, Name = "Madrid", Population = "3.2m" }
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

      city.WeatherForecast = await GetForecast(name);

      return city;
   }

   private async Task<WeatherForecast?> GetForecast(string name)
   {
      try
      {
         var response = await _weatherClient.Get(name);

         if (!response.IsSuccessStatusCode)
            return null;

         return await response.Content.ReadFromJsonAsync<WeatherForecast>();
      }
      catch (BrokenCircuitException)
      {
         return null;
      }
   }
}