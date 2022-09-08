namespace Client;

internal class Program
{
   private static async Task Main(string[] args)
   {
      var requests = new CityRequests(new HttpClient
      {
         BaseAddress = new Uri("http://localhost:5052/api/")
      });

      await requests.Run();

      Console.Write(requests);
   }
}