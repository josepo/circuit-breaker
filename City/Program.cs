using CityApp;
using Polly;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICityRepository, CityRepository>();

builder.Services
   .AddHttpClient<IWeatherHttpClient, WeatherHttpClient>(options =>
      options.BaseAddress = new Uri("http://localhost:5216/api/"))
   .AddPolicyHandler(
      Policy
         .Handle<TaskCanceledException>()
         .CircuitBreakerAsync(1, TimeSpan.FromMinutes(2))
         .AsAsyncPolicy<HttpResponseMessage>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
