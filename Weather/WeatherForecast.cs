namespace Weather;

public class WeatherForecast
{
   public int Temperature { get; private set; }

   public int ChanceOfRain { get; private set; }

   public WeatherForecast()
   {
      var random = new Random();

      Temperature = random.Next(-20, 45);
      ChanceOfRain = random.Next(0, 100);
   }
}
