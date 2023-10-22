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

					List<(string pattern, Func<int, int, Task<IEnumerable<IEntity>>> getDataMethod)> groups
					= new()
					{
						("/auditoriums", ToGenericAsync<Auditoriums>(publicRepository.GetAuditoriumsAsync)),
						("/showtimes", ToGenericAsync<Showtimes>(publicRepository.GetShowtimesAsync)),
						("/users", ToGenericAsync<Users>(publicRepository.GetUsersAsync)),
						("/seats", ToGenericAsync<Seats>(publicRepository.GetSeatsAsync)),
						("/menus", ToGenericAsync<Menus>(publicRepository.GetMenusAsync)),
						("/movies", ToGenericAsync<Movies>(publicRepository.GetMoviesAsync)),
						("/orders", ToGenericAsync<Orders>(publicRepository.GetOrdersAsync)),
						("/cinemas", ToGenericAsync<Cinemas>(publicRepository.GetCinemasAsync)),
						("/tickets", ToGenericAsync<Tickets>(publicRepository.GetTicketsAsync)),
						("/reservations", ToGenericAsync<Reservations>(publicRepository.GetReservationsAsync)),
						("/food-and-drinks", ToGenericAsync<FoodAndDrinks>(publicRepository.GetFoodAndDrinksAsync)),
					};

					foreach ((string pattern, Func<int, int, Task<IEnumerable<IEntity>>> getDataMethod) in groups)
					{
						endpoints.MapGet(pattern, async (
						[FromQuery(Name = "page-size")] int? pageSize, [FromQuery(Name = "page-number")] int? pageNumber) =>
						{
							return await getDataMethod(pageSize ?? 10, pageNumber ?? 1);
						})
						.WithOpenApi()
						.WithName($"Get{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(pattern.Remove(startIndex: 0, count: 1))}");
					}
				}
			});
#pragma warning restore ASP0014

			app.Run();
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