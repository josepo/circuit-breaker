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

   public Task Run()
   {
      return Task.WhenAll(_requests.Select(req => req.Run()));
   }

   public override string ToString()
   {
      return string.Join('\n',
         _requests.Select(req => req.ToString()).ToArray());
   }
}