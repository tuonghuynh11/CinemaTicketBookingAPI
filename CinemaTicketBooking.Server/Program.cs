using Npgsql;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using CinemaTicketBooking.Server.Scaffolds.Models.EntityLayer;
using CinemaTicketBooking.Server.Scaffolds.Models.DataLayer.Contracts;
using CinemaTicketBooking.Server.Scaffolds.Models.DataLayer.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

            // Add authentication services
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // Configure your token validation parameters here
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-secret-key")), // Use a secret key from your configuration
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        // Set other token validation parameters as needed
                    };
                });

            // Add authorization services
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapGet("/", () => "Hello");

#pragma warning disable ASP0014
			app.UseEndpoints(endpoints =>
			{
				using (IServiceScope scope = endpoints.ServiceProvider.CreateScope())
				{
					IPublicRepository publicRepository = scope.ServiceProvider.GetRequiredService<IPublicRepository>();

					endpoints.MapTogether<Auditoriums>("/auditoriums",
					SELECT_EntireDataMethod: publicRepository.GetAuditoriumsAsync,
					SELECT_ByMatchingPropertiesDataMethod: publicRepository.GetAuditoriumsAsync,
					INSERT_JustOneDataMethod: publicRepository.AddAuditoriumsAsync,
					UPDATE_JustOneDataMethod: publicRepository.UpdateAuditoriumsAsync,
					DELETE_JustOneDataMethod: publicRepository.RemoveAuditoriumsAsync);

					endpoints.MapTogether<Showtimes>("/showtimes",
					SELECT_EntireDataMethod: publicRepository.GetShowtimesAsync,
					SELECT_ByMatchingPropertiesDataMethod: publicRepository.GetShowtimesAsync,
					INSERT_JustOneDataMethod: publicRepository.AddShowtimesAsync,
					UPDATE_JustOneDataMethod: publicRepository.UpdateShowtimesAsync,
					DELETE_JustOneDataMethod: publicRepository.RemoveShowtimesAsync);

					endpoints.MapTogether<Users>("/users",
					SELECT_EntireDataMethod: publicRepository.GetUsersAsync,
					SELECT_ByMatchingPropertiesDataMethod: publicRepository.GetUsersAsync,
					INSERT_JustOneDataMethod: publicRepository.AddUsersAsync,
					UPDATE_JustOneDataMethod: publicRepository.UpdateUsersAsync,
					DELETE_JustOneDataMethod: publicRepository.RemoveUsersAsync);

					endpoints.MapTogether<Seats>("/seats",
					SELECT_EntireDataMethod: publicRepository.GetSeatsAsync,
					SELECT_ByMatchingPropertiesDataMethod: publicRepository.GetSeatsAsync,
					INSERT_JustOneDataMethod: publicRepository.AddSeatsAsync,
					UPDATE_JustOneDataMethod: publicRepository.UpdateSeatsAsync,
					DELETE_JustOneDataMethod: publicRepository.RemoveSeatsAsync);

					endpoints.MapTogether<Menus>("/menus",
					SELECT_EntireDataMethod: publicRepository.GetMenusAsync,
					SELECT_ByMatchingPropertiesDataMethod: publicRepository.GetMenusAsync,
					INSERT_JustOneDataMethod: publicRepository.AddMenusAsync,
					UPDATE_JustOneDataMethod: publicRepository.UpdateMenusAsync,
					DELETE_JustOneDataMethod: publicRepository.RemoveMenusAsync);

					endpoints.MapTogether<Movies>("/movies",
					SELECT_EntireDataMethod: publicRepository.GetMoviesAsync,
					SELECT_ByMatchingPropertiesDataMethod: publicRepository.GetMoviesAsync,
					INSERT_JustOneDataMethod: publicRepository.AddMoviesAsync,
					UPDATE_JustOneDataMethod: publicRepository.UpdateMoviesAsync,
					DELETE_JustOneDataMethod: publicRepository.RemoveMoviesAsync);

					endpoints.MapTogether<Orders>("/orders",
					SELECT_EntireDataMethod: publicRepository.GetOrdersAsync,
					SELECT_ByMatchingPropertiesDataMethod: publicRepository.GetOrdersAsync,
					INSERT_JustOneDataMethod: publicRepository.AddOrdersAsync,
					UPDATE_JustOneDataMethod: publicRepository.UpdateOrdersAsync,
					DELETE_JustOneDataMethod: publicRepository.RemoveOrdersAsync);

					endpoints.MapTogether<Cinemas>("/cinemas",
					SELECT_EntireDataMethod: publicRepository.GetCinemasAsync,
					SELECT_ByMatchingPropertiesDataMethod: publicRepository.GetCinemasAsync,
					INSERT_JustOneDataMethod: publicRepository.AddCinemasAsync,
					UPDATE_JustOneDataMethod: publicRepository.UpdateCinemasAsync,
					DELETE_JustOneDataMethod: publicRepository.RemoveCinemasAsync);

					endpoints.MapTogether<Tickets>("/tickets",
					SELECT_EntireDataMethod: publicRepository.GetTicketsAsync,
					SELECT_ByMatchingPropertiesDataMethod: publicRepository.GetTicketsAsync,
					INSERT_JustOneDataMethod: publicRepository.AddTicketsAsync,
					UPDATE_JustOneDataMethod: publicRepository.UpdateTicketsAsync,
					DELETE_JustOneDataMethod: publicRepository.RemoveTicketsAsync);

					endpoints.MapTogether<Feedbacks>("/feedbacks",
					SELECT_EntireDataMethod: publicRepository.GetFeedbacksAsync,
					SELECT_ByMatchingPropertiesDataMethod: publicRepository.GetFeedbacksAsync,
					INSERT_JustOneDataMethod: publicRepository.AddFeedbacksAsync,
					UPDATE_JustOneDataMethod: publicRepository.UpdateFeedbacksAsync,
					DELETE_JustOneDataMethod: publicRepository.RemoveFeedbacksAsync);

					endpoints.MapTogether<Memberships>("/memberships",
					SELECT_EntireDataMethod: publicRepository.GetMembershipsAsync,
					SELECT_ByMatchingPropertiesDataMethod: publicRepository.GetMembershipsAsync,
					INSERT_JustOneDataMethod: publicRepository.AddMembershipsAsync,
					UPDATE_JustOneDataMethod: publicRepository.UpdateMembershipsAsync,
					DELETE_JustOneDataMethod: publicRepository.RemoveMembershipsAsync);

					endpoints.MapTogether<Reservations>("/reservations",
					SELECT_EntireDataMethod: publicRepository.GetReservationsAsync,
					SELECT_ByMatchingPropertiesDataMethod: publicRepository.GetReservationsAsync,
					INSERT_JustOneDataMethod: publicRepository.AddReservationsAsync,
					UPDATE_JustOneDataMethod: publicRepository.UpdateReservationsAsync,
					DELETE_JustOneDataMethod: publicRepository.RemoveReservationsAsync);

					endpoints.MapTogether<FoodAndDrinks>("/food-and-drinks",
					SELECT_EntireDataMethod: publicRepository.GetFoodAndDrinksAsync,
					SELECT_ByMatchingPropertiesDataMethod: publicRepository.GetFoodAndDrinksAsync,
					INSERT_JustOneDataMethod: publicRepository.AddFoodAndDrinksAsync,
					UPDATE_JustOneDataMethod: publicRepository.UpdateFoodAndDrinksAsync,
					DELETE_JustOneDataMethod: publicRepository.RemoveFoodAndDrinksAsync);

					//endpoints.Map_SELECT_Entire<Auditoriums>("/auditoriums", publicRepository.GetAuditoriumsAsync);
					//endpoints.Map_SELECT_Entire<Showtimes>("/showtimes", publicRepository.GetShowtimesAsync);
					//endpoints.Map_SELECT_Entire<Users>("/users", publicRepository.GetUsersAsync);
					//endpoints.Map_SELECT_Entire<Seats>("/seats", publicRepository.GetSeatsAsync);
					//endpoints.Map_SELECT_Entire<Menus>("/menus", publicRepository.GetMenusAsync);
					//endpoints.Map_SELECT_Entire<Movies>("/movies", publicRepository.GetMoviesAsync);
					//endpoints.Map_SELECT_Entire<Orders>("/orders", publicRepository.GetOrdersAsync);
					//endpoints.Map_SELECT_Entire<Cinemas>("/cinemas", publicRepository.GetCinemasAsync);
					//endpoints.Map_SELECT_Entire<Tickets>("/tickets", publicRepository.GetTicketsAsync);
					//endpoints.Map_SELECT_Entire<Reservations>("/reservations", publicRepository.GetReservationsAsync);
					//endpoints.Map_SELECT_Entire<FoodAndDrinks>("/food-and-drinks", publicRepository.GetFoodAndDrinksAsync);

					//endpoints.Map_SELECT_ByMatchingProperties<Auditoriums>("/auditoriums", publicRepository.GetAuditoriumsAsync);
					//endpoints.Map_SELECT_ByMatchingProperties<Showtimes>("/showtimes", publicRepository.GetShowtimesAsync);
					//endpoints.Map_SELECT_ByMatchingProperties<Users>("/users", publicRepository.GetUsersAsync);
					//endpoints.Map_SELECT_ByMatchingProperties<Seats>("/seats", publicRepository.GetSeatsAsync);
					//endpoints.Map_SELECT_ByMatchingProperties<Menus>("/menus", publicRepository.GetMenusAsync);
					//endpoints.Map_SELECT_ByMatchingProperties<Movies>("/movies", publicRepository.GetMoviesAsync);
					//endpoints.Map_SELECT_ByMatchingProperties<Orders>("/orders", publicRepository.GetOrdersAsync);
					//endpoints.Map_SELECT_ByMatchingProperties<Cinemas>("/cinemas", publicRepository.GetCinemasAsync);
					//endpoints.Map_SELECT_ByMatchingProperties<Tickets>("/tickets", publicRepository.GetTicketsAsync);
					//endpoints.Map_SELECT_ByMatchingProperties<Reservations>("/reservations", publicRepository.GetReservationsAsync);
					//endpoints.Map_SELECT_ByMatchingProperties<FoodAndDrinks>("/food-and-drinks", publicRepository.GetFoodAndDrinksAsync);
				}
			});
#pragma warning restore ASP0014

			app.Run();
		}

		public static string PatternToTitleCase(this string pattern) =>
			CultureInfo.CurrentCulture.TextInfo.ToTitleCase(pattern.Remove(startIndex: 0, count: 1));

		public static void MapTogether<T>(this IEndpointRouteBuilder endpoints, string pattern,
		Func<int, int, Task<IEnumerable<T>>> SELECT_EntireDataMethod,
		Func<T, Task<T?>> SELECT_ByMatchingPropertiesDataMethod,
		Func<T, Task<int>> INSERT_JustOneDataMethod,
		Func<T, Task<int>> UPDATE_JustOneDataMethod,
		Func<T, Task<int>> DELETE_JustOneDataMethod
		)
		{
			endpoints.Map_SELECT_Entire<T>(pattern, SELECT_EntireDataMethod);
			endpoints.Map_SELECT_ByMatchingProperties<T>(pattern, SELECT_ByMatchingPropertiesDataMethod);
			endpoints.Map_INSERT_JustOne<T>(pattern, INSERT_JustOneDataMethod);
			endpoints.Map_UPDATE_JustOne<T>(pattern, UPDATE_JustOneDataMethod);
			endpoints.Map_DELETE_JustOne<T>(pattern, DELETE_JustOneDataMethod);
		}

		public static void Map_SELECT_Entire<T>
		(this IEndpointRouteBuilder endpoints, string pattern, Func<int, int, Task<IEnumerable<T>>> SELECT_EntireDataMethod)
		{
			endpoints.MapGet($"select/entire{pattern}", async (
			[FromQuery(Name = "page-size")] int pageSize, [FromQuery(Name = "page-number")] int pageNumber) =>
				await SELECT_EntireDataMethod(pageSize, pageNumber));
			//.WithOpenApi().WithName($"SELECT_Entire{pattern.PatternToTitleCase()}");
		}

		public static void Map_SELECT_ByMatchingProperties<T>
		(this IEndpointRouteBuilder endpoints, string pattern, Func<T, Task<T?>> SELECT_ByMatchingPropertiesDataMethod)
		{
			endpoints.MapGet($"/select/matching-properties{pattern}", async ([FromBody] T entity) =>
				await SELECT_ByMatchingPropertiesDataMethod(entity));
			//.WithOpenApi().WithName($"SELECT_ByMatchingProperties{pattern.PatternToTitleCase()}");
		}

		public static void Map_INSERT_JustOne<T>
		(this IEndpointRouteBuilder endpoints, string pattern, Func<T, Task<int>> INSERT_JustOneDataMethod)
		{
			endpoints.MapPost($"/insert/just-one{pattern}", async ([FromBody] T entity) =>
				await INSERT_JustOneDataMethod(entity));
			//.WithOpenApi().WithName($"INSERT_JustOne{pattern.PatternToTitleCase()}");
		}

		public static void Map_UPDATE_JustOne<T>
		(this IEndpointRouteBuilder endpoints, string pattern, Func<T, Task<int>> UPDATE_JustOneDataMethod)
		{
			endpoints.MapPut($"/update/just-one{pattern}", async ([FromBody] T entity) =>
				await UPDATE_JustOneDataMethod(entity));
			//.WithOpenApi().WithName($"UPDATE_JustOne{pattern.PatternToTitleCase()}");
		}

		public static void Map_DELETE_JustOne<T>
		(this IEndpointRouteBuilder endpoints, string pattern, Func<T, Task<int>> DELETE_JustOneDataMethod)
		{
			endpoints.MapDelete($"/delete/just-one{pattern}", async ([FromBody] T entity) =>
				await DELETE_JustOneDataMethod(entity));
			//.WithOpenApi().WithName($"DELETE_JustOne{pattern.PatternToTitleCase()}");
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
