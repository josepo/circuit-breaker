namespace Client;

public class WeatherForecast
{
   public int Temperature { get; set; }
   public int ChanceOfRain { get; set; }

   public override string ToString()
   {
      return $"{Temperature}°C, {ChanceOfRain}% of rain";
   }
}