using Npgsql;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
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

			builder.Services.AddScoped<IPublicRepository, PublicRepository>(serviceProvider
				=> new PublicRepository(new NpgsqlConnection(builder.Configuration["ConnectionStrings:DefaultConnection"])));

			WebApplication app = builder.Build();

			app.UseRouting();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

#pragma warning disable ASP0014
			app.UseEndpoints(endpoints =>
			{
				using (IServiceScope scope = endpoints.ServiceProvider.CreateScope())
				{
					IPublicRepository publicRepository = scope.ServiceProvider.GetRequiredService<IPublicRepository>();

					Map_SELECT_Entire<Auditoriums>(endpoints, "/auditoriums", publicRepository.GetAuditoriumsAsync);
					Map_SELECT_Entire<Showtimes>(endpoints, "/showtimes", publicRepository.GetShowtimesAsync);
					Map_SELECT_Entire<Users>(endpoints, "/users", publicRepository.GetUsersAsync);
					Map_SELECT_Entire<Seats>(endpoints, "/seats", publicRepository.GetSeatsAsync);
					Map_SELECT_Entire<Menus>(endpoints, "/menus", publicRepository.GetMenusAsync);
					Map_SELECT_Entire<Movies>(endpoints, "/movies", publicRepository.GetMoviesAsync);
					Map_SELECT_Entire<Orders>(endpoints, "/orders", publicRepository.GetOrdersAsync);
					Map_SELECT_Entire<Cinemas>(endpoints, "/cinemas", publicRepository.GetCinemasAsync);
					Map_SELECT_Entire<Tickets>(endpoints, "/tickets", publicRepository.GetTicketsAsync);
					Map_SELECT_Entire<Reservations>(endpoints, "/reservations", publicRepository.GetReservationsAsync);
					Map_SELECT_Entire<FoodAndDrinks>(endpoints, "/food-and-drinks", publicRepository.GetFoodAndDrinksAsync);

					Map_SELECT_ByMatchingProperties<Auditoriums>(endpoints, "/auditoriums", publicRepository.GetAuditoriumsAsync);
					Map_SELECT_ByMatchingProperties<Showtimes>(endpoints, "/showtimes", publicRepository.GetShowtimesAsync);
					Map_SELECT_ByMatchingProperties<Users>(endpoints, "/users", publicRepository.GetUsersAsync);
					Map_SELECT_ByMatchingProperties<Seats>(endpoints, "/seats", publicRepository.GetSeatsAsync);
					Map_SELECT_ByMatchingProperties<Menus>(endpoints, "/menus", publicRepository.GetMenusAsync);
					Map_SELECT_ByMatchingProperties<Movies>(endpoints, "/movies", publicRepository.GetMoviesAsync);
					Map_SELECT_ByMatchingProperties<Orders>(endpoints, "/orders", publicRepository.GetOrdersAsync);
					Map_SELECT_ByMatchingProperties<Cinemas>(endpoints, "/cinemas", publicRepository.GetCinemasAsync);
					Map_SELECT_ByMatchingProperties<Tickets>(endpoints, "/tickets", publicRepository.GetTicketsAsync);
					Map_SELECT_ByMatchingProperties<Reservations>(endpoints, "/reservations", publicRepository.GetReservationsAsync);
					Map_SELECT_ByMatchingProperties<FoodAndDrinks>(endpoints, "/food-and-drinks", publicRepository.GetFoodAndDrinksAsync);
				}
			});
#pragma warning restore ASP0014

			app.Run();
		}

		public static void Map_SELECT_Entire<T>
		(IEndpointRouteBuilder endpoints, string pattern, Func<int, int, Task<IEnumerable<T>>> SELECT_EntireDataMethod)
		{
			endpoints.MapGet($"/entire{pattern}", async (
			[FromQuery(Name = "page-size")] int pageSize, [FromQuery(Name = "page-number")] int pageNumber) =>
			      await SELECT_EntireDataMethod(pageSize, pageNumber))
			.WithOpenApi()
			.WithName($"SELECT_Entire{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(pattern.Remove(startIndex: 0, count: 1))}");
		}

		public static void Map_SELECT_ByMatchingProperties<T>
		(IEndpointRouteBuilder endpoints, string pattern, Func<T, Task<T?>> SELECT_ByMatchingPropertiesDataMethod)
		{
			endpoints.MapPost($"/matching-properties{pattern}", async (T entity) => await SELECT_ByMatchingPropertiesDataMethod(entity))
			.WithOpenApi().WithName($"SELECT_ByMatchingProperties{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(pattern.Remove(startIndex: 0, count: 1))}");
		}

		public static Func<int, int, Task<IEnumerable<IEntity>>> ToGenericAsync<T>
		             (Func<int, int, Task<IEnumerable<T>>> getDataMethod) where T : IEntity =>
		   async (int pageSize, int pageNumber) => (IEnumerable<IEntity>) await getDataMethod(pageSize, pageNumber);
	}
}

//ensure ? for types (warnings)
//ensure bracket "(" , ")"
//ensure not empty where clause
//ensure order by primary key(s)