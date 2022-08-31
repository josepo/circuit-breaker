namespace Weather;

public class WeatherForecast
{
   public int Temperature { get; private set; }

   public int ChanceOfRain { get; private set; }

   private WeatherForecast(int temperature, int chanceOfRain)
   {
      Temperature = temperature;
      ChanceOfRain = chanceOfRain;
   }

   public static WeatherForecast Random()
   {
      var random = new Random();

      return new WeatherForecast
      (
         random.Next(-20, 45),
         random.Next(0, 100)
      );
   }
}
