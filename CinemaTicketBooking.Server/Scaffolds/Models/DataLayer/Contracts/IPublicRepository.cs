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
		Task<IEnumerable<Feedbacks>> SelectFeedbacksAsync(int pageSize = 10, int pageNumber = 1);

		Task<IEnumerable<Feedbacks>> SelectFeedbacksMatchingAsync(Feedbacks entity);

		Task<int> InsertFeedbacksJustOnceAsync(Feedbacks entity);

		Task<int> UpdateFeedbacksMatchingAsync(Feedbacks entity, Feedbacks updatedValue);

		Task<int> RemoveFeedbacksMatchingAsync(Feedbacks entity);

		Task<IEnumerable<Seats>> SelectSeatsAsync(int pageSize = 10, int pageNumber = 1);

		Task<IEnumerable<Seats>> SelectSeatsMatchingAsync(Seats entity);

		Task<int> InsertSeatsJustOnceAsync(Seats entity);

		Task<int> UpdateSeatsMatchingAsync(Seats entity, Seats updatedValue);

		Task<int> RemoveSeatsMatchingAsync(Seats entity);

		Task<IEnumerable<FoodAndDrinks>> SelectFoodAndDrinksAsync(int pageSize = 10, int pageNumber = 1);

		Task<IEnumerable<FoodAndDrinks>> SelectFoodAndDrinksMatchingAsync(FoodAndDrinks entity);

		Task<int> InsertFoodAndDrinksJustOnceAsync(FoodAndDrinks entity);

		Task<int> UpdateFoodAndDrinksMatchingAsync(FoodAndDrinks entity, FoodAndDrinks updatedValue);

		Task<int> RemoveFoodAndDrinksMatchingAsync(FoodAndDrinks entity);

		Task<IEnumerable<Auditoriums>> SelectAuditoriumsAsync(int pageSize = 10, int pageNumber = 1);

		Task<IEnumerable<Auditoriums>> SelectAuditoriumsMatchingAsync(Auditoriums entity);

		Task<int> InsertAuditoriumsJustOnceAsync(Auditoriums entity);

		Task<int> UpdateAuditoriumsMatchingAsync(Auditoriums entity, Auditoriums updatedValue);

		Task<int> RemoveAuditoriumsMatchingAsync(Auditoriums entity);

		Task<IEnumerable<Tickets>> SelectTicketsAsync(int pageSize = 10, int pageNumber = 1);

		Task<IEnumerable<Tickets>> SelectTicketsMatchingAsync(Tickets entity);

		Task<int> InsertTicketsJustOnceAsync(Tickets entity);

		Task<int> UpdateTicketsMatchingAsync(Tickets entity, Tickets updatedValue);

		Task<int> RemoveTicketsMatchingAsync(Tickets entity);

		Task<IEnumerable<Showtimes>> SelectShowtimesAsync(int pageSize = 10, int pageNumber = 1);

		Task<IEnumerable<Showtimes>> SelectShowtimesMatchingAsync(Showtimes entity);

		Task<int> InsertShowtimesJustOnceAsync(Showtimes entity);

		Task<int> UpdateShowtimesMatchingAsync(Showtimes entity, Showtimes updatedValue);

		Task<int> RemoveShowtimesMatchingAsync(Showtimes entity);

		Task<IEnumerable<Reservations>> SelectReservationsAsync(int pageSize = 10, int pageNumber = 1);

		Task<IEnumerable<Reservations>> SelectReservationsMatchingAsync(Reservations entity);

		Task<int> InsertReservationsJustOnceAsync(Reservations entity);

		Task<int> UpdateReservationsMatchingAsync(Reservations entity, Reservations updatedValue);

		Task<int> RemoveReservationsMatchingAsync(Reservations entity);

		Task<IEnumerable<Memberships>> SelectMembershipsAsync(int pageSize = 10, int pageNumber = 1);

		Task<IEnumerable<Memberships>> SelectMembershipsMatchingAsync(Memberships entity);

		Task<int> InsertMembershipsJustOnceAsync(Memberships entity);

		Task<int> UpdateMembershipsMatchingAsync(Memberships entity, Memberships updatedValue);

		Task<int> RemoveMembershipsMatchingAsync(Memberships entity);

		Task<IEnumerable<Users>> SelectUsersAsync(int pageSize = 10, int pageNumber = 1);

		Task<IEnumerable<Users>> SelectUsersMatchingAsync(Users entity);

		Task<int> InsertUsersJustOnceAsync(Users entity);

		Task<int> UpdateUsersMatchingAsync(Users entity, Users updatedValue);

		Task<int> RemoveUsersMatchingAsync(Users entity);

		Task<IEnumerable<Movies>> SelectMoviesAsync(int pageSize = 10, int pageNumber = 1);

		Task<IEnumerable<Movies>> SelectMoviesMatchingAsync(Movies entity);

		Task<int> InsertMoviesJustOnceAsync(Movies entity);

		Task<int> UpdateMoviesMatchingAsync(Movies entity, Movies updatedValue);

		Task<int> RemoveMoviesMatchingAsync(Movies entity);

		Task<IEnumerable<Cinemas>> SelectCinemasAsync(int pageSize = 10, int pageNumber = 1);

		Task<IEnumerable<Cinemas>> SelectCinemasMatchingAsync(Cinemas entity);

		Task<int> InsertCinemasJustOnceAsync(Cinemas entity);

		Task<int> UpdateCinemasMatchingAsync(Cinemas entity, Cinemas updatedValue);

		Task<int> RemoveCinemasMatchingAsync(Cinemas entity);

		Task<IEnumerable<Orders>> SelectOrdersAsync(int pageSize = 10, int pageNumber = 1);

		Task<IEnumerable<Orders>> SelectOrdersMatchingAsync(Orders entity);

		Task<int> InsertOrdersJustOnceAsync(Orders entity);

		Task<int> UpdateOrdersMatchingAsync(Orders entity, Orders updatedValue);

		Task<int> RemoveOrdersMatchingAsync(Orders entity);

		Task<IEnumerable<ExtendedMenus>> SelectMenusAsync(int pageSize = 10, int pageNumber = 1);

		Task<IEnumerable<ExtendedMenus>> SelectMenusMatchingAsync(Menus entity);

		Task<int> InsertMenusJustOnceAsync(Menus entity);

		Task<int> UpdateMenusMatchingAsync(Menus entity, Menus updatedValue);

		Task<int> RemoveMenusMatchingAsync(Menus entity);
	}
}
