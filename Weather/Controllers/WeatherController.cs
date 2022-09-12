using Microsoft.AspNetCore.Mvc;

namespace Weather.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
   [HttpGet("{cityName}")]
   public ActionResult<WeatherForecast> Get([FromRoute] string cityName)
   {
      Thread.Sleep(TimeSpan.FromMinutes(2));

      return Ok(new WeatherForecast());
   }
}
