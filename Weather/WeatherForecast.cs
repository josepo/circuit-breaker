namespace Weather;

public class WeatherForecast
{
   public double Temperature { get; private set; }

   public double ChanceOfRain { get; private set; }

   private WeatherForecast(double temperature, double chanceOfRain)
   {
      Temperature = temperature;
      ChanceOfRain = chanceOfRain;
   }

   public static WeatherForecast Random()
   {
      return new WeatherForecast(0, 0);
   }
}
