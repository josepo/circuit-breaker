namespace Client;

public class CityRequest
{
   public Status Status { get; private set; }

   public double RunningTime { get; private set; }

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
         await _httpClient.GetAsync("city/zaragoza");

         Status = Status.Success;
      }
      catch (TaskCanceledException)
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
      return $"{Status} in {RunningTime}ms";
   }
}
