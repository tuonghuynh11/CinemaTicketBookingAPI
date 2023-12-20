using Npgsql;
using System.Text.Json;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using CinemaTicketBooking.Server.Scaffolds.Models.EntityLayer;
using CinemaTicketBooking.Server.Scaffolds.Models.DataLayer.Contracts;
using CinemaTicketBooking.Server.Scaffolds.Models.DataLayer.Repositories;

namespace CinemaTicketBooking.Server
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

			if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")! != "Development")
			{
				string PORT = Environment.GetEnvironmentVariable("PORT")!;
				builder.WebHost.
						UseUrls($"http://0.0.0.0:{PORT}");
			}

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
			if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapGet("/", () => "Hello");

			app.MapGet("/showtimes/in-the-next-7-days/", async () =>
			{

			});

#pragma warning disable ASP0014
			app.UseEndpoints(endpoints =>
			{
				using (IServiceScope scope = endpoints.ServiceProvider.CreateScope())
				{
					IPublicRepository publicRepository = scope.ServiceProvider.GetRequiredService<IPublicRepository>();

					endpoints.MapTogether<Auditoriums>("/auditoriums",
					SELECT_EntireByPageSizeByPageNumberDataMethod: publicRepository.SelectAuditoriumsAsync,
					SELECT_ByMatchingPropertiesDataMethod: publicRepository.SelectAuditoriumsMatchingAsync,
					INSERT_JustOneDataMethod: publicRepository.InsertAuditoriumsJustOnceAsync,
					UPDATE_ByMatchingPropertiesDataMethod: publicRepository.UpdateAuditoriumsMatchingAsync,
					DELETE_ByMatchingPropertiesDataMethod: publicRepository.RemoveAuditoriumsMatchingAsync);

					endpoints.MapTogether<Showtimes>("/showtimes",
					SELECT_EntireByPageSizeByPageNumberDataMethod: publicRepository.SelectShowtimesAsync,
					SELECT_ByMatchingPropertiesDataMethod: publicRepository.SelectShowtimesMatchingAsync,
					INSERT_JustOneDataMethod: publicRepository.InsertShowtimesJustOnceAsync,
					UPDATE_ByMatchingPropertiesDataMethod: publicRepository.UpdateShowtimesMatchingAsync,
					DELETE_ByMatchingPropertiesDataMethod: publicRepository.RemoveShowtimesMatchingAsync);

					endpoints.MapTogether<Users>("/users",
					SELECT_EntireByPageSizeByPageNumberDataMethod: publicRepository.SelectUsersAsync,
					SELECT_ByMatchingPropertiesDataMethod: publicRepository.SelectUsersMatchingAsync,
					INSERT_JustOneDataMethod: publicRepository.InsertUsersJustOnceAsync,
					UPDATE_ByMatchingPropertiesDataMethod: publicRepository.UpdateUsersMatchingAsync,
					DELETE_ByMatchingPropertiesDataMethod: publicRepository.RemoveUsersMatchingAsync);

					endpoints.MapTogether<Seats>("/seats",
					SELECT_EntireByPageSizeByPageNumberDataMethod: publicRepository.SelectSeatsAsync,
					SELECT_ByMatchingPropertiesDataMethod: publicRepository.SelectSeatsMatchingAsync,
					INSERT_JustOneDataMethod: publicRepository.InsertSeatsJustOnceAsync,
					UPDATE_ByMatchingPropertiesDataMethod: publicRepository.UpdateSeatsMatchingAsync,
					DELETE_ByMatchingPropertiesDataMethod: publicRepository.RemoveSeatsMatchingAsync);

					endpoints.MapTogether<Menus>("/menus",
					SELECT_EntireByPageSizeByPageNumberDataMethod: publicRepository.SelectMenusAsync,
					SELECT_ByMatchingPropertiesDataMethod: publicRepository.SelectMenusMatchingAsync,
					INSERT_JustOneDataMethod: publicRepository.InsertMenusJustOnceAsync,
					UPDATE_ByMatchingPropertiesDataMethod: publicRepository.UpdateMenusMatchingAsync,
					DELETE_ByMatchingPropertiesDataMethod: publicRepository.RemoveMenusMatchingAsync);

					endpoints.MapTogether<Movies>("/movies",
					SELECT_EntireByPageSizeByPageNumberDataMethod: publicRepository.SelectMoviesAsync,
					SELECT_ByMatchingPropertiesDataMethod: publicRepository.SelectMoviesMatchingAsync,
					INSERT_JustOneDataMethod: publicRepository.InsertMoviesJustOnceAsync,
					UPDATE_ByMatchingPropertiesDataMethod: publicRepository.UpdateMoviesMatchingAsync,
					DELETE_ByMatchingPropertiesDataMethod: publicRepository.RemoveMoviesMatchingAsync);

					endpoints.MapTogether<Orders>("/orders",
					SELECT_EntireByPageSizeByPageNumberDataMethod: publicRepository.SelectOrdersAsync,
					SELECT_ByMatchingPropertiesDataMethod: publicRepository.SelectOrdersMatchingAsync,
					INSERT_JustOneDataMethod: publicRepository.InsertOrdersJustOnceAsync,
					UPDATE_ByMatchingPropertiesDataMethod: publicRepository.UpdateOrdersMatchingAsync,
					DELETE_ByMatchingPropertiesDataMethod: publicRepository.RemoveOrdersMatchingAsync);

					endpoints.MapTogether<Cinemas>("/cinemas",
					SELECT_EntireByPageSizeByPageNumberDataMethod: publicRepository.SelectCinemasAsync,
					SELECT_ByMatchingPropertiesDataMethod: publicRepository.SelectCinemasMatchingAsync,
					INSERT_JustOneDataMethod: publicRepository.InsertCinemasJustOnceAsync,
					UPDATE_ByMatchingPropertiesDataMethod: publicRepository.UpdateCinemasMatchingAsync,
					DELETE_ByMatchingPropertiesDataMethod: publicRepository.RemoveCinemasMatchingAsync);

					endpoints.MapTogether<Tickets>("/tickets",
					SELECT_EntireByPageSizeByPageNumberDataMethod: publicRepository.SelectTicketsAsync,
					SELECT_ByMatchingPropertiesDataMethod: publicRepository.SelectTicketsMatchingAsync,
					INSERT_JustOneDataMethod: publicRepository.InsertTicketsJustOnceAsync,
					UPDATE_ByMatchingPropertiesDataMethod: publicRepository.UpdateTicketsMatchingAsync,
					DELETE_ByMatchingPropertiesDataMethod: publicRepository.RemoveTicketsMatchingAsync);

					endpoints.MapTogether<Feedbacks>("/feedbacks",
					SELECT_EntireByPageSizeByPageNumberDataMethod: publicRepository.SelectFeedbacksAsync,
					SELECT_ByMatchingPropertiesDataMethod: publicRepository.SelectFeedbacksMatchingAsync,
					INSERT_JustOneDataMethod: publicRepository.InsertFeedbacksJustOnceAsync,
					UPDATE_ByMatchingPropertiesDataMethod: publicRepository.UpdateFeedbacksMatchingAsync,
					DELETE_ByMatchingPropertiesDataMethod: publicRepository.RemoveFeedbacksMatchingAsync);

					endpoints.MapTogether<Memberships>("/memberships",
					SELECT_EntireByPageSizeByPageNumberDataMethod: publicRepository.SelectMembershipsAsync,
					SELECT_ByMatchingPropertiesDataMethod: publicRepository.SelectMembershipsMatchingAsync,
					INSERT_JustOneDataMethod: publicRepository.InsertMembershipsJustOnceAsync,
					UPDATE_ByMatchingPropertiesDataMethod: publicRepository.UpdateMembershipsMatchingAsync,
					DELETE_ByMatchingPropertiesDataMethod: publicRepository.RemoveMembershipsMatchingAsync);

					endpoints.MapTogether<Reservations>("/reservations",
					SELECT_EntireByPageSizeByPageNumberDataMethod: publicRepository.SelectReservationsAsync,
					SELECT_ByMatchingPropertiesDataMethod: publicRepository.SelectReservationsMatchingAsync,
					INSERT_JustOneDataMethod: publicRepository.InsertReservationsJustOnceAsync,
					UPDATE_ByMatchingPropertiesDataMethod: publicRepository.UpdateReservationsMatchingAsync,
					DELETE_ByMatchingPropertiesDataMethod: publicRepository.RemoveReservationsMatchingAsync);

					endpoints.MapTogether<FoodAndDrinks>("/food-and-drinks",
					SELECT_EntireByPageSizeByPageNumberDataMethod: publicRepository.SelectFoodAndDrinksAsync,
					SELECT_ByMatchingPropertiesDataMethod: publicRepository.SelectFoodAndDrinksMatchingAsync,
					INSERT_JustOneDataMethod: publicRepository.InsertFoodAndDrinksJustOnceAsync,
					UPDATE_ByMatchingPropertiesDataMethod: publicRepository.UpdateFoodAndDrinksMatchingAsync,
					DELETE_ByMatchingPropertiesDataMethod: publicRepository.RemoveFoodAndDrinksMatchingAsync);
				}
			});
#pragma warning restore ASP0014

			app.Run();
		}

		public static string PatternToTitleCase(this string pattern) =>
			CultureInfo.CurrentCulture.TextInfo.ToTitleCase(pattern.Remove(startIndex: 0, count: 1));

		public static void MapTogether<T>(this IEndpointRouteBuilder endpoints, string pattern,
		Func<int, int, Task<IEnumerable<T>>> SELECT_EntireByPageSizeByPageNumberDataMethod,
		Func<T, Task<IEnumerable<T>>> SELECT_ByMatchingPropertiesDataMethod,
		Func<T, Task<int>> INSERT_JustOneDataMethod,
		Func<T, T, Task<int>> UPDATE_ByMatchingPropertiesDataMethod,
		Func<T,    Task<int>> DELETE_ByMatchingPropertiesDataMethod
		)
		{
			endpoints.Map_SELECT_EntireByPageSizeByPageNumber<T>(pattern, SELECT_EntireByPageSizeByPageNumberDataMethod);
			endpoints.Map_SELECT_ByMatchingProperties<T>(pattern, SELECT_ByMatchingPropertiesDataMethod);
			endpoints.Map_INSERT_JustOne<T>(pattern, INSERT_JustOneDataMethod);
			endpoints.Map_UPDATE_ByMatchingProperties<T>(pattern, UPDATE_ByMatchingPropertiesDataMethod);
			endpoints.Map_DELETE_ByMatchingProperties<T>(pattern, DELETE_ByMatchingPropertiesDataMethod);
		}

		public static void Map_SELECT_EntireByPageSizeByPageNumber<T>
		(this IEndpointRouteBuilder endpoints, string pattern, Func<int, int, Task<IEnumerable<T>>>
		SELECT_EntireByPageSizeByPageNumberDataMethod)
		{
			endpoints.MapGet($"select/entire{pattern}", async (
			[FromQuery(Name = "page-size")] int pageSize, [FromQuery(Name = "page-number")] int pageNumber) =>
				await SELECT_EntireByPageSizeByPageNumberDataMethod
			(pageSize, pageNumber))
			.WithTags(@"Select Entities By Provide Page Size and Page Number");
		}

		public static void Map_SELECT_ByMatchingProperties<T>
		(this IEndpointRouteBuilder endpoints, string pattern, Func<T, Task<IEnumerable<T>>> SELECT_ByMatchingPropertiesDataMethod)
		{
			endpoints.MapPost($"/select/matching-properties{pattern}", async ([FromBody] T entity) =>
				await SELECT_ByMatchingPropertiesDataMethod(entity))
			.WithTags(@"Select Entities By Matching Properties
(could omit any fields/properties in the body if the request does not wish to search for entities with that matching
fields/properties, no fields/properties included `means` matching all rows)");
		}

		public static void Map_INSERT_JustOne<T>
		(this IEndpointRouteBuilder endpoints, string pattern, Func<T, Task<int>> INSERT_JustOneDataMethod)
		{
			endpoints.MapPost($"/insert/just-one{pattern}", async ([FromBody] T entity) =>
				await INSERT_JustOneDataMethod(entity))
			.WithTags(@"Insert Just One Entity
(must provide value for all the fields/properties in the body, not necessary to include the `id` field/property because the DBMS
automatically generate and handle it - except `movies`)");
		}

		public static void Map_UPDATE_ByMatchingProperties<T>
		(this IEndpointRouteBuilder endpoints, string pattern, Func<T, T, Task<int>> UPDATE_ByMatchingPropertiesDataMethod)
		{
			endpoints.MapPut
			($"/Update/matching-properties{pattern}", async ([FromBody] UpdateMethodBody<T> updateMethodBody) =>
				await UPDATE_ByMatchingPropertiesDataMethod(updateMethodBody.Matching,  updateMethodBody.UpdatedValue))
			.WithTags(@"Update Entities By Matching Properties
(could omit any fields/properties in the matching part of the body if the request does not wish to search for entities with
  that matching fields/properties, no fields/properties included `means` matching all rows) (could omit any fields/properties
in the updated part of the body if the request does not wish that fields/properties to be updated in those matching entities)");
		}

		public static void Map_DELETE_ByMatchingProperties<T>
		(this IEndpointRouteBuilder endpoints, string pattern, Func<T, Task<int>> DELETE_ByMatchingPropertiesDataMethod)
		{
			endpoints.MapDelete
			($"/delete/matching-properties{pattern}", async ([FromBody] T entity) =>
				await DELETE_ByMatchingPropertiesDataMethod(entity))
			.WithTags(@"Delete Entities By Matching Properties
(could omit any fields/properties in the body if the request does not wish to search for entities with that matching
fields/properties then delete them, no fields/properties included `means` matching all rows then delete them)");
		}

		public static Func<int, int, Task<IEnumerable<IEntity>>> ToGenericAsync<T>
					 (Func<int, int, Task<IEnumerable<T>>> getDataMethod) where T : IEntity =>
		   async (int pageSize, int pageNumber) => (IEnumerable<IEntity>) await getDataMethod(pageSize, pageNumber);
	}

	public record struct UpdateMethodBody<T>
	{
		public T Matching { get; set; } public T UpdatedValue { get; set; }
	}
}
