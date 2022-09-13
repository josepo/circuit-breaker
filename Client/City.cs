namespace Client;

public class City
{
   public int Id { get; set; }
   public string Name { get; set; } = "";

   public WeatherForecast? WeatherForecast { get; set; }

   public override string ToString()
   {
      var forecast =
         WeatherForecast != null ? $"{WeatherForecast}" : "";

      return $"{Name} {forecast}";
   }
}