using LanguageExt;

namespace CityApp;

public interface ICityRepository
{
   Task<Option<City>> Get(string name);
}

public class CityRepository : ICityRepository
{
   public Task<Option<City>> Get(string name)
   {
      var city = Option<City>.Some(new City());

      return Task.FromResult(city);
   }
}