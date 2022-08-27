using Microsoft.AspNetCore.Mvc;

namespace City.Controllers;

[ApiController]
[Route("[controller]")]
public class CityController : ControllerBase
{
   [HttpGet("{name}")]
   public ActionResult Get([FromRoute] string name)
   {
      return Ok();
   }
}
