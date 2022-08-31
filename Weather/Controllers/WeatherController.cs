using Microsoft.AspNetCore.Mvc;

namespace Weather.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{

   [HttpGet("{cityName}")]
   public ActionResult<WeatherForecast> Get([FromRoute] string cityName)
   {
      return Ok(WeatherForecast.Random());
   }
}
