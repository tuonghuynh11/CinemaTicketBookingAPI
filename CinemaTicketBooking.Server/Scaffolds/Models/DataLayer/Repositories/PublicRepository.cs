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

namespace CinemaTicketBooking.Server.Scaffolds.Models.DataLayer.Repositories
{
	public class PublicRepository : Repository, IPublicRepository
	{
		public PublicRepository(IDbConnection connection)
			: base(connection)
		{
		}

		public async Task<IEnumerable<Seats>> GetSeatsAsync(int pageSize = 10, int pageNumber = 1)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("  id Id, ");
			query.Append("  auditorium_id AuditoriumId, ");
			query.Append("  row_number RowNumber, ");
			query.Append("  col_number ColNumber, ");
			query.Append("  created_timestamp CreatedTimestamp, ");
			query.Append("  updated_timestamp UpdatedTimestamp ");
			query.Append(" from ");
			query.Append("  public.seats ");
			query.Append(" where ");
			query.Append(" order by ");
			query.Append("  id ");
			query.Append(" offset @pageSize * (@pageNumber - 1) rows ");
			query.Append(" fetch next @pageSize rows only ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@pageSize", pageSize);
			parameters.Add("@pageNumber", pageNumber);
			
			// Retrieve result from database and convert to typed list
			return await Connection.QueryAsync<Seats>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<Seats> GetSeatsAsync(Seats entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("  id Id, ");
			query.Append("  auditorium_id AuditoriumId, ");
			query.Append("  row_number RowNumber, ");
			query.Append("  col_number ColNumber, ");
			query.Append("  created_timestamp CreatedTimestamp, ");
			query.Append("  updated_timestamp UpdatedTimestamp ");
			query.Append(" from ");
			query.Append("  public.seats ");
			query.Append(" where ");
			query.Append("  id = @id ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("id", entity.Id);
			
			// Retrieve result from database and convert to entity class
			return await Connection.QueryFirstOrDefaultAsync<Seats>(query.ToString(), parameters);
		}

		public async Task<int> AddSeatsAsync(Seats entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" insert into ");
			query.Append("  public.seats ");
			query.Append("  ( ");
			query.Append("   id, ");
			query.Append("   auditorium_id, ");
			query.Append("   row_number, ");
			query.Append("   col_number, ");
			query.Append("   created_timestamp, ");
			query.Append("   updated_timestamp ");
			query.Append("  ) ");
			query.Append(" values ");
			query.Append(" ( ");
			query.Append("  @id, ");
			query.Append("  @auditoriumId, ");
			query.Append("  @rowNumber, ");
			query.Append("  @colNumber, ");
			query.Append("  @createdTimestamp, ");
			query.Append("  @updatedTimestamp ");
			query.Append(" ) ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@id", entity.Id);
			parameters.Add("@auditoriumId", entity.AuditoriumId);
			parameters.Add("@rowNumber", entity.RowNumber);
			parameters.Add("@colNumber", entity.ColNumber);
			parameters.Add("@createdTimestamp", entity.CreatedTimestamp);
			parameters.Add("@updatedTimestamp", entity.UpdatedTimestamp);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<int> UpdateSeatsAsync(Seats entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" update ");
			query.Append("  public.seats ");
			query.Append(" set ");
			query.Append("  auditorium_id = @auditoriumId, ");
			query.Append("  row_number = @rowNumber, ");
			query.Append("  col_number = @colNumber, ");
			query.Append("  created_timestamp = @createdTimestamp, ");
			query.Append("  updated_timestamp = @updatedTimestamp ");
			query.Append(" where ");
			query.Append("  id = @id ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@auditoriumId", entity.AuditoriumId);
			parameters.Add("@rowNumber", entity.RowNumber);
			parameters.Add("@colNumber", entity.ColNumber);
			parameters.Add("@createdTimestamp", entity.CreatedTimestamp);
			parameters.Add("@updatedTimestamp", entity.UpdatedTimestamp);
			parameters.Add("@id", entity.Id);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<int> RemoveSeatsAsync(Seats entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" delete from ");
			query.Append("  public.seats ");
			query.Append(" where ");
			query.Append("  id = @id ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@id", entity.Id);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<FoodAndDrinks>> GetFoodAndDrinksAsync(int pageSize = 10, int pageNumber = 1)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("  id Id, ");
			query.Append("  name Name, ");
			query.Append("  category Category, ");
			query.Append("  description Description, ");
			query.Append("  created_timestamp CreatedTimestamp, ");
			query.Append("  updated_timestamp UpdatedTimestamp, ");
			query.Append("  image_url ImageUrl ");
			query.Append(" from ");
			query.Append("  public.food_and_drinks ");
			query.Append(" where ");
			query.Append(" order by ");
			query.Append("  id ");
			query.Append(" offset @pageSize * (@pageNumber - 1) rows ");
			query.Append(" fetch next @pageSize rows only ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@pageSize", pageSize);
			parameters.Add("@pageNumber", pageNumber);
			
			// Retrieve result from database and convert to typed list
			return await Connection.QueryAsync<FoodAndDrinks>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<FoodAndDrinks> GetFoodAndDrinksAsync(FoodAndDrinks entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("  id Id, ");
			query.Append("  name Name, ");
			query.Append("  category Category, ");
			query.Append("  description Description, ");
			query.Append("  created_timestamp CreatedTimestamp, ");
			query.Append("  updated_timestamp UpdatedTimestamp, ");
			query.Append("  image_url ImageUrl ");
			query.Append(" from ");
			query.Append("  public.food_and_drinks ");
			query.Append(" where ");
			query.Append("  id = @id ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("id", entity.Id);
			
			// Retrieve result from database and convert to entity class
			return await Connection.QueryFirstOrDefaultAsync<FoodAndDrinks>(query.ToString(), parameters);
		}

		public async Task<int> AddFoodAndDrinksAsync(FoodAndDrinks entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" insert into ");
			query.Append("  public.food_and_drinks ");
			query.Append("  ( ");
			query.Append("   id, ");
			query.Append("   name, ");
			query.Append("   category, ");
			query.Append("   description, ");
			query.Append("   created_timestamp, ");
			query.Append("   updated_timestamp, ");
			query.Append("   image_url ");
			query.Append("  ) ");
			query.Append(" values ");
			query.Append(" ( ");
			query.Append("  @id, ");
			query.Append("  @name, ");
			query.Append("  @category, ");
			query.Append("  @description, ");
			query.Append("  @createdTimestamp, ");
			query.Append("  @updatedTimestamp, ");
			query.Append("  @imageUrl ");
			query.Append(" ) ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@id", entity.Id);
			parameters.Add("@name", entity.Name);
			parameters.Add("@category", entity.Category);
			parameters.Add("@description", entity.Description);
			parameters.Add("@createdTimestamp", entity.CreatedTimestamp);
			parameters.Add("@updatedTimestamp", entity.UpdatedTimestamp);
			parameters.Add("@imageUrl", entity.ImageUrl);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<int> UpdateFoodAndDrinksAsync(FoodAndDrinks entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" update ");
			query.Append("  public.food_and_drinks ");
			query.Append(" set ");
			query.Append("  name = @name, ");
			query.Append("  category = @category, ");
			query.Append("  description = @description, ");
			query.Append("  created_timestamp = @createdTimestamp, ");
			query.Append("  updated_timestamp = @updatedTimestamp, ");
			query.Append("  image_url = @imageUrl ");
			query.Append(" where ");
			query.Append("  id = @id ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@name", entity.Name);
			parameters.Add("@category", entity.Category);
			parameters.Add("@description", entity.Description);
			parameters.Add("@createdTimestamp", entity.CreatedTimestamp);
			parameters.Add("@updatedTimestamp", entity.UpdatedTimestamp);
			parameters.Add("@imageUrl", entity.ImageUrl);
			parameters.Add("@id", entity.Id);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<int> RemoveFoodAndDrinksAsync(FoodAndDrinks entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" delete from ");
			query.Append("  public.food_and_drinks ");
			query.Append(" where ");
			query.Append("  id = @id ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@id", entity.Id);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<Auditoriums>> GetAuditoriumsAsync(int pageSize = 10, int pageNumber = 1)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("  id Id, ");
			query.Append("  name Name, ");
			query.Append("  cinema_id CinemaId, ");
			query.Append("  updated_timestamp UpdatedTimestamp, ");
			query.Append("  created_timestamp CreatedTimestamp ");
			query.Append(" from ");
			query.Append("  public.auditoriums ");
			query.Append(" where ");
			query.Append(" order by ");
			query.Append("  id ");
			query.Append(" offset @pageSize * (@pageNumber - 1) rows ");
			query.Append(" fetch next @pageSize rows only ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@pageSize", pageSize);
			parameters.Add("@pageNumber", pageNumber);
			
			// Retrieve result from database and convert to typed list
			return await Connection.QueryAsync<Auditoriums>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<Auditoriums> GetAuditoriumsAsync(Auditoriums entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("  id Id, ");
			query.Append("  name Name, ");
			query.Append("  cinema_id CinemaId, ");
			query.Append("  updated_timestamp UpdatedTimestamp, ");
			query.Append("  created_timestamp CreatedTimestamp ");
			query.Append(" from ");
			query.Append("  public.auditoriums ");
			query.Append(" where ");
			query.Append("  id = @id ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("id", entity.Id);
			
			// Retrieve result from database and convert to entity class
			return await Connection.QueryFirstOrDefaultAsync<Auditoriums>(query.ToString(), parameters);
		}

		public async Task<int> AddAuditoriumsAsync(Auditoriums entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" insert into ");
			query.Append("  public.auditoriums ");
			query.Append("  ( ");
			query.Append("   id, ");
			query.Append("   name, ");
			query.Append("   cinema_id, ");
			query.Append("   updated_timestamp, ");
			query.Append("   created_timestamp ");
			query.Append("  ) ");
			query.Append(" values ");
			query.Append(" ( ");
			query.Append("  @id, ");
			query.Append("  @name, ");
			query.Append("  @cinemaId, ");
			query.Append("  @updatedTimestamp, ");
			query.Append("  @createdTimestamp ");
			query.Append(" ) ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@id", entity.Id);
			parameters.Add("@name", entity.Name);
			parameters.Add("@cinemaId", entity.CinemaId);
			parameters.Add("@updatedTimestamp", entity.UpdatedTimestamp);
			parameters.Add("@createdTimestamp", entity.CreatedTimestamp);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<int> UpdateAuditoriumsAsync(Auditoriums entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" update ");
			query.Append("  public.auditoriums ");
			query.Append(" set ");
			query.Append("  name = @name, ");
			query.Append("  cinema_id = @cinemaId, ");
			query.Append("  updated_timestamp = @updatedTimestamp, ");
			query.Append("  created_timestamp = @createdTimestamp ");
			query.Append(" where ");
			query.Append("  id = @id ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@name", entity.Name);
			parameters.Add("@cinemaId", entity.CinemaId);
			parameters.Add("@updatedTimestamp", entity.UpdatedTimestamp);
			parameters.Add("@createdTimestamp", entity.CreatedTimestamp);
			parameters.Add("@id", entity.Id);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<int> RemoveAuditoriumsAsync(Auditoriums entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" delete from ");
			query.Append("  public.auditoriums ");
			query.Append(" where ");
			query.Append("  id = @id ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@id", entity.Id);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<Tickets>> GetTicketsAsync(int pageSize = 10, int pageNumber = 1)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("  id Id, ");
			query.Append("  showtime_id ShowtimeId, ");
			query.Append("  user_id UserId, ");
			query.Append("  created_timestamp CreatedTimestamp, ");
			query.Append("  updated_timestamp UpdatedTimestamp ");
			query.Append(" from ");
			query.Append("  public.tickets ");
			query.Append(" where ");
			query.Append(" order by ");
			query.Append("  id ");
			query.Append(" offset @pageSize * (@pageNumber - 1) rows ");
			query.Append(" fetch next @pageSize rows only ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@pageSize", pageSize);
			parameters.Add("@pageNumber", pageNumber);
			
			// Retrieve result from database and convert to typed list
			return await Connection.QueryAsync<Tickets>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<Tickets> GetTicketsAsync(Tickets entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("  id Id, ");
			query.Append("  showtime_id ShowtimeId, ");
			query.Append("  user_id UserId, ");
			query.Append("  created_timestamp CreatedTimestamp, ");
			query.Append("  updated_timestamp UpdatedTimestamp ");
			query.Append(" from ");
			query.Append("  public.tickets ");
			query.Append(" where ");
			query.Append("  id = @id ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("id", entity.Id);
			
			// Retrieve result from database and convert to entity class
			return await Connection.QueryFirstOrDefaultAsync<Tickets>(query.ToString(), parameters);
		}

		public async Task<int> AddTicketsAsync(Tickets entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" insert into ");
			query.Append("  public.tickets ");
			query.Append("  ( ");
			query.Append("   id, ");
			query.Append("   showtime_id, ");
			query.Append("   user_id, ");
			query.Append("   created_timestamp, ");
			query.Append("   updated_timestamp ");
			query.Append("  ) ");
			query.Append(" values ");
			query.Append(" ( ");
			query.Append("  @id, ");
			query.Append("  @showtimeId, ");
			query.Append("  @userId, ");
			query.Append("  @createdTimestamp, ");
			query.Append("  @updatedTimestamp ");
			query.Append(" ) ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@id", entity.Id);
			parameters.Add("@showtimeId", entity.ShowtimeId);
			parameters.Add("@userId", entity.UserId);
			parameters.Add("@createdTimestamp", entity.CreatedTimestamp);
			parameters.Add("@updatedTimestamp", entity.UpdatedTimestamp);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<int> UpdateTicketsAsync(Tickets entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" update ");
			query.Append("  public.tickets ");
			query.Append(" set ");
			query.Append("  showtime_id = @showtimeId, ");
			query.Append("  user_id = @userId, ");
			query.Append("  created_timestamp = @createdTimestamp, ");
			query.Append("  updated_timestamp = @updatedTimestamp ");
			query.Append(" where ");
			query.Append("  id = @id ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@showtimeId", entity.ShowtimeId);
			parameters.Add("@userId", entity.UserId);
			parameters.Add("@createdTimestamp", entity.CreatedTimestamp);
			parameters.Add("@updatedTimestamp", entity.UpdatedTimestamp);
			parameters.Add("@id", entity.Id);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<int> RemoveTicketsAsync(Tickets entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" delete from ");
			query.Append("  public.tickets ");
			query.Append(" where ");
			query.Append("  id = @id ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@id", entity.Id);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<Showtimes>> GetShowtimesAsync(int pageSize = 10, int pageNumber = 1)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("  id Id, ");
			query.Append("  movie_id MovieId, ");
			query.Append("  start_time StartTime, ");
			query.Append("  cease_time CeaseTime, ");
			query.Append("  date Date, ");
			query.Append("  auditorium_id AuditoriumId, ");
			query.Append("  price Price, ");
			query.Append("  status Status, ");
			query.Append("  created_timestamp CreatedTimestamp, ");
			query.Append("  updated_timestamp UpdatedTimestamp ");
			query.Append(" from ");
			query.Append("  public.showtimes ");
			query.Append(" where ");
			query.Append(" order by ");
			query.Append("  id ");
			query.Append(" offset @pageSize * (@pageNumber - 1) rows ");
			query.Append(" fetch next @pageSize rows only ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@pageSize", pageSize);
			parameters.Add("@pageNumber", pageNumber);
			
			// Retrieve result from database and convert to typed list
			return await Connection.QueryAsync<Showtimes>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<Showtimes> GetShowtimesAsync(Showtimes entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("  id Id, ");
			query.Append("  movie_id MovieId, ");
			query.Append("  start_time StartTime, ");
			query.Append("  cease_time CeaseTime, ");
			query.Append("  date Date, ");
			query.Append("  auditorium_id AuditoriumId, ");
			query.Append("  price Price, ");
			query.Append("  status Status, ");
			query.Append("  created_timestamp CreatedTimestamp, ");
			query.Append("  updated_timestamp UpdatedTimestamp ");
			query.Append(" from ");
			query.Append("  public.showtimes ");
			query.Append(" where ");
			query.Append("  id = @id ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("id", entity.Id);
			
			// Retrieve result from database and convert to entity class
			return await Connection.QueryFirstOrDefaultAsync<Showtimes>(query.ToString(), parameters);
		}

		public async Task<int> AddShowtimesAsync(Showtimes entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" insert into ");
			query.Append("  public.showtimes ");
			query.Append("  ( ");
			query.Append("   id, ");
			query.Append("   movie_id, ");
			query.Append("   start_time, ");
			query.Append("   cease_time, ");
			query.Append("   date, ");
			query.Append("   auditorium_id, ");
			query.Append("   price, ");
			query.Append("   status, ");
			query.Append("   created_timestamp, ");
			query.Append("   updated_timestamp ");
			query.Append("  ) ");
			query.Append(" values ");
			query.Append(" ( ");
			query.Append("  @id, ");
			query.Append("  @movieId, ");
			query.Append("  @startTime, ");
			query.Append("  @ceaseTime, ");
			query.Append("  @date, ");
			query.Append("  @auditoriumId, ");
			query.Append("  @price, ");
			query.Append("  @status, ");
			query.Append("  @createdTimestamp, ");
			query.Append("  @updatedTimestamp ");
			query.Append(" ) ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@id", entity.Id);
			parameters.Add("@movieId", entity.MovieId);
			parameters.Add("@startTime", entity.StartTime);
			parameters.Add("@ceaseTime", entity.CeaseTime);
			parameters.Add("@date", entity.Date);
			parameters.Add("@auditoriumId", entity.AuditoriumId);
			parameters.Add("@price", entity.Price);
			parameters.Add("@status", entity.Status);
			parameters.Add("@createdTimestamp", entity.CreatedTimestamp);
			parameters.Add("@updatedTimestamp", entity.UpdatedTimestamp);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<int> UpdateShowtimesAsync(Showtimes entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" update ");
			query.Append("  public.showtimes ");
			query.Append(" set ");
			query.Append("  movie_id = @movieId, ");
			query.Append("  start_time = @startTime, ");
			query.Append("  cease_time = @ceaseTime, ");
			query.Append("  date = @date, ");
			query.Append("  auditorium_id = @auditoriumId, ");
			query.Append("  price = @price, ");
			query.Append("  status = @status, ");
			query.Append("  created_timestamp = @createdTimestamp, ");
			query.Append("  updated_timestamp = @updatedTimestamp ");
			query.Append(" where ");
			query.Append("  id = @id ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@movieId", entity.MovieId);
			parameters.Add("@startTime", entity.StartTime);
			parameters.Add("@ceaseTime", entity.CeaseTime);
			parameters.Add("@date", entity.Date);
			parameters.Add("@auditoriumId", entity.AuditoriumId);
			parameters.Add("@price", entity.Price);
			parameters.Add("@status", entity.Status);
			parameters.Add("@createdTimestamp", entity.CreatedTimestamp);
			parameters.Add("@updatedTimestamp", entity.UpdatedTimestamp);
			parameters.Add("@id", entity.Id);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<int> RemoveShowtimesAsync(Showtimes entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" delete from ");
			query.Append("  public.showtimes ");
			query.Append(" where ");
			query.Append("  id = @id ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@id", entity.Id);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<Reservations>> GetReservationsAsync(int pageSize = 10, int pageNumber = 1)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("  showtime_id ShowtimeId, ");
			query.Append("  seat_id SeatId, ");
			query.Append("  ticket_id TicketId, ");
			query.Append("  created_timestamp CreatedTimestamp, ");
			query.Append("  updated_timestamp UpdatedTimestamp ");
			query.Append(" from ");
			query.Append("  public.reservations ");
			query.Append(" where ");
			query.Append(" order by ");
			query.Append("  showtime_id ");
			query.Append(" offset @pageSize * (@pageNumber - 1) rows ");
			query.Append(" fetch next @pageSize rows only ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@pageSize", pageSize);
			parameters.Add("@pageNumber", pageNumber);
			
			// Retrieve result from database and convert to typed list
			return await Connection.QueryAsync<Reservations>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<Reservations> GetReservationsAsync(Reservations entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("  showtime_id ShowtimeId, ");
			query.Append("  seat_id SeatId, ");
			query.Append("  ticket_id TicketId, ");
			query.Append("  created_timestamp CreatedTimestamp, ");
			query.Append("  updated_timestamp UpdatedTimestamp ");
			query.Append(" from ");
			query.Append("  public.reservations ");
			query.Append(" where ");
			query.Append("  showtime_id = @showtimeId ");
			
			query.Append("  seat_id = @seatId ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("showtimeId", entity.ShowtimeId);
			parameters.Add("seatId", entity.SeatId);
			
			// Retrieve result from database and convert to entity class
			return await Connection.QueryFirstOrDefaultAsync<Reservations>(query.ToString(), parameters);
		}

		public async Task<int> AddReservationsAsync(Reservations entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" insert into ");
			query.Append("  public.reservations ");
			query.Append("  ( ");
			query.Append("   showtime_id, ");
			query.Append("   seat_id, ");
			query.Append("   ticket_id, ");
			query.Append("   created_timestamp, ");
			query.Append("   updated_timestamp ");
			query.Append("  ) ");
			query.Append(" values ");
			query.Append(" ( ");
			query.Append("  @showtimeId, ");
			query.Append("  @seatId, ");
			query.Append("  @ticketId, ");
			query.Append("  @createdTimestamp, ");
			query.Append("  @updatedTimestamp ");
			query.Append(" ) ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@showtimeId", entity.ShowtimeId);
			parameters.Add("@seatId", entity.SeatId);
			parameters.Add("@ticketId", entity.TicketId);
			parameters.Add("@createdTimestamp", entity.CreatedTimestamp);
			parameters.Add("@updatedTimestamp", entity.UpdatedTimestamp);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<int> UpdateReservationsAsync(Reservations entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" update ");
			query.Append("  public.reservations ");
			query.Append(" set ");
			query.Append("  ticket_id = @ticketId, ");
			query.Append("  created_timestamp = @createdTimestamp, ");
			query.Append("  updated_timestamp = @updatedTimestamp ");
			query.Append(" where ");
			query.Append("  showtime_id = @showtimeId and  ");
			query.Append("  seat_id = @seatId ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@ticketId", entity.TicketId);
			parameters.Add("@createdTimestamp", entity.CreatedTimestamp);
			parameters.Add("@updatedTimestamp", entity.UpdatedTimestamp);
			parameters.Add("@showtimeId", entity.ShowtimeId);
			parameters.Add("@seatId", entity.SeatId);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<int> RemoveReservationsAsync(Reservations entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" delete from ");
			query.Append("  public.reservations ");
			query.Append(" where ");
			query.Append("  showtime_id = @showtimeId and  ");
			query.Append("  seat_id = @seatId ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@showtimeId", entity.ShowtimeId);
			parameters.Add("@seatId", entity.SeatId);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<Users>> GetUsersAsync(int pageSize = 10, int pageNumber = 1)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("  id Id, ");
			query.Append("  username Username, ");
			query.Append("  password Password, ");
			query.Append("  created_timestamp CreatedTimestamp, ");
			query.Append("  updated_timestamp UpdatedTimestamp ");
			query.Append(" from ");
			query.Append("  public.users ");
			query.Append(" where ");
			query.Append(" order by ");
			query.Append("  id ");
			query.Append(" offset @pageSize * (@pageNumber - 1) rows ");
			query.Append(" fetch next @pageSize rows only ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@pageSize", pageSize);
			parameters.Add("@pageNumber", pageNumber);
			
			// Retrieve result from database and convert to typed list
			return await Connection.QueryAsync<Users>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<Users> GetUsersAsync(Users entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("  id Id, ");
			query.Append("  username Username, ");
			query.Append("  password Password, ");
			query.Append("  created_timestamp CreatedTimestamp, ");
			query.Append("  updated_timestamp UpdatedTimestamp ");
			query.Append(" from ");
			query.Append("  public.users ");
			query.Append(" where ");
			query.Append("  id = @id ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("id", entity.Id);
			
			// Retrieve result from database and convert to entity class
			return await Connection.QueryFirstOrDefaultAsync<Users>(query.ToString(), parameters);
		}

		public async Task<int> AddUsersAsync(Users entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" insert into ");
			query.Append("  public.users ");
			query.Append("  ( ");
			query.Append("   id, ");
			query.Append("   username, ");
			query.Append("   password, ");
			query.Append("   created_timestamp, ");
			query.Append("   updated_timestamp ");
			query.Append("  ) ");
			query.Append(" values ");
			query.Append(" ( ");
			query.Append("  @id, ");
			query.Append("  @username, ");
			query.Append("  @password, ");
			query.Append("  @createdTimestamp, ");
			query.Append("  @updatedTimestamp ");
			query.Append(" ) ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@id", entity.Id);
			parameters.Add("@username", entity.Username);
			parameters.Add("@password", entity.Password);
			parameters.Add("@createdTimestamp", entity.CreatedTimestamp);
			parameters.Add("@updatedTimestamp", entity.UpdatedTimestamp);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<int> UpdateUsersAsync(Users entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" update ");
			query.Append("  public.users ");
			query.Append(" set ");
			query.Append("  username = @username, ");
			query.Append("  password = @password, ");
			query.Append("  created_timestamp = @createdTimestamp, ");
			query.Append("  updated_timestamp = @updatedTimestamp ");
			query.Append(" where ");
			query.Append("  id = @id ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@username", entity.Username);
			parameters.Add("@password", entity.Password);
			parameters.Add("@createdTimestamp", entity.CreatedTimestamp);
			parameters.Add("@updatedTimestamp", entity.UpdatedTimestamp);
			parameters.Add("@id", entity.Id);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<int> RemoveUsersAsync(Users entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" delete from ");
			query.Append("  public.users ");
			query.Append(" where ");
			query.Append("  id = @id ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@id", entity.Id);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<Movies>> GetMoviesAsync(int pageSize = 10, int pageNumber = 1)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("  adult Adult, ");
			query.Append("  backdrop_path BackdropPath, ");
			query.Append("  belongs_to_collection BelongsToCollection, ");
			query.Append("  budget Budget, ");
			query.Append("  genres Genres, ");
			query.Append("  homepage Homepage, ");
			query.Append("  id Id, ");
			query.Append("  imdb_id ImdbId, ");
			query.Append("  original_language OriginalLanguage, ");
			query.Append("  original_title OriginalTitle, ");
			query.Append("  overview Overview, ");
			query.Append("  popularity Popularity, ");
			query.Append("  poster_path PosterPath, ");
			query.Append("  production_companies ProductionCompanies, ");
			query.Append("  production_countries ProductionCountries, ");
			query.Append("  release_date ReleaseDate, ");
			query.Append("  revenue Revenue, ");
			query.Append("  runtime Runtime, ");
			query.Append("  spoken_languages SpokenLanguages, ");
			query.Append("  status Status, ");
			query.Append("  tagline Tagline, ");
			query.Append("  title Title, ");
			query.Append("  video Video, ");
			query.Append("  vote_average VoteAverage, ");
			query.Append("  vote_count VoteCount, ");
			query.Append("  casting Casting, ");
			query.Append("  directors Directors, ");
			query.Append("  created_timestamp CreatedTimestamp, ");
			query.Append("  updated_timestamp UpdatedTimestamp ");
			query.Append(" from ");
			query.Append("  public.movies ");
			query.Append(" where ");
			query.Append(" order by ");
			query.Append("  adult ");
			query.Append(" offset @pageSize * (@pageNumber - 1) rows ");
			query.Append(" fetch next @pageSize rows only ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@pageSize", pageSize);
			parameters.Add("@pageNumber", pageNumber);
			
			// Retrieve result from database and convert to typed list
			return await Connection.QueryAsync<Movies>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<Movies> GetMoviesAsync(Movies entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("  adult Adult, ");
			query.Append("  backdrop_path BackdropPath, ");
			query.Append("  belongs_to_collection BelongsToCollection, ");
			query.Append("  budget Budget, ");
			query.Append("  genres Genres, ");
			query.Append("  homepage Homepage, ");
			query.Append("  id Id, ");
			query.Append("  imdb_id ImdbId, ");
			query.Append("  original_language OriginalLanguage, ");
			query.Append("  original_title OriginalTitle, ");
			query.Append("  overview Overview, ");
			query.Append("  popularity Popularity, ");
			query.Append("  poster_path PosterPath, ");
			query.Append("  production_companies ProductionCompanies, ");
			query.Append("  production_countries ProductionCountries, ");
			query.Append("  release_date ReleaseDate, ");
			query.Append("  revenue Revenue, ");
			query.Append("  runtime Runtime, ");
			query.Append("  spoken_languages SpokenLanguages, ");
			query.Append("  status Status, ");
			query.Append("  tagline Tagline, ");
			query.Append("  title Title, ");
			query.Append("  video Video, ");
			query.Append("  vote_average VoteAverage, ");
			query.Append("  vote_count VoteCount, ");
			query.Append("  casting Casting, ");
			query.Append("  directors Directors, ");
			query.Append("  created_timestamp CreatedTimestamp, ");
			query.Append("  updated_timestamp UpdatedTimestamp ");
			query.Append(" from ");
			query.Append("  public.movies ");
			query.Append(" where ");
			query.Append("  id = @id ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("id", entity.Id);
			
			// Retrieve result from database and convert to entity class
			return await Connection.QueryFirstOrDefaultAsync<Movies>(query.ToString(), parameters);
		}

		public async Task<int> AddMoviesAsync(Movies entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" insert into ");
			query.Append("  public.movies ");
			query.Append("  ( ");
			query.Append("   adult, ");
			query.Append("   backdrop_path, ");
			query.Append("   belongs_to_collection, ");
			query.Append("   budget, ");
			query.Append("   genres, ");
			query.Append("   homepage, ");
			query.Append("   id, ");
			query.Append("   imdb_id, ");
			query.Append("   original_language, ");
			query.Append("   original_title, ");
			query.Append("   overview, ");
			query.Append("   popularity, ");
			query.Append("   poster_path, ");
			query.Append("   production_companies, ");
			query.Append("   production_countries, ");
			query.Append("   release_date, ");
			query.Append("   revenue, ");
			query.Append("   runtime, ");
			query.Append("   spoken_languages, ");
			query.Append("   status, ");
			query.Append("   tagline, ");
			query.Append("   title, ");
			query.Append("   video, ");
			query.Append("   vote_average, ");
			query.Append("   vote_count, ");
			query.Append("   casting, ");
			query.Append("   directors, ");
			query.Append("   created_timestamp, ");
			query.Append("   updated_timestamp ");
			query.Append("  ) ");
			query.Append(" values ");
			query.Append(" ( ");
			query.Append("  @adult, ");
			query.Append("  @backdropPath, ");
			query.Append("  @belongsToCollection, ");
			query.Append("  @budget, ");
			query.Append("  @genres, ");
			query.Append("  @homepage, ");
			query.Append("  @id, ");
			query.Append("  @imdbId, ");
			query.Append("  @originalLanguage, ");
			query.Append("  @originalTitle, ");
			query.Append("  @overview, ");
			query.Append("  @popularity, ");
			query.Append("  @posterPath, ");
			query.Append("  @productionCompanies, ");
			query.Append("  @productionCountries, ");
			query.Append("  @releaseDate, ");
			query.Append("  @revenue, ");
			query.Append("  @runtime, ");
			query.Append("  @spokenLanguages, ");
			query.Append("  @status, ");
			query.Append("  @tagline, ");
			query.Append("  @title, ");
			query.Append("  @video, ");
			query.Append("  @voteAverage, ");
			query.Append("  @voteCount, ");
			query.Append("  @casting, ");
			query.Append("  @directors, ");
			query.Append("  @createdTimestamp, ");
			query.Append("  @updatedTimestamp ");
			query.Append(" ) ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@adult", entity.Adult);
			parameters.Add("@backdropPath", entity.BackdropPath);
			parameters.Add("@belongsToCollection", entity.BelongsToCollection);
			parameters.Add("@budget", entity.Budget);
			parameters.Add("@genres", entity.Genres);
			parameters.Add("@homepage", entity.Homepage);
			parameters.Add("@id", entity.Id);
			parameters.Add("@imdbId", entity.ImdbId);
			parameters.Add("@originalLanguage", entity.OriginalLanguage);
			parameters.Add("@originalTitle", entity.OriginalTitle);
			parameters.Add("@overview", entity.Overview);
			parameters.Add("@popularity", entity.Popularity);
			parameters.Add("@posterPath", entity.PosterPath);
			parameters.Add("@productionCompanies", entity.ProductionCompanies);
			parameters.Add("@productionCountries", entity.ProductionCountries);
			parameters.Add("@releaseDate", entity.ReleaseDate);
			parameters.Add("@revenue", entity.Revenue);
			parameters.Add("@runtime", entity.Runtime);
			parameters.Add("@spokenLanguages", entity.SpokenLanguages);
			parameters.Add("@status", entity.Status);
			parameters.Add("@tagline", entity.Tagline);
			parameters.Add("@title", entity.Title);
			parameters.Add("@video", entity.Video);
			parameters.Add("@voteAverage", entity.VoteAverage);
			parameters.Add("@voteCount", entity.VoteCount);
			parameters.Add("@casting", entity.Casting);
			parameters.Add("@directors", entity.Directors);
			parameters.Add("@createdTimestamp", entity.CreatedTimestamp);
			parameters.Add("@updatedTimestamp", entity.UpdatedTimestamp);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<int> UpdateMoviesAsync(Movies entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" update ");
			query.Append("  public.movies ");
			query.Append(" set ");
			query.Append("  adult = @adult, ");
			query.Append("  backdrop_path = @backdropPath, ");
			query.Append("  belongs_to_collection = @belongsToCollection, ");
			query.Append("  budget = @budget, ");
			query.Append("  genres = @genres, ");
			query.Append("  homepage = @homepage, ");
			query.Append("  imdb_id = @imdbId, ");
			query.Append("  original_language = @originalLanguage, ");
			query.Append("  original_title = @originalTitle, ");
			query.Append("  overview = @overview, ");
			query.Append("  popularity = @popularity, ");
			query.Append("  poster_path = @posterPath, ");
			query.Append("  production_companies = @productionCompanies, ");
			query.Append("  production_countries = @productionCountries, ");
			query.Append("  release_date = @releaseDate, ");
			query.Append("  revenue = @revenue, ");
			query.Append("  runtime = @runtime, ");
			query.Append("  spoken_languages = @spokenLanguages, ");
			query.Append("  status = @status, ");
			query.Append("  tagline = @tagline, ");
			query.Append("  title = @title, ");
			query.Append("  video = @video, ");
			query.Append("  vote_average = @voteAverage, ");
			query.Append("  vote_count = @voteCount, ");
			query.Append("  casting = @casting, ");
			query.Append("  directors = @directors, ");
			query.Append("  created_timestamp = @createdTimestamp, ");
			query.Append("  updated_timestamp = @updatedTimestamp ");
			query.Append(" where ");
			query.Append("  id = @id ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@adult", entity.Adult);
			parameters.Add("@backdropPath", entity.BackdropPath);
			parameters.Add("@belongsToCollection", entity.BelongsToCollection);
			parameters.Add("@budget", entity.Budget);
			parameters.Add("@genres", entity.Genres);
			parameters.Add("@homepage", entity.Homepage);
			parameters.Add("@imdbId", entity.ImdbId);
			parameters.Add("@originalLanguage", entity.OriginalLanguage);
			parameters.Add("@originalTitle", entity.OriginalTitle);
			parameters.Add("@overview", entity.Overview);
			parameters.Add("@popularity", entity.Popularity);
			parameters.Add("@posterPath", entity.PosterPath);
			parameters.Add("@productionCompanies", entity.ProductionCompanies);
			parameters.Add("@productionCountries", entity.ProductionCountries);
			parameters.Add("@releaseDate", entity.ReleaseDate);
			parameters.Add("@revenue", entity.Revenue);
			parameters.Add("@runtime", entity.Runtime);
			parameters.Add("@spokenLanguages", entity.SpokenLanguages);
			parameters.Add("@status", entity.Status);
			parameters.Add("@tagline", entity.Tagline);
			parameters.Add("@title", entity.Title);
			parameters.Add("@video", entity.Video);
			parameters.Add("@voteAverage", entity.VoteAverage);
			parameters.Add("@voteCount", entity.VoteCount);
			parameters.Add("@casting", entity.Casting);
			parameters.Add("@directors", entity.Directors);
			parameters.Add("@createdTimestamp", entity.CreatedTimestamp);
			parameters.Add("@updatedTimestamp", entity.UpdatedTimestamp);
			parameters.Add("@id", entity.Id);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<int> RemoveMoviesAsync(Movies entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" delete from ");
			query.Append("  public.movies ");
			query.Append(" where ");
			query.Append("  id = @id ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@id", entity.Id);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<Cinemas>> GetCinemasAsync(int pageSize = 10, int pageNumber = 1)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("  id Id, ");
			query.Append("  name Name, ");
			query.Append("  address Address, ");
			query.Append("  created_timestamp CreatedTimestamp, ");
			query.Append("  updated_timestamp UpdatedTimestamp ");
			query.Append(" from ");
			query.Append("  public.cinemas ");
			query.Append(" where ");
			query.Append(" order by ");
			query.Append("  id ");
			query.Append(" offset @pageSize * (@pageNumber - 1) rows ");
			query.Append(" fetch next @pageSize rows only ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@pageSize", pageSize);
			parameters.Add("@pageNumber", pageNumber);
			
			// Retrieve result from database and convert to typed list
			return await Connection.QueryAsync<Cinemas>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<Cinemas> GetCinemasAsync(Cinemas entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("  id Id, ");
			query.Append("  name Name, ");
			query.Append("  address Address, ");
			query.Append("  created_timestamp CreatedTimestamp, ");
			query.Append("  updated_timestamp UpdatedTimestamp ");
			query.Append(" from ");
			query.Append("  public.cinemas ");
			query.Append(" where ");
			query.Append("  id = @id ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("id", entity.Id);
			
			// Retrieve result from database and convert to entity class
			return await Connection.QueryFirstOrDefaultAsync<Cinemas>(query.ToString(), parameters);
		}

		public async Task<int> AddCinemasAsync(Cinemas entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" insert into ");
			query.Append("  public.cinemas ");
			query.Append("  ( ");
			query.Append("   id, ");
			query.Append("   name, ");
			query.Append("   address, ");
			query.Append("   created_timestamp, ");
			query.Append("   updated_timestamp ");
			query.Append("  ) ");
			query.Append(" values ");
			query.Append(" ( ");
			query.Append("  @id, ");
			query.Append("  @name, ");
			query.Append("  @address, ");
			query.Append("  @createdTimestamp, ");
			query.Append("  @updatedTimestamp ");
			query.Append(" ) ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@id", entity.Id);
			parameters.Add("@name", entity.Name);
			parameters.Add("@address", entity.Address);
			parameters.Add("@createdTimestamp", entity.CreatedTimestamp);
			parameters.Add("@updatedTimestamp", entity.UpdatedTimestamp);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<int> UpdateCinemasAsync(Cinemas entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" update ");
			query.Append("  public.cinemas ");
			query.Append(" set ");
			query.Append("  name = @name, ");
			query.Append("  address = @address, ");
			query.Append("  created_timestamp = @createdTimestamp, ");
			query.Append("  updated_timestamp = @updatedTimestamp ");
			query.Append(" where ");
			query.Append("  id = @id ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@name", entity.Name);
			parameters.Add("@address", entity.Address);
			parameters.Add("@createdTimestamp", entity.CreatedTimestamp);
			parameters.Add("@updatedTimestamp", entity.UpdatedTimestamp);
			parameters.Add("@id", entity.Id);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<int> RemoveCinemasAsync(Cinemas entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" delete from ");
			query.Append("  public.cinemas ");
			query.Append(" where ");
			query.Append("  id = @id ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@id", entity.Id);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<Orders>> GetOrdersAsync(int pageSize = 10, int pageNumber = 1)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("  ticket_id TicketId, ");
			query.Append("  food_and_drink_id FoodAndDrinkId, ");
			query.Append("  created_timestamp CreatedTimestamp, ");
			query.Append("  updated_timestamp UpdatedTimestamp ");
			query.Append(" from ");
			query.Append("  public.orders ");
			query.Append(" where ");
			query.Append(" order by ");
			query.Append("  ticket_id ");
			query.Append(" offset @pageSize * (@pageNumber - 1) rows ");
			query.Append(" fetch next @pageSize rows only ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@pageSize", pageSize);
			parameters.Add("@pageNumber", pageNumber);
			
			// Retrieve result from database and convert to typed list
			return await Connection.QueryAsync<Orders>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<Orders> GetOrdersAsync(Orders entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("  ticket_id TicketId, ");
			query.Append("  food_and_drink_id FoodAndDrinkId, ");
			query.Append("  created_timestamp CreatedTimestamp, ");
			query.Append("  updated_timestamp UpdatedTimestamp ");
			query.Append(" from ");
			query.Append("  public.orders ");
			query.Append(" where ");
			query.Append("  ticket_id = @ticketId ");
			
			query.Append("  food_and_drink_id = @foodAndDrinkId ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("ticketId", entity.TicketId);
			parameters.Add("foodAndDrinkId", entity.FoodAndDrinkId);
			
			// Retrieve result from database and convert to entity class
			return await Connection.QueryFirstOrDefaultAsync<Orders>(query.ToString(), parameters);
		}

		public async Task<int> AddOrdersAsync(Orders entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" insert into ");
			query.Append("  public.orders ");
			query.Append("  ( ");
			query.Append("   ticket_id, ");
			query.Append("   food_and_drink_id, ");
			query.Append("   created_timestamp, ");
			query.Append("   updated_timestamp ");
			query.Append("  ) ");
			query.Append(" values ");
			query.Append(" ( ");
			query.Append("  @ticketId, ");
			query.Append("  @foodAndDrinkId, ");
			query.Append("  @createdTimestamp, ");
			query.Append("  @updatedTimestamp ");
			query.Append(" ) ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@ticketId", entity.TicketId);
			parameters.Add("@foodAndDrinkId", entity.FoodAndDrinkId);
			parameters.Add("@createdTimestamp", entity.CreatedTimestamp);
			parameters.Add("@updatedTimestamp", entity.UpdatedTimestamp);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<int> UpdateOrdersAsync(Orders entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" update ");
			query.Append("  public.orders ");
			query.Append(" set ");
			query.Append("  created_timestamp = @createdTimestamp, ");
			query.Append("  updated_timestamp = @updatedTimestamp ");
			query.Append(" where ");
			query.Append("  ticket_id = @ticketId and  ");
			query.Append("  food_and_drink_id = @foodAndDrinkId ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@createdTimestamp", entity.CreatedTimestamp);
			parameters.Add("@updatedTimestamp", entity.UpdatedTimestamp);
			parameters.Add("@ticketId", entity.TicketId);
			parameters.Add("@foodAndDrinkId", entity.FoodAndDrinkId);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<int> RemoveOrdersAsync(Orders entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" delete from ");
			query.Append("  public.orders ");
			query.Append(" where ");
			query.Append("  ticket_id = @ticketId and  ");
			query.Append("  food_and_drink_id = @foodAndDrinkId ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@ticketId", entity.TicketId);
			parameters.Add("@foodAndDrinkId", entity.FoodAndDrinkId);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<Menus>> GetMenusAsync(int pageSize = 10, int pageNumber = 1)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("  cinema_id CinemaId, ");
			query.Append("  food_and_drink_id FoodAndDrinkId, ");
			query.Append("  serving_size ServingSize, ");
			query.Append("  availability Availability, ");
			query.Append("  price Price, ");
			query.Append("  created_timestamp CreatedTimestamp, ");
			query.Append("  updated_timestamp UpdatedTimestamp ");
			query.Append(" from ");
			query.Append("  public.menus ");
			query.Append(" where ");
			query.Append(" order by ");
			query.Append("  cinema_id ");
			query.Append(" offset @pageSize * (@pageNumber - 1) rows ");
			query.Append(" fetch next @pageSize rows only ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@pageSize", pageSize);
			parameters.Add("@pageNumber", pageNumber);
			
			// Retrieve result from database and convert to typed list
			return await Connection.QueryAsync<Menus>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<Menus> GetMenusAsync(Menus entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("  cinema_id CinemaId, ");
			query.Append("  food_and_drink_id FoodAndDrinkId, ");
			query.Append("  serving_size ServingSize, ");
			query.Append("  availability Availability, ");
			query.Append("  price Price, ");
			query.Append("  created_timestamp CreatedTimestamp, ");
			query.Append("  updated_timestamp UpdatedTimestamp ");
			query.Append(" from ");
			query.Append("  public.menus ");
			query.Append(" where ");
			query.Append("  cinema_id = @cinemaId ");
			
			query.Append("  food_and_drink_id = @foodAndDrinkId ");
			
			query.Append("  serving_size = @servingSize ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("cinemaId", entity.CinemaId);
			parameters.Add("foodAndDrinkId", entity.FoodAndDrinkId);
			parameters.Add("servingSize", entity.ServingSize);
			
			// Retrieve result from database and convert to entity class
			return await Connection.QueryFirstOrDefaultAsync<Menus>(query.ToString(), parameters);
		}

		public async Task<int> AddMenusAsync(Menus entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" insert into ");
			query.Append("  public.menus ");
			query.Append("  ( ");
			query.Append("   cinema_id, ");
			query.Append("   food_and_drink_id, ");
			query.Append("   serving_size, ");
			query.Append("   availability, ");
			query.Append("   price, ");
			query.Append("   created_timestamp, ");
			query.Append("   updated_timestamp ");
			query.Append("  ) ");
			query.Append(" values ");
			query.Append(" ( ");
			query.Append("  @cinemaId, ");
			query.Append("  @foodAndDrinkId, ");
			query.Append("  @servingSize, ");
			query.Append("  @availability, ");
			query.Append("  @price, ");
			query.Append("  @createdTimestamp, ");
			query.Append("  @updatedTimestamp ");
			query.Append(" ) ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@cinemaId", entity.CinemaId);
			parameters.Add("@foodAndDrinkId", entity.FoodAndDrinkId);
			parameters.Add("@servingSize", entity.ServingSize);
			parameters.Add("@availability", entity.Availability);
			parameters.Add("@price", entity.Price);
			parameters.Add("@createdTimestamp", entity.CreatedTimestamp);
			parameters.Add("@updatedTimestamp", entity.UpdatedTimestamp);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<int> UpdateMenusAsync(Menus entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" update ");
			query.Append("  public.menus ");
			query.Append(" set ");
			query.Append("  availability = @availability, ");
			query.Append("  price = @price, ");
			query.Append("  created_timestamp = @createdTimestamp, ");
			query.Append("  updated_timestamp = @updatedTimestamp ");
			query.Append(" where ");
			query.Append("  cinema_id = @cinemaId and  ");
			query.Append("  food_and_drink_id = @foodAndDrinkId and  ");
			query.Append("  serving_size = @servingSize ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@availability", entity.Availability);
			parameters.Add("@price", entity.Price);
			parameters.Add("@createdTimestamp", entity.CreatedTimestamp);
			parameters.Add("@updatedTimestamp", entity.UpdatedTimestamp);
			parameters.Add("@cinemaId", entity.CinemaId);
			parameters.Add("@foodAndDrinkId", entity.FoodAndDrinkId);
			parameters.Add("@servingSize", entity.ServingSize);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<int> RemoveMenusAsync(Menus entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" delete from ");
			query.Append("  public.menus ");
			query.Append(" where ");
			query.Append("  cinema_id = @cinemaId and  ");
			query.Append("  food_and_drink_id = @foodAndDrinkId and  ");
			query.Append("  serving_size = @servingSize ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@cinemaId", entity.CinemaId);
			parameters.Add("@foodAndDrinkId", entity.FoodAndDrinkId);
			parameters.Add("@servingSize", entity.ServingSize);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}
	}
}
