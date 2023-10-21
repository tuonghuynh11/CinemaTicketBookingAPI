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
				IEnumerable<Auditoriums> auditoriums = await httpContext.RequestServices.GetRequiredService<IPublicRepository>().GetAuditoriumsAsync();
				IEnumerable<Cinemas> cinemas = await httpContext.RequestServices.GetRequiredService<IPublicRepository>().GetCinemasAsync();
				IEnumerable<FoodAndDrinks> foodAndDrinks = await httpContext.RequestServices.GetRequiredService<IPublicRepository>().GetFoodAndDrinksAsync();
				IEnumerable<Menus> menus = await httpContext.RequestServices.GetRequiredService<IPublicRepository>().GetMenusAsync();
				IEnumerable<Orders> orders = await httpContext.RequestServices.GetRequiredService<IPublicRepository>().GetOrdersAsync();
				IEnumerable<Reservations> reservations = await httpContext.RequestServices.GetRequiredService<IPublicRepository>().GetReservationsAsync();
				IEnumerable<Seats> seats = await httpContext.RequestServices.GetRequiredService<IPublicRepository>().GetSeatsAsync();
				IEnumerable<Showtimes> showtimes = await httpContext.RequestServices.GetRequiredService<IPublicRepository>().GetShowtimesAsync();
				IEnumerable<Tickets> tickets = await httpContext.RequestServices.GetRequiredService<IPublicRepository>().GetTicketsAsync();
				IEnumerable<Users> users = await httpContext.RequestServices.GetRequiredService<IPublicRepository>().GetUsersAsync();

				Auditoriums? auditoriums1 = await httpContext.RequestServices.GetRequiredService<IPublicRepository>().GetAuditoriumsAsync(new(51));

				return auditoriums1?.Name ?? "Unknown";

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

//ensure ? for types (warnings)
//ensure bracket "(" , ")"
//ensure not empty where clause
//ensure order by primary key(s)