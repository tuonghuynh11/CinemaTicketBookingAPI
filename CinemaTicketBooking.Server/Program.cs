using Npgsql;
using CinemaTicketBooking.Server.Scaffolds.Models.EntityLayer;
using CinemaTicketBooking.Server.Scaffolds.Models.DataLayer.Contracts;
using CinemaTicketBooking.Server.Scaffolds.Models.DataLayer.Repositories;

namespace CinemaTicketBooking.Server
{
	public class Program
	{
		public static void Main(string[] args)
		{
			WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddAuthorization();

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddScoped<IPublicRepository, PublicRepository>(serviceProvide
				=> new PublicRepository(new NpgsqlConnection(builder.Configuration["ConnectionStrings:DefaultConnection"])));

			WebApplication app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapGet("/weatherforecast", async (HttpContext httpContext) =>
			{
				IEnumerable<Movies> movies = await httpContext.RequestServices.GetRequiredService<IPublicRepository>().GetMoviesAsync();

				return movies.Count();

				//var forecast = Enumerable.Range(1, 5).Select(index =>
				//	new WeatherForecast
				//	{
				//		Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
				//		TemperatureC = Random.Shared.Next(-20, 55),
				//		Summary = summaries[Random.Shared.Next(summaries.Length)]
				//	})
				//	.ToArray();
				//return forecast;
			})
			.WithName("GetWeatherForecast")
			.WithOpenApi();

			app.Run();
		}
	}
}