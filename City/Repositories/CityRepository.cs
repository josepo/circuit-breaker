using LanguageExt;

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
      new City { Id = 7, Name = "Zaragoza" }
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

      var response = await _weatherClient.Get(name);

      if (response.IsSuccessStatusCode)
         city.WeatherForecast = await response.Content.ReadFromJsonAsync<WeatherForecast>();

      return city;
   }
}