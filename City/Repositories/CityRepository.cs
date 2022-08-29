using LanguageExt;

namespace CityApp;

public interface ICityRepository
{
   Task<Option<City>> Get(string name);
}

public class CityRepository : ICityRepository
{
   private readonly List<City> _cities = new List<City>
   {
      new City { Id = 4, Name = "Granada" },
      new City { Id = 7, Name = "Zaragoza" }
   };

   public Task<Option<City>> Get(string name)
   {
      var city =
         _cities.FirstOrDefault(c => c.Name.ToLower() == name.ToLower());

      var result = city == null
         ? Option<City>.None
         : Option<City>.Some(city);

      return Task.FromResult(result);
   }
}