using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using CinemaTicketBooking.Server.Scaffolds.Models.EntityLayer;
using CinemaTicketBooking.Server.Scaffolds.Models.DataLayer.Contracts;

namespace CinemaTicketBooking.Server.Scaffolds.Models.DataLayer.Contracts
{
	public interface IPublicRepository : IRepository
	{
		Task<IEnumerable<Feedbacks>> GetFeedbacksAsync(int pageSize = 10, int pageNumber = 1);

		Task<Feedbacks?> GetFeedbacksAsync(Feedbacks entity);

		Task<int> AddFeedbacksAsync(Feedbacks entity);

		Task<int> UpdateFeedbacksAsync(Feedbacks entity);

		Task<int> RemoveFeedbacksAsync(Feedbacks entity);

		Task<IEnumerable<Seats>> GetSeatsAsync(int pageSize = 10, int pageNumber = 1);

		Task<Seats?> GetSeatsAsync(Seats entity);

		Task<int> AddSeatsAsync(Seats entity);

		Task<int> UpdateSeatsAsync(Seats entity);

		Task<int> RemoveSeatsAsync(Seats entity);

		Task<IEnumerable<FoodAndDrinks>> GetFoodAndDrinksAsync(int pageSize = 10, int pageNumber = 1);

		Task<FoodAndDrinks?> GetFoodAndDrinksAsync(FoodAndDrinks entity);

		Task<int> AddFoodAndDrinksAsync(FoodAndDrinks entity);

		Task<int> UpdateFoodAndDrinksAsync(FoodAndDrinks entity);

		Task<int> RemoveFoodAndDrinksAsync(FoodAndDrinks entity);

		Task<IEnumerable<Auditoriums>> GetAuditoriumsAsync(int pageSize = 10, int pageNumber = 1);

		Task<Auditoriums?> GetAuditoriumsAsync(Auditoriums entity);

		Task<int> AddAuditoriumsAsync(Auditoriums entity);

		Task<int> UpdateAuditoriumsAsync(Auditoriums entity);

		Task<int> RemoveAuditoriumsAsync(Auditoriums entity);

		Task<IEnumerable<Tickets>> GetTicketsAsync(int pageSize = 10, int pageNumber = 1);

		Task<Tickets?> GetTicketsAsync(Tickets entity);

		Task<int> AddTicketsAsync(Tickets entity);

		Task<int> UpdateTicketsAsync(Tickets entity);

		Task<int> RemoveTicketsAsync(Tickets entity);

		Task<IEnumerable<Showtimes>> GetShowtimesAsync(int pageSize = 10, int pageNumber = 1);

		Task<Showtimes?> GetShowtimesAsync(Showtimes entity);

		Task<int> AddShowtimesAsync(Showtimes entity);

		Task<int> UpdateShowtimesAsync(Showtimes entity);

		Task<int> RemoveShowtimesAsync(Showtimes entity);

		Task<IEnumerable<Reservations>> GetReservationsAsync(int pageSize = 10, int pageNumber = 1);

		Task<Reservations?> GetReservationsAsync(Reservations entity);

		Task<int> AddReservationsAsync(Reservations entity);

		Task<int> UpdateReservationsAsync(Reservations entity);

		Task<int> RemoveReservationsAsync(Reservations entity);

		Task<IEnumerable<Memberships>> GetMembershipsAsync(int pageSize = 10, int pageNumber = 1);

		Task<Memberships?> GetMembershipsAsync(Memberships entity);

		Task<int> AddMembershipsAsync(Memberships entity);

		Task<int> UpdateMembershipsAsync(Memberships entity);

		Task<int> RemoveMembershipsAsync(Memberships entity);

		Task<IEnumerable<Users>> GetUsersAsync(int pageSize = 10, int pageNumber = 1);

		Task<Users?> GetUsersAsync(Users entity);

		Task<int> AddUsersAsync(Users entity);

		Task<int> UpdateUsersAsync(Users entity);

		Task<int> RemoveUsersAsync(Users entity);

		Task<IEnumerable<Movies>> GetMoviesAsync(int pageSize = 10, int pageNumber = 1);

		Task<Movies?> GetMoviesAsync(Movies entity);

		Task<int> AddMoviesAsync(Movies entity);

		Task<int> UpdateMoviesAsync(Movies entity);

		Task<int> RemoveMoviesAsync(Movies entity);

		Task<IEnumerable<Cinemas>> GetCinemasAsync(int pageSize = 10, int pageNumber = 1);

		Task<Cinemas?> GetCinemasAsync(Cinemas entity);

		Task<int> AddCinemasAsync(Cinemas entity);

		Task<int> UpdateCinemasAsync(Cinemas entity);

		Task<int> RemoveCinemasAsync(Cinemas entity);

		Task<IEnumerable<Orders>> GetOrdersAsync(int pageSize = 10, int pageNumber = 1);

		Task<Orders?> GetOrdersAsync(Orders entity);

		Task<int> AddOrdersAsync(Orders entity);

		Task<int> UpdateOrdersAsync(Orders entity);

		Task<int> RemoveOrdersAsync(Orders entity);

		Task<IEnumerable<Menus>> GetMenusAsync(int pageSize = 10, int pageNumber = 1);

		Task<Menus?> GetMenusAsync(Menus entity);

		Task<int> AddMenusAsync(Menus entity);

		Task<int> UpdateMenusAsync(Menus entity);

		Task<int> RemoveMenusAsync(Menus entity);
	}
}
