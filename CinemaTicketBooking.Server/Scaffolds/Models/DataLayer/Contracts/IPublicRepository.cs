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

		Task<IEnumerable<Feedbacks>> SelectFeedbacksMatchingAsync(Feedbacks entity, string? additionalWhere = null, params (string parameterName, object? parameterValue)[] additionalParameters);

		Task<long> InsertFeedbacksJustOnceAsync(Feedbacks entity);

		Task<long> UpdateFeedbacksMatchingAsync(Feedbacks entity, Feedbacks updatedValue);

		Task<long> RemoveFeedbacksMatchingAsync(Feedbacks entity);

		Task<IEnumerable<Seats>> SelectSeatsAsync(int pageSize = 10, int pageNumber = 1);

		Task<IEnumerable<Seats>> SelectSeatsMatchingAsync(Seats entity, string? additionalWhere = null, params (string parameterName, object? parameterValue)[] additionalParameters);

		Task<long> InsertSeatsJustOnceAsync(Seats entity);

		Task<long> UpdateSeatsMatchingAsync(Seats entity, Seats updatedValue);

		Task<long> RemoveSeatsMatchingAsync(Seats entity);

		Task<IEnumerable<FoodAndDrinks>> SelectFoodAndDrinksAsync(int pageSize = 10, int pageNumber = 1);

		Task<IEnumerable<FoodAndDrinks>> SelectFoodAndDrinksMatchingAsync(FoodAndDrinks entity, string? additionalWhere = null, params (string parameterName, object? parameterValue)[] additionalParameters);

		Task<long> InsertFoodAndDrinksJustOnceAsync(FoodAndDrinks entity);

		Task<long> UpdateFoodAndDrinksMatchingAsync(FoodAndDrinks entity, FoodAndDrinks updatedValue);

		Task<long> RemoveFoodAndDrinksMatchingAsync(FoodAndDrinks entity);

		Task<IEnumerable<Auditoriums>> SelectAuditoriumsAsync(int pageSize = 10, int pageNumber = 1);

		Task<IEnumerable<Auditoriums>> SelectAuditoriumsMatchingAsync(Auditoriums entity, string? additionalWhere = null, params (string parameterName, object? parameterValue)[] additionalParameters);

		Task<long> InsertAuditoriumsJustOnceAsync(Auditoriums entity);

		Task<long> UpdateAuditoriumsMatchingAsync(Auditoriums entity, Auditoriums updatedValue);

		Task<long> RemoveAuditoriumsMatchingAsync(Auditoriums entity);

		Task<IEnumerable<Tickets>> SelectTicketsAsync(int pageSize = 10, int pageNumber = 1);

		Task<IEnumerable<Tickets>> SelectTicketsMatchingAsync(Tickets entity, string? additionalWhere = null, params (string parameterName, object? parameterValue)[] additionalParameters);

		Task<long> InsertTicketsJustOnceAsync(Tickets entity);

		Task<long> UpdateTicketsMatchingAsync(Tickets entity, Tickets updatedValue);

		Task<long> RemoveTicketsMatchingAsync(Tickets entity);

		Task<IEnumerable<Showtimes>> SelectShowtimesAsync(int pageSize = 10, int pageNumber = 1);

		Task<IEnumerable<Showtimes>> SelectShowtimesMatchingAsync(Showtimes entity, string? additionalWhere = null, params (string parameterName, object? parameterValue)[] additionalParameters);

		Task<long> InsertShowtimesJustOnceAsync(Showtimes entity);

		Task<long> UpdateShowtimesMatchingAsync(Showtimes entity, Showtimes updatedValue);

		Task<long> RemoveShowtimesMatchingAsync(Showtimes entity);

		Task<IEnumerable<Reservations>> SelectReservationsAsync(int pageSize = 10, int pageNumber = 1);

		Task<IEnumerable<Reservations>> SelectReservationsMatchingAsync(Reservations entity, string? additionalWhere = null, params (string parameterName, object? parameterValue)[] additionalParameters);

		Task<long> InsertReservationsJustOnceAsync(Reservations entity);

		Task<long> UpdateReservationsMatchingAsync(Reservations entity, Reservations updatedValue);

		Task<long> RemoveReservationsMatchingAsync(Reservations entity);

		Task<IEnumerable<Memberships>> SelectMembershipsAsync(int pageSize = 10, int pageNumber = 1);

		Task<IEnumerable<Memberships>> SelectMembershipsMatchingAsync(Memberships entity, string? additionalWhere = null, params (string parameterName, object? parameterValue)[] additionalParameters);

		Task<long> InsertMembershipsJustOnceAsync(Memberships entity);

		Task<long> UpdateMembershipsMatchingAsync(Memberships entity, Memberships updatedValue);

		Task<long> RemoveMembershipsMatchingAsync(Memberships entity);

		Task<IEnumerable<Users>> SelectUsersAsync(int pageSize = 10, int pageNumber = 1);

		Task<IEnumerable<Users>> SelectUsersMatchingAsync(Users entity, string? additionalWhere = null, params (string parameterName, object? parameterValue)[] additionalParameters);

		Task<long> InsertUsersJustOnceAsync(Users entity);

		Task<long> UpdateUsersMatchingAsync(Users entity, Users updatedValue);

		Task<long> RemoveUsersMatchingAsync(Users entity);

		Task<IEnumerable<Movies>> SelectMoviesAsync(int pageSize = 10, int pageNumber = 1);

		Task<IEnumerable<Movies>> SelectMoviesMatchingAsync(Movies entity, string? additionalWhere = null, params (string parameterName, object? parameterValue)[] additionalParameters);

		Task<long> InsertMoviesJustOnceAsync(Movies entity);

		Task<long> UpdateMoviesMatchingAsync(Movies entity, Movies updatedValue);

		Task<long> RemoveMoviesMatchingAsync(Movies entity);

		Task<IEnumerable<Cinemas>> SelectCinemasAsync(int pageSize = 10, int pageNumber = 1);

		Task<IEnumerable<Cinemas>> SelectCinemasMatchingAsync(Cinemas entity, string? additionalWhere = null, params (string parameterName, object? parameterValue)[] additionalParameters);

		Task<long> InsertCinemasJustOnceAsync(Cinemas entity);

		Task<long> UpdateCinemasMatchingAsync(Cinemas entity, Cinemas updatedValue);

		Task<long> RemoveCinemasMatchingAsync(Cinemas entity);

		Task<IEnumerable<Orders>> SelectOrdersAsync(int pageSize = 10, int pageNumber = 1);

		Task<IEnumerable<Orders>> SelectOrdersMatchingAsync(Orders entity, string? additionalWhere = null, params (string parameterName, object? parameterValue)[] additionalParameters);

		Task<long> InsertOrdersJustOnceAsync(Orders entity);

		Task<long> UpdateOrdersMatchingAsync(Orders entity, Orders updatedValue);

		Task<long> RemoveOrdersMatchingAsync(Orders entity);

		Task<IEnumerable<ExtendedMenus>> SelectMenusAsync(int pageSize = 10, int pageNumber = 1);

		Task<IEnumerable<ExtendedMenus>> SelectMenusMatchingAsync(Menus entity, string? additionalWhere = null, params (string parameterName, object? parameterValue)[] additionalParameters);

		Task<long> InsertMenusJustOnceAsync(Menus entity);

		Task<long> UpdateMenusMatchingAsync(Menus entity, Menus updatedValue);

		Task<long> RemoveMenusMatchingAsync(Menus entity);

		Task<IEnumerable<Staffs>> SelectStaffsAsync(int pageSize = 10, int pageNumber = 1);

		Task<IEnumerable<Staffs>> SelectStaffsMatchingAsync(Staffs entity, string? additionalWhere = null, params (string parameterName, object? parameterValue)[] additionalParameters);

		Task<long> InsertStaffsJustOnceAsync(Staffs entity);

		Task<long> UpdateStaffsMatchingAsync(Staffs entity, Staffs updatedValue);

		Task<long> RemoveStaffsMatchingAsync(Staffs entity);

		Task<IEnumerable<Discounts>> SelectDiscountsAsync(int pageSize = 10, int pageNumber = 1);

		Task<IEnumerable<Discounts>> SelectDiscountsMatchingAsync(Discounts entity, string? additionalWhere = null, params (string parameterName, object? parameterValue)[] additionalParameters);

		Task<long> InsertDiscountsJustOnceAsync(Discounts entity);

		Task<long> UpdateDiscountsMatchingAsync(Discounts entity, Discounts updatedValue);

		Task<long> RemoveDiscountsMatchingAsync(Discounts entity);

		Task<IEnumerable<Bills>> SelectBillsAsync(int pageSize = 10, int pageNumber = 1);

		Task<IEnumerable<Bills>> SelectBillsMatchingAsync(Bills entity, string? additionalWhere = null, params (string parameterName, object? parameterValue)[] additionalParameters);

		Task<long> InsertBillsJustOnceAsync(Bills entity);

		Task<long> UpdateBillsMatchingAsync(Bills entity, Bills updatedValue);

		Task<long> RemoveBillsMatchingAsync(Bills entity);

		Task<IEnumerable<ExtendedDiscountsUsers>> SelectDiscountsUsersAsync(int pageSize = 10, int pageNumber = 1);

		Task<IEnumerable<ExtendedDiscountsUsers>> SelectDiscountsUsersMatchingAsync(DiscountsUsers entity, string? additionalWhere = null, params (string parameterName, object? parameterValue)[] additionalParameters);

		Task<long> InsertDiscountsUsersJustOnceAsync(DiscountsUsers entity);

		Task<long> UpdateDiscountsUsersMatchingAsync(DiscountsUsers entity, DiscountsUsers updatedValue);

		Task<long> RemoveDiscountsUsersMatchingAsync(DiscountsUsers entity);
	}
}
