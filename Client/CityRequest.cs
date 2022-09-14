using System.Net.Http.Json;

namespace Client;

public class CityRequest
{
   public Status Status { get; private set; }

   public double RunningTime { get; private set; }

   public City? Response { get; private set; }

   private readonly HttpClient _httpClient;

   public CityRequest(HttpClient httpClient)
   {
      Status = Status.NotStarted;
      RunningTime = 0;

      _httpClient = httpClient;
   }

   public async Task Run()
   {
      var start = DateTime.Now;

      try
      {
         var response = await _httpClient.GetAsync("city/madrid");

         Status = Status.Success;
         Response = await response.Content.ReadFromJsonAsync<City>();
      }
      catch (Exception)
      {
         Status = Status.Fail;
      }
      finally
      {
         RunningTime = Math.Round((DateTime.Now - start).TotalMilliseconds);
      }
   }

   public override string ToString()
   {
      return $"{Status} ({RunningTime}ms) {Response}";
   }
}
