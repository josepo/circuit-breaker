namespace Client;

public class CityRequests
{
   private readonly HttpClient _httpClient;

   private readonly CityRequest[] _requests;

   public CityRequests(HttpClient httpClient)
   {
      _httpClient = httpClient;

      _requests = new CityRequest[10]
      {
         new CityRequest(httpClient),
         new CityRequest(httpClient),
         new CityRequest(httpClient),
         new CityRequest(httpClient),
         new CityRequest(httpClient),
         new CityRequest(httpClient),
         new CityRequest(httpClient),
         new CityRequest(httpClient),
         new CityRequest(httpClient),
         new CityRequest(httpClient)
      };
   }

   public async Task Run()
   {
      foreach (var req in _requests)
      {
         Console.Write("Request started... ");

         await Task.Delay(2000);
         await req.Run();

         Console.WriteLine(req.ToString());
      }
   }

   public override string ToString()
   {
      var successes = _requests.Count(req => req.Status == Status.Success);
      var fails = _requests.Count(req => req.Status == Status.Fail);

      return
         $"\n{_requests.Count()} requests ({successes} successes, {fails} fails)" +
         $"\nwith an average running time of {AverageRunningTime()}ms \n\n";
   }

   private double AverageRunningTime()
   {
      return Math.Round(_requests.Sum(req => req.RunningTime) / 10);
   }
}