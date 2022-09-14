namespace CityApp;

public class City
{
   public int Id { get; set; }
   public string Name { get; set; } = "";
   public string Population { get; set; } = "";

   public WeatherForecast? WeatherForecast { get; set; }
}