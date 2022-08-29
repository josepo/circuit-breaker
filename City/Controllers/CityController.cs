using Microsoft.AspNetCore.Mvc;

namespace CityApp;

[ApiController]
[Route("[controller]")]
public class CityController : ControllerBase
{
   private readonly ICityRepository _cityRepository;

   public CityController(ICityRepository cityRepository)
   {
      _cityRepository = cityRepository;
   }

   [HttpGet("{name}")]
   public async Task<ActionResult> Get([FromRoute] string name)
   {
      var response = await _cityRepository.Get(name);

      if (response.IsNone)
         return NotFound();

      return Ok((City)response);
   }
}
