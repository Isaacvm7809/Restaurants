using Restaurants.API.Services;
using Restaurants.Infrastructure.Extensions;
using Restaurants.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();



//Inject the DbContext through the Infrastructure layer
builder.Services.AddInfrastructure(builder.Configuration);


var app = builder.Build();


var scope = app.Services.CreateScope();
var services = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
await services.Seed();




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
