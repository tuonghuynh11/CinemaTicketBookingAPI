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
using System.Collections;

namespace CinemaTicketBooking.Server.Scaffolds.Models.DataLayer.Repositories
{
	public class PublicRepository : Repository, IPublicRepository
	{
		public PublicRepository(IDbConnection connection)
			: base(connection)
		{
		}

		public async Task<IEnumerable<Feedbacks>> SelectFeedbacksAsync(int pageSize = 10, int pageNumber = 1)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("     id Id, ");
			query.Append("   user_id UserId , ");
			query.Append("   content Content, ");
			query.Append("   created_timestamp CreatedTimestamp, ");
			query.Append("   updated_timestamp UpdatedTimestamp  ");
			query.Append(" from ");
			query.Append("   public.feedbacks ");
			query.Append(" order by ");
			query.Append("   id ");
			query.Append(" offset (@pageSize * (@pageNumber - 1)) rows ");
			query.Append(" fetch next @pageSize rows only ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add(  "@pageSize", pageSize  );
			parameters.Add("@pageNumber", pageNumber);
			
			// Retrieve result from database and convert to typed list
			return await Connection.QueryAsync<Feedbacks>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<Feedbacks>> SelectFeedbacksMatchingAsync(Feedbacks entity, string? additionalWhere = null, params (string parameterName, object? parameterValue)[] additionalParameters)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("     id Id, ");
			query.Append("   user_id UserId , ");
			query.Append("   content Content, ");
			query.Append("   created_timestamp CreatedTimestamp, ");
			query.Append("   updated_timestamp UpdatedTimestamp  ");
			query.Append(" from ");
			query.Append("   public.feedbacks ");
			query.Append(" where true ");
			if (entity.    Id != null)
			query.Append("   and      id =     @id ");
			if (entity.UserId != null)
			query.Append("   and user_id = @userId ");
			if (entity.Content != null)
			query.Append("   and content = @content  ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@id", entity.Id);
			parameters.Add( "@userId", entity. UserId);
			parameters.Add("@content", entity.Content);

			// Retrieve result from database and convert to entity class
			return await Connection.QueryAsync<Feedbacks>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> InsertFeedbacksJustOnceAsync(Feedbacks entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" insert into public.feedbacks ");
			query.Append("   ( ");
			query.Append("     user_id, ");
			query.Append("     content  ");
			query.Append("   ) ");
			query.Append(" values ");
			query.Append("   ( ");
			query.Append("     @userId , ");
			query.Append("     @content, ");
			query.Append("   ) ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add( "@userId", entity. UserId);
			parameters.Add("@content", entity.Content);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> UpdateFeedbacksMatchingAsync(Feedbacks entity, Feedbacks updatedValue)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" update ");
			query.Append("   public.feedbacks ");
			query.Append(" set ");
			query.Append("     created_timestamp = created_timestamp ");
			if (updatedValue. UserId != null)
			query.Append("   , user_id = @updatedUserId  ");
			if (updatedValue.Content != null)
			query.Append("   , content = @updatedContent ");
			if (updatedValue.Id != null)
			query.Append("   ,      id = @updatedId ");
			query.Append(" where true ");
			if (entity.Id != null)
			query.Append("   and      id =     @id  ");
			if (entity.UserId  != null)
			query.Append("   and user_id = @userId  ");
			if (entity.Content != null)
			query.Append("   and content = @content ");

			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add( "@userId", entity. UserId);
			parameters.Add("@content", entity.Content);
			parameters.Add("@id", entity.Id);

			parameters.Add( "@updatedUserId", updatedValue. UserId);
			parameters.Add("@updatedContent", updatedValue.Content);
			parameters.Add("@updatedId", updatedValue.Id);

			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> RemoveFeedbacksMatchingAsync(Feedbacks entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" delete from public.feedbacks where true ");
			if (entity.Id != null)
			query.Append("   and      id =     @id  ");
			if (entity.UserId  != null)
			query.Append("   and user_id = @userId  ");
			if (entity.Content != null)
			query.Append("   and content = @content ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add( "@userId", entity. UserId);
			parameters.Add("@content", entity.Content);
			parameters.Add("@id", entity.Id);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<Seats>> SelectSeatsAsync(int pageSize = 10, int pageNumber = 1)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("              id Id, ");
			query.Append("   auditorium_id AuditoriumId, ");
			query.Append("   row_number RowNumber, ");
			query.Append("   col_number ColNumber, ");
			query.Append("   created_timestamp CreatedTimestamp, ");
			query.Append("   updated_timestamp UpdatedTimestamp  ");
			query.Append(" from ");
			query.Append("   public.seats ");
			query.Append(" order by ");
			query.Append("   id ");
			query.Append(" offset (@pageSize * (@pageNumber - 1)) rows ");
			query.Append(" fetch next @pageSize rows only ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add(  "@pageSize", pageSize  );
			parameters.Add("@pageNumber", pageNumber);
			
			// Retrieve result from database and convert to typed list
			return await Connection.QueryAsync<Seats>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<Seats>> SelectSeatsMatchingAsync(Seats entity, string? additionalWhere = null, params (string parameterName, object? parameterValue)[] additionalParameters)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("              id Id, ");
			query.Append("   auditorium_id AuditoriumId, ");
			query.Append("   row_number RowNumber, ");
			query.Append("   col_number ColNumber, ");
			query.Append("   created_timestamp CreatedTimestamp, ");
			query.Append("   updated_timestamp UpdatedTimestamp  ");
			query.Append(" from ");
			query.Append("   public.seats ");
			query.Append(" where true ");
			if (entity.Id != null)
			query.Append("   and id = @id ");
			if (entity.AuditoriumId != null)
			query.Append("   and auditorium_id = @auditoriumId ");
			if (entity.RowNumber != null)
			query.Append("   and row_number = @rowNumber ");
			if (entity.ColNumber != null)
			query.Append("   and col_number = @colNumber ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("id", entity.Id);
			parameters.Add("@auditoriumId", entity.AuditoriumId);
			parameters.Add("@rowNumber", entity.RowNumber);
			parameters.Add("@colNumber", entity.ColNumber);

			// Retrieve result from database and convert to entity class
			return await Connection.QueryAsync<Seats>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> InsertSeatsJustOnceAsync(Seats entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" insert into public.seats ");
			query.Append("   ( ");
			query.Append("     auditorium_id, ");
			query.Append("     row_number, ");
			query.Append("     col_number  ");
			query.Append("   ) ");
			query.Append(" values ");
			query.Append("   ( ");
			query.Append("     @auditoriumId, ");
			query.Append("     @rowNumber, ");
			query.Append("     @colNumber  ");
			query.Append("   ) ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@auditoriumId", entity.AuditoriumId);
			parameters.Add("@rowNumber", entity.RowNumber);
			parameters.Add("@colNumber", entity.ColNumber);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> UpdateSeatsMatchingAsync(Seats entity, Seats updatedValue)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" update ");
			query.Append("   public.seats ");
			query.Append(" set ");
			query.Append("     created_timestamp = created_timestamp ");
			if (updatedValue.AuditoriumId != null)
			query.Append("   , auditorium_id = @updatedAuditoriumId ");
			if (updatedValue.RowNumber != null)
			query.Append("   , row_number = @updatedRowNumber ");
			if (updatedValue.ColNumber != null)
			query.Append("   , col_number = @updatedColNumber ");
			if (updatedValue.Id != null)
			query.Append("   , id = @updatedId ");
			query.Append(" where true ");
			if (entity.Id != null)
			query.Append("   and id = @id ");
			if (entity.AuditoriumId != null)
			query.Append("   and auditorium_id = @auditoriumId ");
			if (entity.RowNumber != null)
			query.Append("   and row_number = @rowNumber ");
			if (entity.ColNumber != null)
			query.Append("   and col_number = @colNumber ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@auditoriumId", entity.AuditoriumId);
			parameters.Add("@rowNumber", entity.RowNumber);
			parameters.Add("@colNumber", entity.ColNumber);
			parameters.Add("@id", entity.Id);

			parameters.Add("@updatedAuditoriumId", updatedValue.AuditoriumId);
			parameters.Add("@updatedRowNumber", updatedValue.RowNumber);
			parameters.Add("@updatedColNumber", updatedValue.ColNumber);
			parameters.Add("@updatedId", updatedValue.Id);

			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> RemoveSeatsMatchingAsync(Seats entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" delete from public.seats where true ");
			if (entity.Id != null)
			query.Append("   and id = @id ");
			if (entity.AuditoriumId != null)
			query.Append("   and auditorium_id = @auditoriumId ");
			if (entity.RowNumber != null)
			query.Append("   and row_number = @rowNumber ");
			if (entity.ColNumber != null)
			query.Append("   and col_number = @colNumber ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();

			// Add parameters to collection
			parameters.Add("@auditoriumId", entity.AuditoriumId);
			parameters.Add("@rowNumber", entity.RowNumber);
			parameters.Add("@colNumber", entity.ColNumber);
			parameters.Add("@id", entity.Id);

			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<FoodAndDrinks>> SelectFoodAndDrinksAsync(int pageSize = 10, int pageNumber = 1)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("       id Id, ");
			query.Append("   name Name, ");
			query.Append("   category Category, ");
			query.Append("   description Description, ");
			query.Append("   created_timestamp CreatedTimestamp, ");
			query.Append("   updated_timestamp UpdatedTimestamp, ");
			query.Append("   image_url ImageUrl ");
			query.Append(" from ");
			query.Append("   public.food_and_drinks ");
			query.Append(" order by ");
			query.Append("   id ");
			query.Append(" offset (@pageSize * (@pageNumber - 1)) rows ");
			query.Append(" fetch next @pageSize rows only ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add(  "@pageSize", pageSize  );
			parameters.Add("@pageNumber", pageNumber);
			
			// Retrieve result from database and convert to typed list
			return await Connection.QueryAsync<FoodAndDrinks>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<FoodAndDrinks>> SelectFoodAndDrinksMatchingAsync(FoodAndDrinks entity, string? additionalWhere = null, params (string parameterName, object? parameterValue)[] additionalParameters)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("       id Id, ");
			query.Append("   name Name, ");
			query.Append("   category Category, ");
			query.Append("   description Description, ");
			query.Append("   created_timestamp CreatedTimestamp, ");
			query.Append("   updated_timestamp UpdatedTimestamp, ");
			query.Append("   image_url ImageUrl ");
			query.Append(" from ");
			query.Append("   public.food_and_drinks ");
			query.Append(" where true ");
			if (entity.  Id != null)
			query.Append("   and   id =   @id ");
			if (entity.Name != null)
			query.Append("   and name = @name ");
			if (entity.Category != null)
			query.Append("   and category = @category ");
			if (entity.Description != null)
			query.Append("   and description = @description ");
			if (entity.ImageUrl != null)
			query.Append("   and image_url = @imageUrl ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@id", entity.Id);
			parameters.Add("@name", entity.Name);
			parameters.Add("@category", entity.Category);
			parameters.Add("@description", entity.Description);
			parameters.Add("@imageUrl", entity.ImageUrl);

			// Retrieve result from database and convert to entity class
			return await Connection.QueryAsync<FoodAndDrinks>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> InsertFoodAndDrinksJustOnceAsync(FoodAndDrinks entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" insert into public.food_and_drinks ");
			query.Append("   ( ");
			query.Append("     name, ");
			query.Append("     category, ");
			query.Append("     description, ");
			query.Append("     image_url ");
			query.Append("   ) ");
			query.Append(" values ");
			query.Append("   ( ");
			query.Append("     @name, ");
			query.Append("     @category, ");
			query.Append("     @description, ");
			query.Append("     @imageUrl  ");
			query.Append("   ) ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();

			// Add parameters to collection
			parameters.Add("@name", entity.Name);
			parameters.Add("@category", entity.Category);
			parameters.Add("@description", entity.Description);
			parameters.Add("@imageUrl", entity.ImageUrl);

			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> UpdateFoodAndDrinksMatchingAsync(FoodAndDrinks entity, FoodAndDrinks updatedValue)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" update ");
			query.Append("   public.food_and_drinks ");
			query.Append(" set ");
			query.Append("     created_timestamp = created_timestamp ");
			if (updatedValue.Id != null)
			query.Append("   , id = @updatedId");
			if (updatedValue.Name != null)
			query.Append("   , name = @updatedName ");
			if (updatedValue.Category != null)
			query.Append("   , category  = @updatedCategory ");
			if (updatedValue.Description != null)
			query.Append("   , description = @updatedDescription ");
			if (updatedValue.ImageUrl != null)
			query.Append("   , image_url = @updatedImageUrl ");
			query.Append(" where true ");
			if (entity.  Id != null)
			query.Append("   and   id =   @id ");
			if (entity.Name != null)
			query.Append("   and name = @name ");
			if (entity.Category != null)
			query.Append("   and category  = @category ");
			if (entity.Description != null)
			query.Append("   and description = @description ");
			if (entity.ImageUrl != null)
			query.Append("   and image_url = @imageUrl ");

			// Create parameters collection
			var parameters = new DynamicParameters();

			// Add parameters to collection
			parameters.Add("@name", entity.Name);
			parameters.Add("@category", entity.Category);
			parameters.Add("@description", entity.Description);
			parameters.Add("@imageUrl", entity.ImageUrl);
			parameters.Add("@id", entity.Id);

			parameters.Add("@updatedName", updatedValue.Name);
			parameters.Add("@updatedCategory", updatedValue.Category);
			parameters.Add("@updatedDescription", updatedValue.Description);
			parameters.Add("@updatedImageUrl", updatedValue.ImageUrl);
			parameters.Add("@updatedId", updatedValue.Id);

			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> RemoveFoodAndDrinksMatchingAsync(FoodAndDrinks entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" delete from public.food_and_drinks where true ");
			if (entity.  Id != null)
			query.Append("   and   id =   @id ");
			if (entity.Name != null)
			query.Append("   and name = @name ");
			if (entity.Category != null)
			query.Append("   and category  = @category ");
			if (entity.Description != null)
			query.Append("   and description = @description ");
			if (entity.ImageUrl != null)
			query.Append("   and image_url = @imageUrl ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();

			// Add parameters to collection
			parameters.Add("@name", entity.Name);
			parameters.Add("@category", entity.Category);
			parameters.Add("@description", entity.Description);
			parameters.Add("@imageUrl", entity.ImageUrl);
			parameters.Add("@id", entity.Id);

			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<Auditoriums>> SelectAuditoriumsAsync(int pageSize = 10, int pageNumber = 1)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("       id Id, ");
			query.Append("   name Name, ");
			query.Append("   cinema_id CinemaId, ");
			query.Append("   updated_timestamp UpdatedTimestamp, ");
			query.Append("   created_timestamp CreatedTimestamp  ");
			query.Append(" from ");
			query.Append("   public.auditoriums ");
			query.Append(" order by ");
			query.Append("   id ");
			query.Append(" offset (@pageSize * (@pageNumber - 1)) rows ");
			query.Append(" fetch next @pageSize rows only ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add(  "@pageSize", pageSize  );
			parameters.Add("@pageNumber", pageNumber);
			
			// Retrieve result from database and convert to typed list
			return await Connection.QueryAsync<Auditoriums>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<Auditoriums>> SelectAuditoriumsMatchingAsync(Auditoriums entity, string? additionalWhere = null, params (string parameterName, object? parameterValue)[] additionalParameters)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("       id Id, ");
			query.Append("   name Name, ");
			query.Append("   cinema_id CinemaId, ");
			query.Append("   updated_timestamp UpdatedTimestamp, ");
			query.Append("   created_timestamp CreatedTimestamp ");
			query.Append(" from ");
			query.Append("   public.auditoriums ");
			query.Append(" where true ");
			if (entity.  Id != null)
			query.Append("   and   id = @id   ");
			if (entity.Name != null)
			query.Append("   and name = @name ");
			if (entity.CinemaId != null)
			query.Append("   and cinema_id = @cinemaId ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@id"  , entity.  Id);
			parameters.Add("@name", entity.Name);
			parameters.Add("@cinemaId", entity.CinemaId);

			// Retrieve result from database and convert to entity class
			return await Connection.QueryAsync<Auditoriums>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> InsertAuditoriumsJustOnceAsync(Auditoriums entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" insert into public.auditoriums ");
			query.Append("   ( ");
			query.Append("     name,     ");
			query.Append("     cinema_id ");
			query.Append("   ) ");
			query.Append(" values ");
			query.Append("   ( ");
			query.Append("     @name,    ");
			query.Append("     @cinemaId ");
			query.Append("   ) ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@name"    , entity.Name);
			parameters.Add("@cinemaId", entity.CinemaId);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> UpdateAuditoriumsMatchingAsync(Auditoriums entity, Auditoriums updatedValue)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" update ");
			query.Append("   public.auditoriums ");
			query.Append(" set ");
			query.Append("     created_timestamp = created_timestamp ");
			if (updatedValue.Name != null)
			query.Append("   , name = @updatedName ");
			if (updatedValue.CinemaId != null)
			query.Append("   , cinema_id = @updatedCinemaId ");
			if (updatedValue.      Id != null)
			query.Append("   ,        id =       @updatedId ");
			query.Append(" where true ");
			if (entity.  Id != null)
			query.Append("   and   id = @id   ");
			if (entity.Name != null)
			query.Append("   and name = @name ");
			if (entity.CinemaId != null)
			query.Append("   and cinema_id = @cinemaId ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@name", entity.Name);
			parameters.Add("@cinemaId", entity.CinemaId);
			parameters.Add(      "@id", entity.Id);

			parameters.Add("@updatedName", updatedValue.Name);
			parameters.Add("@updatedCinemaId", updatedValue.CinemaId);
			parameters.Add(      "@updatedId", updatedValue.Id);

			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> RemoveAuditoriumsMatchingAsync(Auditoriums entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" delete from public.auditoriums where true ");
			if (entity.  Id != null)
			query.Append("   and   id = @id   ");
			if (entity.Name != null)
			query.Append("   and name = @name ");
			if (entity.CinemaId != null)
			query.Append("   and cinema_id = @cinemaId ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@name", entity.Name);
			parameters.Add("@cinemaId", entity.CinemaId);
			parameters.Add(      "@id", entity.Id);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<Tickets>> SelectTicketsAsync(int pageSize = 10, int pageNumber = 1)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("            id Id, ");
			query.Append("   showtime_id ShowtimeId, ");
			query.Append("   bill_id BillId, ");
			query.Append("   created_timestamp CreatedTimestamp, ");
			query.Append("   updated_timestamp UpdatedTimestamp, ");
			query.Append("     price  Price  ");
			query.Append(" from ");
			query.Append("   public.tickets ");
			query.Append(" order by ");
			query.Append("   id ");
			query.Append(" offset (@pageSize * (@pageNumber - 1)) rows ");
			query.Append(" fetch next @pageSize rows only ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add(  "@pageSize", pageSize  );
			parameters.Add("@pageNumber", pageNumber);
			
			// Retrieve result from database and convert to typed list
			return await Connection.QueryAsync<Tickets>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<Tickets>> SelectTicketsMatchingAsync(Tickets entity, string? additionalWhere = null, params (string parameterName, object? parameterValue)[] additionalParameters)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("            id Id, ");
			query.Append("   showtime_id ShowtimeId, ");
			query.Append("   bill_id BillId, ");
			query.Append("   created_timestamp CreatedTimestamp, ");
			query.Append("   updated_timestamp UpdatedTimestamp, ");
			query.Append("     price  Price  ");
			query.Append(" from ");
			query.Append("   public.tickets ");
			query.Append(" where true ");
			if (entity.Price != null)
			query.Append("   and      price = @price ");
			if (entity.        Id != null)
			query.Append("   and      id = @id ");
			if (entity.ShowtimeId != null)
			query.Append("   and showtime_id = @showtimeId ");
			if (entity.    BillId != null)
			query.Append("   and     bill_id =     @billId ");

			// Create parameters collection
			var parameters = new DynamicParameters();

			// Add parameters to collection
			parameters.Add("@price", entity.Price);
			parameters.Add(          "@id", entity.Id);
			parameters.Add(  "@showtimeId", entity.ShowtimeId);
			parameters.Add(      "@billId", entity.BillId);

			// Retrieve result from database and convert to entity class
			return await Connection.QueryAsync<Tickets>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> InsertTicketsJustOnceAsync(Tickets entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" insert into public.tickets ");
			query.Append("   ( ");
			query.Append("       showtime_id, ");
			query.Append("           bill_id, ");
			query.Append("       price  ");
			query.Append("   ) ");
			query.Append(" values ");
			query.Append("   ( ");
			query.Append("       @showtimeId, ");
			query.Append("           @billId, ");
			query.Append("       @price  ");
			query.Append("   ) ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add(  "@showtimeId", entity.ShowtimeId);
			parameters.Add(      "@billId", entity.    BillId);
			parameters.Add("@price", entity.Price);

			// Execute query in database
			return await Connection.ExecuteScalarAsync<long>(new CommandDefinition(query.Append(" returning id ").ToString(), parameters));
		}

		public async Task<long> UpdateTicketsMatchingAsync(Tickets entity, Tickets updatedValue)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" update ");
			query.Append("   public.tickets ");
			query.Append(" set ");
			query.Append("     created_timestamp = created_timestamp ");
			if (updatedValue.        Id != null)
			query.Append("   ,            id =           @updatedId ");
			if (updatedValue.ShowtimeId != null)
			query.Append("   ,   showtime_id =   @updatedShowtimeId ");
			if (updatedValue.    BillId != null)
			query.Append("   ,       bill_id =       @updatedBillId ");
			if (updatedValue.Price != null)
			query.Append("   ,   price =   @updatedPrice ");
			query.Append(" where true ");
			if (entity.Price != null)
			query.Append("   and      price = @price ");
			if (entity.        Id != null)
			query.Append("   and          id =         @id ");
			if (entity.ShowtimeId != null)
			query.Append("   and showtime_id = @showtimeId ");
			if (entity.    BillId != null)
			query.Append("   and     bill_id =     @billId ");
						
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add(  "@showtimeId", entity.  ShowtimeId);
			parameters.Add(      "@billId", entity.      BillId);
			parameters.Add(          "@id", entity.Id);
			parameters.Add("@price", entity.Price);

			parameters.Add(  "@updatedShowtimeId", updatedValue.ShowtimeId);
			parameters.Add(      "@updatedBillId", updatedValue.    BillId);
			parameters.Add("@updatedId"   , updatedValue.Id);
			parameters.Add("@updatedPrice", updatedValue.Price);

			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> RemoveTicketsMatchingAsync(Tickets entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" delete from public.tickets where true ");
			if (entity. Price != null)
			query.Append("   and      price = @price ");
			if (entity.    Id != null)
			query.Append("   and            id =           @id ");
			if (entity.ShowtimeId != null)
			query.Append("   and   showtime_id =   @showtimeId ");
			if (entity.    BillId != null)
			query.Append("   and       bill_id =       @billId ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add(  "@showtimeId", entity.  ShowtimeId);
			parameters.Add(      "@billId", entity.      BillId);
			parameters.Add(          "@id", entity.Id);
			parameters.Add("@price", entity.Price);

			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<Showtimes>> SelectShowtimesAsync(int pageSize = 10, int pageNumber = 1)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("         id Id, ");
			query.Append("   movie_id MovieId, ");
			query.Append("   start_time StartTime, ");
			query.Append("   cease_time CeaseTime, ");
			query.Append("   date Date, ");
			query.Append("   auditorium_id AuditoriumId, ");
			query.Append("   price Price, ");
			query.Append("   status Status, ");
			query.Append("   created_timestamp CreatedTimestamp, ");
			query.Append("   updated_timestamp UpdatedTimestamp  ");
			query.Append(" from ");
			query.Append("   public.showtimes ");
			query.Append(" order by ");
			query.Append("   id ");
			query.Append(" offset (@pageSize * (@pageNumber - 1)) rows ");
			query.Append(" fetch next @pageSize rows only ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add(  "@pageSize", pageSize  );
			parameters.Add("@pageNumber", pageNumber);
			
			// Retrieve result from database and convert to typed list
			return await Connection.QueryAsync<Showtimes>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<Showtimes>> SelectShowtimesMatchingAsync(Showtimes entity, string? additionalWhere = null, params (string parameterName, object? parameterValue)[] additionalParameters)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("         id Id, ");
			query.Append("   movie_id MovieId, ");
			query.Append("   start_time StartTime, ");
			query.Append("   cease_time CeaseTime, ");
			query.Append("   date Date, ");
			query.Append("   auditorium_id AuditoriumId, ");
			query.Append("   price Price, ");
			query.Append("   status Status, ");
			query.Append("   created_timestamp CreatedTimestamp, ");
			query.Append("   updated_timestamp UpdatedTimestamp  ");
			query.Append(" from ");
			query.Append("   public.showtimes ");
			query.Append(" where true ");
			if (entity.Id != null)
			query.Append("   and id = @id ");
			if (entity.MovieId != null)
			query.Append("   and movie_id = @movieId ");
			if (entity.StartTime != null)
			query.Append("   and start_time = @startTime ");
			if (entity.CeaseTime != null)
			query.Append("   and cease_time = @ceaseTime ");
			if (entity.Date != null)
			query.Append("   and date = @date ");
			if (entity.AuditoriumId != null)
			query.Append("   and auditorium_id = @auditoriumId ");
			if (entity.Price  != null)
			query.Append("   and price  = @price  ");
			if (entity.Status != null)
			query.Append("   and status = @status ");
			if (additionalWhere != null)
			query.Append($"  and {additionalWhere} ");

			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@id", entity.Id);
			parameters.Add("@movieId", entity.MovieId);
			parameters.Add("@startTime", entity.StartTime);
			parameters.Add("@ceaseTime", entity.CeaseTime);
			parameters.Add("@date", entity.Date);
			parameters.Add("@auditoriumId", entity.AuditoriumId);
			parameters.Add("@price" , entity.Price );
			parameters.Add("@status", entity.Status);
			foreach ((string parameterName, object? parameterValue) in additionalParameters)
			{
				parameters.Add(parameterName, parameterValue);
			}

			// Retrieve result from database and convert to entity class
			return await Connection.QueryAsync<Showtimes>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> InsertShowtimesJustOnceAsync(Showtimes entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" insert into public.showtimes ");
			query.Append("   ( ");
			query.Append("     movie_id, ");
			query.Append("     start_time, ");
			query.Append("     cease_time, ");
			query.Append("     date, ");
			query.Append("     auditorium_id, ");
			query.Append("     price,  ");
			query.Append("     status  ");
			query.Append("   ) ");
			query.Append(" values ");
			query.Append("   ( ");
			query.Append("     @movieId, ");
			query.Append("     @startTime, ");
			query.Append("     @ceaseTime, ");
			query.Append("     @date, ");
			query.Append("     @auditoriumId, ");
			query.Append("     @price,  ");
			query.Append("     @status  ");
			query.Append("   ) ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@movieId", entity.MovieId);
			parameters.Add("@startTime", entity.StartTime);
			parameters.Add("@ceaseTime", entity.CeaseTime);
			parameters.Add("@date", entity.Date);
			parameters.Add("@auditoriumId", entity.AuditoriumId);
			parameters.Add("@price" , entity.Price );
			parameters.Add("@status", entity.Status);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> UpdateShowtimesMatchingAsync(Showtimes entity, Showtimes updatedValue)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" update ");
			query.Append("   public.showtimes ");
			query.Append(" set ");
			query.Append("     created_timestamp = created_timestamp ");
			if (updatedValue.MovieId != null)
			query.Append("   , movie_id = @updatedMovieId ");
			if (updatedValue.StartTime != null)
			query.Append("   , start_time = @updatedStartTime ");
			if (updatedValue.CeaseTime != null)
			query.Append("   , cease_time = @updatedCeaseTime ");
			if (updatedValue.Date != null)
			query.Append("   , date = @updatedDate ");
			if (updatedValue.AuditoriumId != null)
			query.Append("   , auditorium_id = @updatedAuditoriumId ");
			if (updatedValue.Price  != null)
			query.Append("   , price  = @updatedPrice  ");
			if (updatedValue.Status != null)
			query.Append("   , status = @updatedStatus ");
			if (updatedValue.Id != null)
			query.Append("   , id = @updatedId ");
			query.Append(" where true ");
			if (entity.Id != null)
			query.Append("   and id = @id ");
			if (entity.MovieId != null)
			query.Append("   and movie_id = @movieId ");
			if (entity.StartTime != null)
			query.Append("   and start_time = @startTime ");
			if (entity.CeaseTime != null)
			query.Append("   and cease_time = @ceaseTime ");
			if (entity.Date != null)
			query.Append("   and date = @date ");
			if (entity.AuditoriumId != null)
			query.Append("   and auditorium_id = @auditoriumId ");
			if (entity.Price  != null)
			query.Append("   and price  = @price  ");
			if (entity.Status != null)
			query.Append("   and status = @status ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@movieId", entity.MovieId);
			parameters.Add("@startTime", entity.StartTime);
			parameters.Add("@ceaseTime", entity.CeaseTime);
			parameters.Add("@date", entity.Date);
			parameters.Add("@auditoriumId", entity.AuditoriumId);
			parameters.Add("@price" , entity.Price );
			parameters.Add("@status", entity.Status);
			parameters.Add("@id", entity.Id);
	
			parameters.Add("@updatedMovieId", updatedValue.MovieId);
			parameters.Add("@updatedStartTime", updatedValue.StartTime);
			parameters.Add("@updatedCeaseTime", updatedValue.CeaseTime);
			parameters.Add("@updatedDate", updatedValue.Date);
			parameters.Add("@updatedAuditoriumId", updatedValue.AuditoriumId);
			parameters.Add("@updatedPrice" , updatedValue.Price );
			parameters.Add("@updatedStatus", updatedValue.Status);
			parameters.Add("@updatedId", updatedValue.Id);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> RemoveShowtimesMatchingAsync(Showtimes entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" delete from public.showtimes where true ");
			if (entity.Id != null)
			query.Append("   and id = @id ");
			if (entity.MovieId != null)
			query.Append("   and movie_id = @movieId ");
			if (entity.StartTime != null)
			query.Append("   and start_time = @startTime ");
			if (entity.CeaseTime != null)
			query.Append("   and cease_time = @ceaseTime ");
			if (entity.Date != null)
			query.Append("   and date = @date ");
			if (entity.AuditoriumId != null)
			query.Append("   and auditorium_id = @auditoriumId ");
			if (entity.Price  != null)
			query.Append("   and price  = @price  ");
			if (entity.Status != null)
			query.Append("   and status = @status ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@movieId", entity.MovieId);
			parameters.Add("@startTime", entity.StartTime);
			parameters.Add("@ceaseTime", entity.CeaseTime);
			parameters.Add("@date", entity.Date);
			parameters.Add("@auditoriumId", entity.AuditoriumId);
			parameters.Add("@price" , entity.Price );
			parameters.Add("@status", entity.Status);
			parameters.Add("@id", entity.Id);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<Reservations>> SelectReservationsAsync(int pageSize = 10, int pageNumber = 1)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("   showtime_id ShowtimeId, ");
			query.Append("   seat_id SeatId, ");
			query.Append("   ticket_id TicketId, ");
			query.Append("   created_timestamp CreatedTimestamp, ");
			query.Append("   updated_timestamp UpdatedTimestamp  ");
			query.Append(" from ");
			query.Append("   public.reservations ");
			query.Append(" order by ");
			query.Append("   showtime_id, ");
			query.Append("       seat_id  ");
			query.Append(" offset (@pageSize * (@pageNumber - 1)) rows ");
			query.Append(" fetch next @pageSize rows only ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("  @pageSize", pageSize  );
			parameters.Add("@pageNumber", pageNumber);
			
			// Retrieve result from database and convert to typed list
			return await Connection.QueryAsync<Reservations>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<Reservations>> SelectReservationsMatchingAsync(Reservations entity, string? additionalWhere = null, params (string parameterName, object? parameterValue)[] additionalParameters)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("   showtime_id ShowtimeId, ");
			query.Append("   seat_id SeatId, ");
			query.Append("   ticket_id TicketId, ");
			query.Append("   created_timestamp CreatedTimestamp, ");
			query.Append("   updated_timestamp UpdatedTimestamp  ");
			query.Append(" from ");
			query.Append("   public.reservations ");
			query.Append(" where true ");
			if (entity.ShowtimeId != null)
			query.Append("   and showtime_id = @showtimeId ");
			if (entity.SeatId != null)
			query.Append("   and seat_id = @seatId ");
			if (entity.TicketId != null)
			query.Append("   and ticket_id = @ticketId ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@showtimeId", entity.ShowtimeId);
			parameters.Add("@seatId", entity.SeatId);
			parameters.Add("@ticketId", entity.TicketId);
			
			// Retrieve result from database and convert to entity class
			return await Connection.QueryAsync<Reservations>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> InsertReservationsJustOnceAsync(Reservations entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" insert into public.reservations ");
			query.Append("   ( ");
			query.Append("     showtime_id, ");
			query.Append("     seat_id,  ");
			query.Append("     ticket_id ");
			query.Append("   ) ");
			query.Append(" values ");
			query.Append("   ( ");
			query.Append("     @showtimeId, ");
			query.Append("     @seatId,  ");
			query.Append("     @ticketId ");
			query.Append("   ) ");

			// Create parameters collection
			var parameters = new DynamicParameters();

			// Add parameters to collection
			parameters.Add("@showtimeId", entity.ShowtimeId);
			parameters.Add("@seatId", entity.SeatId);
			parameters.Add("@ticketId", entity.TicketId);

			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> UpdateReservationsMatchingAsync(Reservations entity, Reservations updatedValue)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" update ");
			query.Append("   public.reservations ");
			query.Append(" set ");
			query.Append("     created_timestamp = created_timestamp ");
			if (updatedValue.TicketId != null)
			query.Append("   , ticket_id = @updatedTicketId ");
			if (updatedValue.ShowtimeId != null)
			query.Append("   , showtime_id = @updatedShowtimeId ");
			if (updatedValue.SeatId != null)
			query.Append("   , seat_id = @updatedSeatId ");
			query.Append(" where true ");
			if (entity.ShowtimeId != null)
			query.Append("   and showtime_id = @showtimeId ");
			if (entity.SeatId != null)
			query.Append("   and seat_id = @seatId ");
			if (entity.TicketId != null)
			query.Append("   and ticket_id = @ticketId ");

			// Create parameters collection
			var parameters = new DynamicParameters();

			// Add parameters to collection
			parameters.Add("@ticketId", entity.TicketId);
			parameters.Add("@showtimeId", entity.ShowtimeId);
			parameters.Add("@seatId", entity.SeatId);

			parameters.Add("@updatedTicketId", updatedValue.TicketId);
			parameters.Add("@updatedShowtimeId", updatedValue.ShowtimeId);
			parameters.Add("@updatedSeatId", updatedValue.SeatId);

			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> RemoveReservationsMatchingAsync(Reservations entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" delete from public.reservations where true ");
			if (entity.ShowtimeId != null)
			query.Append("   and showtime_id = @showtimeId ");
			if (entity.SeatId != null)
			query.Append("   and seat_id = @seatId ");
			if (entity.TicketId != null)
			query.Append("   and ticket_id = @ticketId ");

			// Create parameters collection
			var parameters = new DynamicParameters();

			// Add parameters to collection
			parameters.Add("@ticketId", entity.TicketId);
			parameters.Add("@showtimeId", entity.ShowtimeId);
			parameters.Add("@seatId", entity.SeatId);

			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<Memberships>> SelectMembershipsAsync(int pageSize = 10, int pageNumber = 1)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("       id Id, ");
			query.Append("   name Name, ");
			query.Append("   created_timestamp CreatedTimestamp, ");
			query.Append("   updated_timestamp UpdatedTimestamp  ");
			query.Append(" from ");
			query.Append("   public.memberships ");
			query.Append(" order by ");
			query.Append("   id ");
			query.Append(" offset (@pageSize * (@pageNumber - 1)) rows ");
			query.Append(" fetch next @pageSize rows only ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add(  "@pageSize", pageSize  );
			parameters.Add("@pageNumber", pageNumber);
			
			// Retrieve result from database and convert to typed list
			return await Connection.QueryAsync<Memberships>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<Memberships>> SelectMembershipsMatchingAsync(Memberships entity, string? additionalWhere = null, params (string parameterName, object? parameterValue)[] additionalParameters)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("       id Id, ");
			query.Append("   name Name, ");
			query.Append("   created_timestamp CreatedTimestamp, ");
			query.Append("   updated_timestamp UpdatedTimestamp  ");
			query.Append(" from ");
			query.Append("   public.memberships ");
			query.Append(" where true ");
			if (entity.  Id != null)
			query.Append("   and   id = @id   ");
			if (entity.Name != null)
			query.Append("   and name = @name ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add(  "@id", entity.Id  );
			parameters.Add("@name", entity.Name);
			
			// Retrieve result from database and convert to entity class
			return await Connection.QueryAsync<Memberships>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> InsertMembershipsJustOnceAsync(Memberships entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" insert into public.memberships ");
			query.Append("   ( ");
			query.Append("     name ");
			query.Append("   ) ");
			query.Append(" values ");
			query.Append("   ( ");
			query.Append("    @name ");
			query.Append("   ) ");

			// Create parameters collection
			var parameters = new DynamicParameters();

			// Add parameters to collection
			parameters.Add("@name", entity.Name);

			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> UpdateMembershipsMatchingAsync(Memberships entity, Memberships updatedValue)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" update ");
			query.Append("   public.memberships ");
			query.Append(" set ");
			query.Append("     created_timestamp = created_timestamp ");
			if (updatedValue.Name != null)
			query.Append("   , name = @updatedName ");
			if (updatedValue.  Id != null)
			query.Append("   ,   id = @updatedId   ");
			query.Append(" where true ");
			if (entity.Name != null)
			query.Append("   and name = @name ");
			if (entity.  Id != null)
			query.Append("   and   id = @id   ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@name", entity.Name);
			parameters.Add("@id"  , entity.Id  );

			parameters.Add("@updatedName", updatedValue.Name);
			parameters.Add("@updatedId"  , updatedValue.Id  );

			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> RemoveMembershipsMatchingAsync(Memberships entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" delete from public.memberships where true ");
			if (entity.Name != null)
			query.Append("   and name = @name ");
			if (entity.  Id != null)
			query.Append("   and   id = @id   ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@name", entity.Name);
			parameters.Add("@id"  , entity.Id  );
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<Users>> SelectUsersAsync(int pageSize = 10, int pageNumber = 1)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("         id Id, ");
			query.Append("   username Username, ");
			query.Append("   password Password, ");
			query.Append("   full_name FullName, ");
			query.Append("   phone_number PhoneNumber, ");
			query.Append("   address Address, ");
			query.Append("   sex Sex, ");
			query.Append("   created_timestamp CreatedTimestamp, ");
			query.Append("   updated_timestamp UpdatedTimestamp  ");
			query.Append(" from ");
			query.Append("   public.users ");
			query.Append(" order by ");
			query.Append("   id ");
			query.Append(" offset (@pageSize * (@pageNumber - 1)) rows ");
			query.Append(" fetch next @pageSize rows only ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("  @pageSize", pageSize  );
			parameters.Add("@pageNumber", pageNumber);
			
			// Retrieve result from database and convert to typed list
			return await Connection.QueryAsync<Users>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<Users>> SelectUsersMatchingAsync(Users entity, string? additionalWhere = null, params (string parameterName, object? parameterValue)[] additionalParameters)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("         id Id, ");
			query.Append("   username Username, ");
			query.Append("   password Password, ");
			query.Append("   full_name FullName, ");
			query.Append("   phone_number PhoneNumber, ");
			query.Append("   address Address, ");
			query.Append("   sex Sex, ");
			query.Append("   created_timestamp CreatedTimestamp, ");
			query.Append("   updated_timestamp UpdatedTimestamp  ");
			query.Append(" from ");
			query.Append("   public.users ");
			query.Append(" where true ");
			if (entity.Id != null)
			query.Append("   and id = @id ");
			if (entity.Username != null)
			query.Append("   and username = @username ");
			if (entity.Password != null)
			query.Append("   and password = @password ");
			if (entity.FullName != null)
			query.Append("   and full_name = @fullName ");
			if (entity.PhoneNumber != null)
			query.Append("   and phone_number = @phoneNumber ");
			if (entity.Address != null)
			query.Append("   and address = @address ");
			if (entity.Sex != null)
			query.Append("   and sex = @sex ");

			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@id", entity.Id);
			parameters.Add("@username", entity.Username);
			parameters.Add("@password", entity.Password);
			parameters.Add("@fullName", entity.FullName);
			parameters.Add("@phoneNumber", entity.PhoneNumber);
			parameters.Add("@address", entity.Address);
			parameters.Add("@sex", entity.Sex);

			// Retrieve result from database and convert to entity class
			return await Connection.QueryAsync<Users>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> InsertUsersJustOnceAsync(Users entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" insert into public.users ");
			query.Append("   ( ");
			query.Append("     username, ");
			query.Append("     password, ");
			query.Append("     full_name, ");
			query.Append("     phone_number, ");
			query.Append("     address, ");
			query.Append("     sex ");
            query.Append("     role ");
            query.Append("   ) ");
			query.Append(" values ");
			query.Append("   ( ");
			query.Append("     @username, ");
			query.Append("     @password, ");
			query.Append("     @fullName, ");
			query.Append("     @phoneNumber, ");
			query.Append("     @address, ");
			query.Append("     @sex ");
            query.Append("     @role ");
            query.Append("   ) ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();

			// Add parameters to collection
			parameters.Add("@username", entity.Username);
			parameters.Add("@password", entity.Password);
			parameters.Add("@fullName", entity.FullName);
			parameters.Add("@phoneNumber", entity.PhoneNumber);
			parameters.Add("@address", entity.Address);
			parameters.Add("@sex", entity.Sex);
            parameters.Add("@role", entity.Role);

            // Execute query in database
            return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> UpdateUsersMatchingAsync(Users entity, Users updatedValue)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" update ");
			query.Append("   public.users ");
			query.Append(" set ");
			query.Append("     created_timestamp = created_timestamp ");
			if (updatedValue.Username != null)
			query.Append("   , username = @updatedUsername ");
			if (updatedValue.Password != null)
			query.Append("   , password = @updatedPassword ");
			if (updatedValue.FullName != null)
			query.Append("   , full_name = @updatedFullName       ");
			if (updatedValue.PhoneNumber != null)
			query.Append("   , phone_number = @updatedPhoneNumber ");
			if (updatedValue.Address != null)
			query.Append("   , address = @updatedAddress ");
			if (updatedValue.Sex != null)
			query.Append("   , sex = @updatedSex ");
			if (updatedValue.Id != null)
			query.Append("   ,  id = @updatedId  ");
			query.Append(" where true ");
			if (entity.Id != null)
			query.Append("   and id = @id ");
			if (entity.Username != null)
			query.Append("   and username = @username ");
			if (entity.Password != null)
			query.Append("   and password = @password ");
			if (entity.FullName != null)
			query.Append("   and full_name = @fullName ");
			if (entity.PhoneNumber != null)
			query.Append("   and phone_number = @phoneNumber ");
			if (entity.Address != null)
			query.Append("   and address = @address ");
			if (entity.Sex != null)
			query.Append("   and sex = @sex ");

			// Create parameters collection
			var parameters = new DynamicParameters();

			// Add parameters to collection
			parameters.Add("@id", entity.Id);
			parameters.Add("@username", entity.Username);
			parameters.Add("@password", entity.Password);
			parameters.Add("@fullName", entity.FullName);
			parameters.Add("@phoneNumber", entity.PhoneNumber);
			parameters.Add("@address", entity.Address);
			parameters.Add("@sex", entity.Sex);

			parameters.Add("@updatedId", updatedValue.Id);
			parameters.Add("@updatedUsername", updatedValue.Username);
			parameters.Add("@updatedPassword", updatedValue.Password);
			parameters.Add("@updatedFullName", updatedValue.FullName);
			parameters.Add("@updatedPhoneNumber", updatedValue.PhoneNumber);
			parameters.Add("@updatedAddress", updatedValue.Address);
			parameters.Add("@updatedSex", updatedValue.Sex);

			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> RemoveUsersMatchingAsync(Users entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" delete from public.users where true ");
			if (entity.Id != null)
			query.Append("   and id = @id ");
			if (entity.Username != null)
			query.Append("   and username = @username ");
			if (entity.Password != null)
			query.Append("   and password = @password ");
			if (entity.FullName != null)
			query.Append("   and full_name = @fullName ");
			if (entity.PhoneNumber != null)
			query.Append("   and phone_number = @phoneNumber ");
			if (entity.Address != null)
			query.Append("   and address = @address ");
			if (entity.Sex != null)
			query.Append("   and sex = @sex ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();

			// Add parameters to collection
			parameters.Add("@id", entity.Id);
			parameters.Add("@username", entity.Username);
			parameters.Add("@password", entity.Password);
			parameters.Add("@fullName", entity.FullName);
			parameters.Add("@phoneNumber", entity.PhoneNumber);
			parameters.Add("@address", entity.Address);
			parameters.Add("@sex", entity.Sex);

			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<Movies>> SelectMoviesAsync(int pageSize = 10, int pageNumber = 1)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("   adult Adult, ");
			query.Append("   backdrop_path BackdropPath, ");
			query.Append("   belongs_to_collection BelongsToCollection, ");
			query.Append("   budget Budget, ");
			query.Append("   genres Genres, ");
			query.Append("   homepage Homepage, ");
			query.Append("   id Id, ");
			query.Append("   imdb_id ImdbId, ");
			query.Append("   original_language OriginalLanguage, ");
			query.Append("   original_title OriginalTitle, ");
			query.Append("   overview Overview, ");
			query.Append("   popularity Popularity, ");
			query.Append("   poster_path PosterPath, ");
			query.Append("   production_companies ProductionCompanies, ");
			query.Append("   production_countries ProductionCountries, ");
			query.Append("   release_date ReleaseDate, ");
			query.Append("   revenue Revenue, ");
			query.Append("   runtime Runtime, ");
			query.Append("   spoken_languages SpokenLanguages, ");
			query.Append("   status Status, ");
			query.Append("   tagline Tagline, ");
			query.Append("   title Title, ");
			query.Append("   video Video, ");
			query.Append("   vote_average VoteAverage, ");
			query.Append("   vote_count VoteCount, ");
			query.Append("   casting Casting, ");
			query.Append("   directors Directors, ");
			query.Append("   created_timestamp CreatedTimestamp, ");
			query.Append("   updated_timestamp UpdatedTimestamp ");
			query.Append(" from ");
			query.Append("   public.movies ");
			query.Append(" order by ");
			query.Append("   id ");
			query.Append(" offset (@pageSize * (@pageNumber - 1)) rows ");
			query.Append(" fetch next @pageSize rows only ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add(  "@pageSize", pageSize  );
			parameters.Add("@pageNumber", pageNumber);
			
			// Retrieve result from database and convert to typed list
			return await Connection.QueryAsync<Movies>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<Movies>> SelectMoviesMatchingAsync(Movies entity, string? additionalWhere = null, params (string parameterName, object? parameterValue)[] additionalParameters)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("   adult Adult, ");
			query.Append("   backdrop_path BackdropPath, ");
			query.Append("   belongs_to_collection BelongsToCollection, ");
			query.Append("   budget Budget, ");
			query.Append("   genres Genres, ");
			query.Append("   homepage Homepage, ");
			query.Append("   id Id, ");
			query.Append("   imdb_id ImdbId, ");
			query.Append("   original_language OriginalLanguage, ");
			query.Append("   original_title OriginalTitle, ");
			query.Append("   overview Overview, ");
			query.Append("   popularity Popularity, ");
			query.Append("   poster_path PosterPath, ");
			query.Append("   production_companies ProductionCompanies, ");
			query.Append("   production_countries ProductionCountries, ");
			query.Append("   release_date ReleaseDate, ");
			query.Append("   revenue Revenue, ");
			query.Append("   runtime Runtime, ");
			query.Append("   spoken_languages SpokenLanguages, ");
			query.Append("   status Status, ");
			query.Append("   tagline Tagline, ");
			query.Append("   title Title, ");
			query.Append("   video Video, ");
			query.Append("   vote_average VoteAverage, ");
			query.Append("   vote_count VoteCount, ");
			query.Append("   casting Casting, ");
			query.Append("   directors Directors, ");
			query.Append("   created_timestamp CreatedTimestamp, ");
			query.Append("   updated_timestamp UpdatedTimestamp ");
			query.Append(" from ");
			query.Append("   public.movies ");
			query.Append(" where true ");
			if (entity.Adult != null)
			query.Append("   and adult = @adult ");
			if (entity.BackdropPath != null)
			query.Append("   and backdrop_path = @backdropPath ");
			if (entity.BelongsToCollection != null)
			query.Append("   and belongs_to_collection = @belongsToCollection ");
			if (entity.Budget != null)
			query.Append("   and budget = @budget ");
			if (entity.Genres != null)
			query.Append("   and genres = @genres ");
			if (entity.Homepage != null)
			query.Append("   and homepage = @homepage ");
			if (entity.Id != null)
			query.Append("   and id = @id ");
			if (entity.ImdbId != null)
			query.Append("   and imdb_id = @imdbId ");
			if (entity.OriginalLanguage != null)
			query.Append("   and original_language = @originalLanguage ");
			if (entity.Title != null)
			query.Append("   and original_title = @originalTitle ");
			if (entity.Overview != null)
			query.Append("   and overview = @overview ");
			if (entity.Popularity != null)
			query.Append("   and popularity  = @popularity ");
			if (entity.PosterPath != null)
			query.Append("   and poster_path = @posterPath ");
			if (entity.ProductionCompanies != null)
			query.Append("   and production_companies = @productionCompanies ");
			if (entity.ProductionCountries != null)
			query.Append("   and production_countries = @productionCountries ");
			if (entity.ReleaseDate != null)
			query.Append("   and release_date = @releaseDate ");
			if (entity.Revenue != null)
			query.Append("   and revenue = @revenue ");
			if (entity.Runtime != null)
			query.Append("   and runtime = @runtime ");
			if (entity.SpokenLanguages != null)
			query.Append("   and spoken_languages = @spokenLanguages, ");
			if (entity.Status != null)
			query.Append("   and status = @status ");
			if (entity.Tagline != null)
			query.Append("   and tagline = @tagline ");
			if (entity.Title != null)
			query.Append("   and title = @title ");
			if (entity.Video != null)
			query.Append("   and video = @video ");
			if (entity.VoteAverage != null)
			query.Append("   and vote_average = @voteAverage ");
			if (entity.VoteCount != null)
			query.Append("   and vote_count = @voteCount ");
			if (entity.Casting != null)
			query.Append("   and casting = @casting ");
			if (entity.Directors != null)
			query.Append("   and directors  = @directors ");
			if (additionalWhere != null)
			query.Append($"  and {additionalWhere} ");

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
			parameters.Add("@originalTitle", entity.Title);
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
			foreach ((string parameterName, object? parameterValue) in additionalParameters)
			{
				parameters.Add(parameterName, parameterValue);
			}

			// Retrieve result from database and convert to entity class
			return await Connection.QueryAsync<Movies>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> InsertMoviesJustOnceAsync(Movies entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" insert into public.movies ");
			query.Append("   ( ");
			query.Append("     adult, ");
			query.Append("     backdrop_path, ");
			query.Append("     belongs_to_collection, ");
			query.Append("     budget, ");
			query.Append("     genres, ");
			query.Append("     homepage, ");
			query.Append("     id, ");
			query.Append("     imdb_id, ");
			query.Append("     original_language, ");
			query.Append("     original_title, ");
			query.Append("     overview, ");
			query.Append("     popularity, ");
			query.Append("     poster_path, ");
			query.Append("     production_companies, ");
			query.Append("     production_countries, ");
			query.Append("     release_date, ");
			query.Append("     revenue, ");
			query.Append("     runtime, ");
			query.Append("     spoken_languages, ");
			query.Append("     status, ");
			query.Append("     tagline, ");
			query.Append("     title, ");
			query.Append("     video, ");
			query.Append("     vote_average, ");
			query.Append("     vote_count, ");
			query.Append("     casting, ");
			query.Append("     directors ");
			query.Append("   ) ");
			query.Append(" values ");
			query.Append("   ( ");
			query.Append("     @adult, ");
			query.Append("     @backdropPath, ");
			query.Append("     @belongsToCollection, ");
			query.Append("     @budget, ");
			query.Append("     @genres, ");
			query.Append("     @homepage, ");
			query.Append("     @id, ");
			query.Append("     @imdbId, ");
			query.Append("     @originalLanguage, ");
			query.Append("     @originalTitle, ");
			query.Append("     @overview, ");
			query.Append("     @popularity, ");
			query.Append("     @posterPath, ");
			query.Append("     @productionCompanies, ");
			query.Append("     @productionCountries, ");
			query.Append("     @releaseDate, ");
			query.Append("     @revenue, ");
			query.Append("     @runtime, ");
			query.Append("     @spokenLanguages, ");
			query.Append("     @status, ");
			query.Append("     @tagline, ");
			query.Append("     @title, ");
			query.Append("     @video, ");
			query.Append("     @voteAverage, ");
			query.Append("     @voteCount, ");
			query.Append("     @casting, ");
			query.Append("     @directors ");
			query.Append("   ) ");
			
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
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> UpdateMoviesMatchingAsync(Movies entity, Movies updatedValue)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" update ");
			query.Append("   public.movies ");
			query.Append(" set ");
			query.Append("    created_timestamp = created_timestamp ");

			if (updatedValue.Adult != null) query.Append("   , adult = @updatedAdult ");
			if (updatedValue.BackdropPath != null) query.Append("   , backdrop_path = @updatedBackdropPath ");
			if (updatedValue.BelongsToCollection != null) query.Append("   , belongs_to_collection = @updatedBelongsToCollection ");
			if (updatedValue.Budget != null) query.Append("   , budget = @updatedBudget ");
			if (updatedValue.Genres != null) query.Append("   , genres = @updatedGenres ");
			if (updatedValue.Homepage != null) query.Append("   , homepage = @updatedHomepage ");
			if (updatedValue.ImdbId != null) query.Append("   , imdb_id = @updatedImdbId ");
			if (updatedValue.OriginalLanguage != null) query.Append("   , original_language = @updatedOriginalLanguage ");
			if (updatedValue.OriginalTitle != null) query.Append("   , original_title = @updatedOriginalTitle ");
			if (updatedValue.Overview != null) query.Append("   , overview = @updatedOverview ");
			if (updatedValue.Popularity != null) query.Append("   , popularity  = @updatedPopularity ");
			if (updatedValue.PosterPath != null) query.Append("   , poster_path = @updatedPosterPath ");
			if (updatedValue.ProductionCompanies != null) query.Append("   , production_companies = @updatedProductionCompanies ");
			if (updatedValue.ProductionCountries != null) query.Append("   , production_countries = @updatedProductionCountries ");
			if (updatedValue.ReleaseDate != null) query.Append("   , release_date = @updatedReleaseDate ");
			if (updatedValue.Revenue != null) query.Append("   , revenue = @updatedRevenue ");
			if (updatedValue.Runtime != null) query.Append("   , runtime = @updatedRuntime ");
			if (updatedValue.SpokenLanguages != null) query.Append("   , spoken_languages = @updatedSpokenLanguages ");
			if (updatedValue.Status != null) query.Append("   , status = @updatedStatus ");
			if (updatedValue.Tagline != null) query.Append("   , tagline = @updatedTagline ");
			if (updatedValue.Title != null) query.Append("   , title = @updatedTitle ");
			if (updatedValue.Video != null) query.Append("   , video = @updatedVideo ");
			if (updatedValue.VoteAverage != null) query.Append("   , vote_average = @updatedVoteAverage ");
			if (updatedValue.VoteCount != null) query.Append("   , vote_count = @updatedVoteCount ");
			if (updatedValue.Casting != null) query.Append("   , casting = @updatedCasting ");
			if (updatedValue.Directors != null) query.Append("   , directors  = @updatedDirectors ");

			query.Append(" where true ");
			if (entity.Adult != null)
			query.Append("   and adult = @adult ");
			if (entity.BackdropPath != null)
			query.Append("   and backdrop_path = @backdropPath ");
			if (entity.BelongsToCollection != null)
			query.Append("   and belongs_to_collection = @belongsToCollection ");
			if (entity.Budget != null)
			query.Append("   and budget = @budget ");
			if (entity.Genres != null)
			query.Append("   and genres = @genres ");
			if (entity.Homepage != null)
			query.Append("   and homepage = @homepage ");
			if (entity.Id != null)
			query.Append("   and id = @id ");
			if (entity.ImdbId != null)
			query.Append("   and imdb_id = @imdbId ");
			if (entity.OriginalLanguage != null)
			query.Append("   and original_language = @originalLanguage ");
			if (entity.Title != null)
			query.Append("   and original_title = @originalTitle ");
			if (entity.Overview != null)
			query.Append("   and overview = @overview ");
			if (entity.Popularity != null)
			query.Append("   and popularity  = @popularity ");
			if (entity.PosterPath != null)
			query.Append("   and poster_path = @posterPath ");
			if (entity.ProductionCompanies != null)
			query.Append("   and production_companies = @productionCompanies ");
			if (entity.ProductionCountries != null)
			query.Append("   and production_countries = @productionCountries ");
			if (entity.ReleaseDate != null)
			query.Append("   and release_date = @releaseDate ");
			if (entity.Revenue != null)
			query.Append("   and revenue = @revenue ");
			if (entity.Runtime != null)
			query.Append("   and runtime = @runtime ");
			if (entity.SpokenLanguages != null)
			query.Append("   and spoken_languages = @spokenLanguages, ");
			if (entity.Status != null)
			query.Append("   and status = @status ");
			if (entity.Tagline != null)
			query.Append("   and tagline = @tagline ");
			if (entity.Title != null)
			query.Append("   and title = @title ");
			if (entity.Video != null)
			query.Append("   and video = @video ");
			if (entity.VoteAverage != null)
			query.Append("   and vote_average = @voteAverage ");
			if (entity.VoteCount != null)
			query.Append("   and vote_count = @voteCount ");
			if (entity.Casting != null)
			query.Append("   and casting = @casting ");
			if (entity.Directors != null)
			query.Append("   and directors  = @directors ");
			
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
			parameters.Add("@id", entity.Id);

			parameters.Add("@updatedAdult", updatedValue.Adult);
			parameters.Add("@updatedBackdropPath", updatedValue.BackdropPath);
			parameters.Add("@updatedBelongsToCollection", updatedValue.BelongsToCollection);
			parameters.Add("@updatedBudget", updatedValue.Budget);
			parameters.Add("@updatedGenres", updatedValue.Genres);
			parameters.Add("@updatedHomepage", updatedValue.Homepage);
			parameters.Add("@updatedImdbId", updatedValue.ImdbId);
			parameters.Add("@updatedOriginalLanguage", updatedValue.OriginalLanguage);
			parameters.Add("@updatedOriginalTitle", updatedValue.OriginalTitle);
			parameters.Add("@updatedOverview", updatedValue.Overview);
			parameters.Add("@updatedPopularity", updatedValue.Popularity);
			parameters.Add("@updatedPosterPath", updatedValue.PosterPath);
			parameters.Add("@updatedProductionCompanies", updatedValue.ProductionCompanies);
			parameters.Add("@updatedProductionCountries", updatedValue.ProductionCountries);
			parameters.Add("@updatedReleaseDate", updatedValue.ReleaseDate);
			parameters.Add("@updatedRevenue", updatedValue.Revenue);
			parameters.Add("@updatedRuntime", updatedValue.Runtime);
			parameters.Add("@updatedSpokenLanguages", updatedValue.SpokenLanguages);
			parameters.Add("@updatedStatus", updatedValue.Status);
			parameters.Add("@updatedTagline", updatedValue.Tagline);
			parameters.Add("@updatedTitle", updatedValue.Title);
			parameters.Add("@updatedVideo", updatedValue.Video);
			parameters.Add("@updatedVoteAverage", updatedValue.VoteAverage);
			parameters.Add("@updatedVoteCount", updatedValue.VoteCount);
			parameters.Add("@updatedCasting", updatedValue.Casting);
			parameters.Add("@updatedDirectors", updatedValue.Directors);
			parameters.Add("@updatedId", updatedValue.Id);

			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> RemoveMoviesMatchingAsync(Movies entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" delete from public.movies where true ");
			if (entity.Adult != null)
			query.Append("   and adult = @adult ");
			if (entity.BackdropPath != null)
			query.Append("   and backdrop_path = @backdropPath ");
			if (entity.BelongsToCollection != null)
			query.Append("   and belongs_to_collection = @belongsToCollection ");
			if (entity.Budget != null)
			query.Append("   and budget = @budget ");
			if (entity.Genres != null)
			query.Append("   and genres = @genres ");
			if (entity.Homepage != null)
			query.Append("   and homepage = @homepage ");
			if (entity.Id != null)
			query.Append("   and id = @id ");
			if (entity.ImdbId != null)
			query.Append("   and imdb_id = @imdbId ");
			if (entity.OriginalLanguage != null)
			query.Append("   and original_language = @originalLanguage ");
			if (entity.Title != null)
			query.Append("   and original_title = @originalTitle ");
			if (entity.Overview != null)
			query.Append("   and overview = @overview ");
			if (entity.Popularity != null)
			query.Append("   and popularity  = @popularity ");
			if (entity.PosterPath != null)
			query.Append("   and poster_path = @posterPath ");
			if (entity.ProductionCompanies != null)
			query.Append("   and production_companies = @productionCompanies ");
			if (entity.ProductionCountries != null)
			query.Append("   and production_countries = @productionCountries ");
			if (entity.ReleaseDate != null)
			query.Append("   and release_date = @releaseDate ");
			if (entity.Revenue != null)
			query.Append("   and revenue = @revenue ");
			if (entity.Runtime != null)
			query.Append("   and runtime = @runtime ");
			if (entity.SpokenLanguages != null)
			query.Append("   and spoken_languages = @spokenLanguages, ");
			if (entity.Status != null)
			query.Append("   and status = @status ");
			if (entity.Tagline != null)
			query.Append("   and tagline = @tagline ");
			if (entity.Title != null)
			query.Append("   and title = @title ");
			if (entity.Video != null)
			query.Append("   and video = @video ");
			if (entity.VoteAverage != null)
			query.Append("   and vote_average = @voteAverage ");
			if (entity.VoteCount != null)
			query.Append("   and vote_count = @voteCount ");
			if (entity.Casting != null)
			query.Append("   and casting = @casting ");
			if (entity.Directors != null)
			query.Append("   and directors  = @directors ");
			
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
			parameters.Add("@id", entity.Id);

			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<Cinemas>> SelectCinemasAsync(int pageSize = 10, int pageNumber = 1)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("      id Id, ");
			query.Append("      name    Name, ");
			query.Append("   address Address, ");
			query.Append("   created_timestamp CreatedTimestamp, ");
			query.Append("   updated_timestamp UpdatedTimestamp  ");
			query.Append(" from ");
			query.Append("   public.cinemas ");
			query.Append(" order by ");
			query.Append("   id ");
			query.Append(" offset (@pageSize * (@pageNumber - 1)) rows ");
			query.Append(" fetch next @pageSize rows only ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@pageSize", pageSize);
			parameters.Add("@pageNumber", pageNumber);
			
			// Retrieve result from database and convert to typed list
			return await Connection.QueryAsync<Cinemas>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<Cinemas>> SelectCinemasMatchingAsync(Cinemas entity, string? additionalWhere = null, params (string parameterName, object? parameterValue)[] additionalParameters)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("      id Id, ");
			query.Append("      name    Name, ");
			query.Append("   address Address, ");
			query.Append("   created_timestamp CreatedTimestamp, ");
			query.Append("   updated_timestamp UpdatedTimestamp  ");
			query.Append(" from ");
			query.Append("   public.cinemas ");
			query.Append(" where true ");
			if (entity.  Id != null)
			query.Append("   and   id =   @id ");
			if (entity.Name != null)
			query.Append("   and name = @name ");
			if (entity.Address != null)
			query.Append("   and address = @address ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@name"   , entity.   Name);
			parameters.Add("@address", entity.Address);
			parameters.Add("@id", entity.Id);

			// Retrieve result from database and convert to entity class
			return await Connection.QueryAsync<Cinemas>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> InsertCinemasJustOnceAsync(Cinemas entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" insert into public.cinemas ");
			query.Append("   ( ");
			query.Append("        name, ");
			query.Append("     address  ");
			query.Append("   ) ");
			query.Append(" values ");
			query.Append("   ( ");
			query.Append("        @name, ");
			query.Append("     @address  ");
			query.Append("   ) ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@name", entity.Name);
			parameters.Add("@address", entity.Address);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> UpdateCinemasMatchingAsync(Cinemas entity, Cinemas updatedValue)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" update ");
			query.Append("   public.cinemas ");
			query.Append(" set ");
			query.Append("     created_timestamp = created_timestamp ");
			if (updatedValue.  Id != null)
			query.Append("   , id = @updatedId ");
			if (updatedValue.Name != null)
			query.Append("   ,    name =    @updatedName ");
			if (updatedValue.Address != null)
			query.Append("   , address = @updatedAddress ");
			query.Append(" where true ");
			if (entity.  Id != null)
			query.Append("   and   id =   @id ");
			if (entity.Name != null)
			query.Append("   and name = @name ");
			if (entity.Address != null)
			query.Append("   and address = @address ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@name"   , entity.   Name);
			parameters.Add("@address", entity.Address);
			parameters.Add("@id", entity.Id);

			parameters.Add("@updatedName"   , updatedValue.   Name);
			parameters.Add("@updatedAddress", updatedValue.Address);
			parameters.Add("@updatedId", updatedValue.Id);

			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> RemoveCinemasMatchingAsync(Cinemas entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" delete from public.cinemas where true ");
			if (entity.  Id != null)
			query.Append("   and   id =   @id ");
			if (entity.Name != null)
			query.Append("   and name = @name ");
			if (entity.Address != null)
			query.Append("   and address = @address ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@id"  , entity.Id);
			parameters.Add("@name", entity.Name);
			parameters.Add("@address", entity.Address);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<Orders>> SelectOrdersAsync(int pageSize = 10, int pageNumber = 1)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("         id Id, ");
			query.Append("   price Price, ");
			query.Append("   cinema_id CinemaId, ");
			query.Append("   serving_size ServingSize, ");
			query.Append("             bill_id           BillId, ");
			query.Append("   food_and_drink_id   FoodAndDrinkId, ");
			query.Append("   created_timestamp CreatedTimestamp, ");
			query.Append("   updated_timestamp UpdatedTimestamp  ");
			query.Append(" from ");
			query.Append("   public.orders ");
			query.Append(" order by ");
			query.Append("   id ");
			query.Append(" offset (@pageSize * (@pageNumber - 1)) rows ");
			query.Append(" fetch next @pageSize rows only ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@pageSize", pageSize);
			parameters.Add("@pageNumber", pageNumber);
			
			// Retrieve result from database and convert to typed list
			return await Connection.QueryAsync<Orders>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<Orders>> SelectOrdersMatchingAsync(Orders entity, string? additionalWhere = null, params (string parameterName, object? parameterValue)[] additionalParameters)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("         id Id, ");
			query.Append("   price Price, ");
			query.Append("   cinema_id CinemaId, ");
			query.Append("   serving_size ServingSize, ");
			query.Append("             bill_id           BillId, ");
			query.Append("   food_and_drink_id   FoodAndDrinkId, ");
			query.Append("   created_timestamp CreatedTimestamp, ");
			query.Append("   updated_timestamp UpdatedTimestamp  ");
			query.Append(" from ");
			query.Append("   public.orders ");
			query.Append(" where true ");
			if (entity.CinemaId != null)
			query.Append("   and cinema_id = @cinemaId ");
			if (entity.ServingSize != null)
			query.Append("   and serving_size = @servingSize ");
			if (entity.Price != null)
			query.Append("   and                price =             @price ");
			if (entity.            Id != null)
			query.Append("   and                id =             @id ");
			if (entity.        BillId != null)
			query.Append("   and           bill_id =         @billId ");
			if (entity.FoodAndDrinkId != null)
			query.Append("   and food_and_drink_id = @foodAndDrinkId ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();

			// Add parameters to collection
			parameters.Add("@id", entity.Id);
			parameters.Add(        "@billId", entity.        BillId);
			parameters.Add("@foodAndDrinkId", entity.FoodAndDrinkId);
			parameters.Add("@price", entity.Price);
			parameters.Add("@cinemaId", entity.CinemaId);
			parameters.Add("@servingSize", entity.ServingSize);

			// Retrieve result from database and convert to entity class
			return await Connection.QueryAsync<Orders>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> InsertOrdersJustOnceAsync(Orders entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" insert into public.orders ");
			query.Append("   ( ");
			query.Append("     price, ");
			query.Append("     cinema_id   , ");
			query.Append("     serving_size, ");
			query.Append("               bill_id, ");
			query.Append("     food_and_drink_id  ");
			query.Append("   ) ");
			query.Append(" values ");
			query.Append("   ( ");
			query.Append("     @price, ");
			query.Append("     @cinemaId   , ");
			query.Append("     @servingSize, ");
			query.Append("             @billId, ");
			query.Append("     @foodAndDrinkId  ");
			query.Append("   ) ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();

			// Add parameters to collection
			parameters.Add("@price", entity.Price);
			parameters.Add(        "@billId", entity.BillId);
			parameters.Add("@foodAndDrinkId", entity.FoodAndDrinkId);
			parameters.Add("@cinemaId", entity.CinemaId);
			parameters.Add("@servingSize", entity.ServingSize);

			// Execute query in database
			return await Connection.ExecuteScalarAsync<long>(new CommandDefinition(query.Append(" returning id ").ToString(), parameters));
		}

		public async Task<long> UpdateOrdersMatchingAsync(Orders entity, Orders updatedValue)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" update ");
			query.Append("   public.orders ");
			query.Append(" set ");
			query.Append("     created_timestamp = created_timestamp ");
			if (updatedValue.Price != null)
			query.Append("   , price = @updatedPrice ");
			if (updatedValue.            Id != null)
			query.Append("   ,                id =             @updatedId ");
			if (updatedValue.        BillId != null)
			query.Append("   ,           bill_id =         @updatedBillId ");
			if (updatedValue.FoodAndDrinkId != null)
			query.Append("   , food_and_drink_id = @updatedFoodAndDrinkId ");
			if (updatedValue.CinemaId != null)
			query.Append("   , cinema_id = @updatedCinemaId ");
			if (updatedValue.ServingSize != null)
			query.Append("   , serving_size = @updatedServingSize ");
			query.Append(" where true ");
			if (entity.Price != null)
			query.Append("   and                price =             @price ");
			if (entity.            Id != null)
			query.Append("   and                id =             @id ");
			if (entity.        BillId != null)
			query.Append("   and           bill_id =         @billId ");
			if (entity.FoodAndDrinkId != null)
			query.Append("   and food_and_drink_id = @foodAndDrinkId ");
			if (entity.CinemaId != null)
			query.Append("   and cinema_id = @cinemaId ");
			if (entity.ServingSize != null)
			query.Append("   and serving_size = @servingSize ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@id", entity.Id);
			parameters.Add(        "@billId", entity.BillId);
			parameters.Add("@foodAndDrinkId", entity.FoodAndDrinkId);
			parameters.Add("@price", entity.Price);
			parameters.Add("@cinemaId", entity.CinemaId);
			parameters.Add("@servingSize", entity.ServingSize);

			parameters.Add(   "@updatedId", updatedValue.Id);
			parameters.Add("@updatedPrice", updatedValue.Price);
			parameters.Add(        "@updatedBillId", updatedValue.BillId);
			parameters.Add("@updatedFoodAndDrinkId", updatedValue.FoodAndDrinkId);
			parameters.Add("@updatedCinemaId", updatedValue.CinemaId);
			parameters.Add("@updatedServingSize", updatedValue.ServingSize);

			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> RemoveOrdersMatchingAsync(Orders entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" delete from public.orders where true ");
			if (entity.CinemaId != null)
			query.Append("   and cinema_id = @cinemaId ");
			if (entity.ServingSize != null)
			query.Append("   and serving_size = @servingSize ");
			if (entity.Price != null)
			query.Append("   and                price =             @price ");
			if (entity.            Id != null)
			query.Append("   and                id =             @id ");
			if (entity.        BillId != null)
			query.Append("   and           bill_id =         @billId ");
			if (entity.FoodAndDrinkId != null)
			query.Append("   and food_and_drink_id = @foodAndDrinkId ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();

			// Add parameters to collection
			parameters.Add("@id", entity.Id);
			parameters.Add(        "@billId", entity.BillId);
			parameters.Add("@foodAndDrinkId", entity.FoodAndDrinkId);
			parameters.Add("@price", entity.Price);
			parameters.Add("@cinemaId", entity.CinemaId);
			parameters.Add("@servingSize", entity.ServingSize);

			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<ExtendedMenus>> SelectMenusAsync(int pageSize = 10, int pageNumber = 1)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("           m.cinema_id       CinemaId, ");
			query.Append("   m.food_and_drink_id FoodAndDrinkId, ");
			query.Append("   m.serving_size ServingSize , ");
			query.Append("   m.availability Availability, ");
			query.Append("   m.price Price, ");
			query.Append("   m.created_timestamp CreatedTimestamp, ");
			query.Append("   m.updated_timestamp UpdatedTimestamp, ");
			
			query.Append("       f.id Id, ");
			query.Append("   f.name Name, ");
			query.Append("   f.category Category, ");
			query.Append("   f.description Description, ");
			query.Append("   f.created_timestamp CreatedTimestamp, ");
			query.Append("   f.updated_timestamp UpdatedTimestamp, ");
			query.Append("   f.image_url ImageUrl ");

			query.Append(" from ");
			query.Append("   public.menus m left join public.food_and_drinks f on m.food_and_drink_id = f.id ");
			query.Append(" order by ");
			query.Append("           m.cinema_id, ");
			query.Append("   m.food_and_drink_id, ");
			query.Append("   m.serving_size ");
			query.Append(" offset (@pageSize * (@pageNumber - 1)) rows ");
			query.Append(" fetch next @pageSize rows only ");

			// Create parameters collection
			var parameters = new DynamicParameters();

			// Add parameters to collection
			parameters.Add("@pageSize", pageSize);
			parameters.Add("@pageNumber", pageNumber);

			// Retrieve result from database and convert to typed list
			return await Connection.QueryAsync<ExtendedMenus, FoodAndDrinks, ExtendedMenus>
			(new CommandDefinition(query.ToString(), parameters), (extendedMenu, foodAndDrink) =>
			{
				extendedMenu.FoodAndDrink = foodAndDrink;
				return extendedMenu;
			}, splitOn: "Id");
		}

		public async Task<IEnumerable<ExtendedMenus>> SelectMenusMatchingAsync(Menus entity, string? additionalWhere = null, params (string parameterName, object? parameterValue)[] additionalParameters)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("           m.cinema_id       CinemaId, ");
			query.Append("   m.food_and_drink_id FoodAndDrinkId, ");
			query.Append("   m.serving_size ServingSize , ");
			query.Append("   m.availability Availability, ");
			query.Append("   m.price Price, ");
			query.Append("   m.created_timestamp CreatedTimestamp, ");
			query.Append("   m.updated_timestamp UpdatedTimestamp, ");

			query.Append("       f.id Id, ");
			query.Append("   f.name Name, ");
			query.Append("   f.category Category, ");
			query.Append("   f.description Description, ");
			query.Append("   f.created_timestamp CreatedTimestamp, ");
			query.Append("   f.updated_timestamp UpdatedTimestamp, ");
			query.Append("   f.image_url ImageUrl ");

			query.Append(" from ");
			query.Append("   public.menus m left join public.food_and_drinks f on m.food_and_drink_id = f.id ");
			query.Append(" where true ");
			if (entity.      CinemaId != null)
			query.Append("   and         m.cinema_id = @cinemaId       ");
			if (entity.FoodAndDrinkId != null)
			query.Append("   and m.food_and_drink_id = @foodAndDrinkId ");
			if (entity. ServingSize != null)
			query.Append("   and m.serving_size = @servingSize  ");
			if (entity.Price != null)
			query.Append("   and m.price = @price ");
			if (entity.Availability != null)
			query.Append("   and m.availability = @availability ");

			// Create parameters collection
			var parameters = new DynamicParameters();

			// Add parameters to collection
			parameters.Add("@cinemaId", entity.CinemaId);
			parameters.Add("@foodAndDrinkId", entity.FoodAndDrinkId);
			parameters.Add("@servingSize" , entity. ServingSize);
			parameters.Add("@price", entity.Price);
			parameters.Add("@availability", entity.Availability);

			// Retrieve result from database and convert to entity class
			return await Connection.QueryAsync<ExtendedMenus, FoodAndDrinks, ExtendedMenus>
			(new CommandDefinition(query.ToString(), parameters), (extendedMenu, foodAndDrink) =>
			{
				extendedMenu.FoodAndDrink = foodAndDrink;
				return extendedMenu;
			}, splitOn: "Id");
		}

		public async Task<long> InsertMenusJustOnceAsync(Menus entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" insert into public.menus ");
			query.Append("   ( ");
			query.Append("             cinema_id, ");
			query.Append("     food_and_drink_id, ");
			query.Append("     serving_size, ");
			query.Append("     availability, ");
			query.Append("     price ");
			query.Append("   ) ");
			query.Append(" values ");
			query.Append("   ( ");
			query.Append("           @cinemaId, ");
			query.Append("     @foodAndDrinkId, ");
			query.Append("     @servingSize , ");
			query.Append("     @availability, ");
			query.Append("     @price ");
			query.Append("   ) ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@cinemaId", entity.CinemaId);
			parameters.Add("@foodAndDrinkId", entity.FoodAndDrinkId);
			parameters.Add("@servingSize" , entity. ServingSize);
			parameters.Add("@availability", entity.Availability);
			parameters.Add("@price", entity.Price);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> UpdateMenusMatchingAsync(Menus entity, Menus updatedValue)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" update ");
			query.Append("   public.menus ");
			query.Append(" set ");
			query.Append("     created_timestamp = created_timestamp ");
			if (updatedValue.Availability != null)
			query.Append("   , availability = @updatedAvailability  ");
			if (updatedValue.Price != null)
			query.Append("   , price = @updatedPrice ");
			if (updatedValue. ServingSize != null)
			query.Append("   , serving_size = @updatedServingSize   ");
			if (updatedValue.      CinemaId != null)
			query.Append("   ,         cinema_id =       @updatedCinemaId ");
			if (updatedValue.FoodAndDrinkId != null)
			query.Append("   , food_and_drink_id = @updatedFoodAndDrinkId ");
			query.Append(" where true ");
			if (entity.      CinemaId != null)
			query.Append("   and         cinema_id =       @cinemaId ");
			if (entity.FoodAndDrinkId != null)
			query.Append("   and food_and_drink_id = @foodAndDrinkId ");
			if (entity. ServingSize != null)
			query.Append("   and serving_size = @servingSize  ");
			if (entity.Price != null)
			query.Append("   and price = @price ");
			if (entity.Availability != null)
			query.Append("   and availability = @availability ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@availability", entity.Availability);
			parameters.Add("@price", entity.Price);
			parameters.Add("@cinemaId"      , entity.      CinemaId);
			parameters.Add("@foodAndDrinkId", entity.FoodAndDrinkId);
			parameters.Add("@servingSize" , entity. ServingSize);

			parameters.Add("@updatedAvailability", updatedValue.Availability);
			parameters.Add("@updatedPrice", updatedValue.Price);
			parameters.Add("@updatedCinemaId"      , updatedValue.      CinemaId);
			parameters.Add("@updatedFoodAndDrinkId", updatedValue.FoodAndDrinkId);
			parameters.Add("@updatedServingSize" , updatedValue. ServingSize);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> RemoveMenusMatchingAsync(Menus entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" delete from public.menus where true ");
			if (entity.      CinemaId != null)
			query.Append("   and         cinema_id = @cinemaId ");
			if (entity.FoodAndDrinkId != null)
			query.Append("   and food_and_drink_id = @foodAndDrinkId ");
			if (entity. ServingSize != null)
			query.Append("   and serving_size = @servingSize  ");
			if (entity.Price != null)
			query.Append("   and price = @price ");
			if (entity.Availability != null)
			query.Append("   and availability = @availability ");

			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add("@cinemaId"      , entity.      CinemaId);
			parameters.Add("@foodAndDrinkId", entity.FoodAndDrinkId);
			parameters.Add("@servingSize" , entity. ServingSize);
			parameters.Add("@price", entity.Price);
			parameters.Add("@availability", entity.Availability);

			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<Staffs>> SelectStaffsAsync(int pageSize = 10, int pageNumber = 1)
		{
			var query = new StringBuilder();

			query.Append(" select ");
			query.Append("   email Email, ");
			query.Append("   role  Role , ");
			query.Append("   date_of_birth DateOfBirth, ");
			query.Append("     user_id   UserId, ");
			query.Append("   cinema_id CinemaId, ");
			query.Append("   created_timestamp CreatedTimestamp, ");
			query.Append("   updated_timestamp UpdatedTimestamp, ");
			query.Append(" from ");
			query.Append("   public.staffs ");
			query.Append(" order by ");
			query.Append("   user_id ");
			query.Append(" offset (@pageSize * (@pageNumber - 1)) rows ");
			query.Append(" fetch next @pageSize rows only ");

			var parameters = new DynamicParameters();
			parameters.Add("@pageSize", pageSize);
			parameters.Add("@pageNumber", pageNumber);

			return await Connection.QueryAsync<Staffs>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<Staffs>> SelectStaffsMatchingAsync(Staffs entity, string? additionalWhere = null, params (string parameterName, object? parameterValue)[] additionalParameters)
		{
			var query = new StringBuilder();

			query.Append(" select ");
			query.Append("   email Email, ");
			query.Append("   role  Role , ");
			query.Append("   date_of_birth DateOfBirth, ");
			query.Append("     user_id   UserId, ");
			query.Append("   cinema_id CinemaId, ");
			query.Append("   created_timestamp CreatedTimestamp, ");
			query.Append("   updated_timestamp UpdatedTimestamp, ");
			query.Append(" from ");
			query.Append("   public.staffs ");
			query.Append(" where true ");
			if (entity.Email != null)
			query.Append("   and email = @email, ");
			if (entity.Role != null)
			query.Append("   and role  = @role , ");
			if (entity.DateOfBirth != null)
			query.Append("   and date_of_birth = @dateOfBirth, ");
			if (entity.  UserId != null)
			query.Append("   and   user_id =   @userId, ");
			if (entity.CinemaId != null)
			query.Append("   and cinema_id = @cinemaId  ");
	
			var parameters = new DynamicParameters();
			parameters.Add("@email", entity.Email);
			parameters.Add("@role", entity.Role);
			parameters.Add("@dateOfBirth", entity.DateOfBirth);
			parameters.Add("@cinemaId", entity.CinemaId);
			parameters.Add("@userId", entity.UserId);

			return await Connection.QueryAsync<Staffs>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> InsertStaffsJustOnceAsync(Staffs entity)
		{
			var query = new StringBuilder();

			query.Append(" insert into public.staffs ");
			query.Append(" ( user_id, date_of_birth, email, role, cinema_id ) ");
			query.Append(" values ");
			query.Append(" ( @userId, @dateOfBirth, @email, @role, @cinemaId ) ");

			var parameters = new DynamicParameters();
			parameters.Add("@email", entity.Email);
			parameters.Add("@role", entity.Role);
			parameters.Add("@dateOfBirth", entity.DateOfBirth);
			parameters.Add("@cinemaId", entity.CinemaId);
			parameters.Add("@userId", entity.UserId);

			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> UpdateStaffsMatchingAsync(Staffs entity, Staffs updatedValue)
		{
			var query = new StringBuilder();

			query.Append(" update ");
			query.Append("   public.menus ");
			query.Append(" set ");
			query.Append("     created_timestamp = created_timestamp ");
			if (updatedValue.Email != null)
			query.Append("   , email = @updatedEmail ");
			if (updatedValue.Role != null)
			query.Append("   , role  = @updatedRole  ");
			if (updatedValue.DateOfBirth != null)
			query.Append("   , date_of_birth = @updatedDateOfBirth ");
			if (updatedValue.  UserId != null)
			query.Append("   ,   user_id =   @updatedUserId ");
			if (updatedValue.CinemaId != null)
			query.Append("   , cinema_id = @updatedCinemaId ");
			query.Append(" where true ");
			if (entity.Email != null)
			query.Append("   and email = @email, ");
			if (entity.Role != null)
			query.Append("   and role  = @role , ");
			if (entity.DateOfBirth != null)
			query.Append("   and date_of_birth = @dateOfBirth, ");
			if (entity.  UserId != null)
			query.Append("   and   user_id =   @userId, ");
			if (entity.CinemaId != null)
			query.Append("   and cinema_id = @cinemaId  ");

			var parameters = new DynamicParameters();
			parameters.Add("@email", entity.Email);
			parameters.Add("@role", entity.Role);
			parameters.Add("@dateOfBirth", entity.DateOfBirth);
			parameters.Add("@cinemaId", entity.CinemaId);
			parameters.Add("@userId", entity.UserId);

			parameters.Add("@updatedEmail", updatedValue.Email);
			parameters.Add("@updatedRole", updatedValue.Role);
			parameters.Add("@updatedDateOfBirth", updatedValue.DateOfBirth);
			parameters.Add("@updatedCinemaId", updatedValue.CinemaId);
			parameters.Add("@updatedUserId", updatedValue.UserId);

			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> RemoveStaffsMatchingAsync(Staffs entity)
		{
			var query = new StringBuilder();

			query.Append(" delete from public.staffs where true ");
			if (entity.Email != null)
			query.Append("   and email = @email, ");
			if (entity.Role != null)
			query.Append("   and role  = @role , ");
			if (entity.DateOfBirth != null)
			query.Append("   and date_of_birth = @dateOfBirth, ");
			if (entity.  UserId != null)
			query.Append("   and   user_id =   @userId, ");
			if (entity.CinemaId != null)
			query.Append("   and cinema_id = @cinemaId  ");

			var parameters = new DynamicParameters();
			parameters.Add("@email", entity.Email);
			parameters.Add("@role", entity.Role);
			parameters.Add("@dateOfBirth", entity.DateOfBirth);
			parameters.Add("@cinemaId", entity.CinemaId);
			parameters.Add("@userId", entity.UserId);

			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<Discounts>> SelectDiscountsAsync(int pageSize = 10, int pageNumber = 1)
		{
			var query = new StringBuilder();

			query.Append(" select ");
			query.Append("   id Id, ");
			query.Append("   name Name, ");
			query.Append("   percentage  Percentage, ");
			query.Append("   minimum_invoice  MinimumInvoice , ");
			query.Append("   maximum_discount MaximumDiscount, ");
			query.Append("   expire_date ExpireDate, ");
			query.Append("   created_timestamp CreatedTimestamp, ");
			query.Append("   updated_timestamp UpdatedTimestamp  ");
			query.Append(" from ");
			query.Append("   public.discounts ");
			query.Append(" order by ");
			query.Append("   id ");
			query.Append(" offset (@pageSize * (@pageNumber - 1)) rows ");
			query.Append(" fetch next @pageSize rows only ");

			var parameters = new DynamicParameters();
			parameters.Add("@pageSize", pageSize);
			parameters.Add("@pageNumber", pageNumber);

			return await Connection.QueryAsync<Discounts>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<Discounts>> SelectDiscountsMatchingAsync(Discounts entity, string? additionalWhere = null, params (string parameterName, object? parameterValue)[] additionalParameters)
		{
			var query = new StringBuilder();

			query.Append(" select ");
			query.Append("   id Id, ");
			query.Append("   name Name, ");
			query.Append("   percentage  Percentage, ");
			query.Append("   minimum_invoice  MinimumInvoice , ");
			query.Append("   maximum_discount MaximumDiscount, ");
			query.Append("   expire_date ExpireDate, ");
			query.Append("   created_timestamp CreatedTimestamp, ");
			query.Append("   updated_timestamp UpdatedTimestamp  ");
			query.Append(" from ");
			query.Append("   public.discounts ");
			query.Append(" where true ");
			if (entity.Id != null)
			query.Append("   and id = @id ");
			if (entity.Name != null)
			query.Append("   and name = @name ");
			if (entity.Percentage != null)
			query.Append("   and percentage  = @percentage ");
			if (entity.MinimumInvoice  != null)
			query.Append("   and minimum_invoice  = @minimumInvoice  ");
			if (entity.MaximumDiscount != null)
			query.Append("   and maximum_discount = @maximumDiscount ");
			if (entity.ExpireDate != null)
			query.Append("   and expire_date = @expireDate ");

			var parameters = new DynamicParameters();
			parameters.Add("@id", entity.Id);
			parameters.Add("@name", entity.Name);
			parameters.Add("@percentage", entity.Percentage);
			parameters.Add("@minimumInvoice" , entity.MinimumInvoice );
			parameters.Add("@maximumDiscount", entity.MaximumDiscount);
			parameters.Add("@expireDate", entity.ExpireDate);

			return await Connection.QueryAsync<Discounts>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> InsertDiscountsJustOnceAsync(Discounts entity)
		{
			var query = new StringBuilder();

			query.Append(" insert into public.discounts ");
			query.Append("   ( name, percentage, minimum_invoice, maximum_discount, expire_date ) ");
			query.Append(" values");
			query.Append("   (@name,@percentage, @minimumInvoice, @maximumDiscount, @expireDate ) ");

			var parameters = new DynamicParameters();
			parameters.Add("@name", entity.Name);
			parameters.Add("@percentage", entity.Percentage);
			parameters.Add("@minimumInvoice" , entity.MinimumInvoice );
			parameters.Add("@maximumDiscount", entity.MaximumDiscount);
			parameters.Add("@expireDate", entity.ExpireDate);

			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> UpdateDiscountsMatchingAsync(Discounts entity, Discounts updatedValue)
		{
			var query = new StringBuilder();

			query.Append(" update ");
			query.Append("   public.discounts ");
			query.Append(" set ");
			query.Append("     created_timestamp = created_timestamp ");
			if (updatedValue.Id != null)
			query.Append("   , id = @updatedId ");
			if (updatedValue.Name != null)
			query.Append("   , name = @updatedName ");
			if (updatedValue.Percentage != null)
			query.Append("   , percentage  = @percentage ");
			if (updatedValue.MinimumInvoice  != null)
			query.Append("   , minimum_invoice  = @minimumInvoice  ");
			if (updatedValue.MaximumDiscount != null)
			query.Append("   , maximum_discount = @maximumDiscount ");
			if (updatedValue.ExpireDate != null)
			query.Append("   , expire_date = @expireDate ");
			query.Append(" where true ");
			if (entity.Id != null)
			query.Append("   and id = @id ");
			if (entity.Name != null)
			query.Append("   and name = @name ");
			if (entity.Percentage != null)
			query.Append("   and percentage  = @percentage ");
			if (entity.MinimumInvoice  != null)
			query.Append("   and minimum_invoice  = @minimumInvoice  ");
			if (entity.MaximumDiscount != null)
			query.Append("   and maximum_discount = @maximumDiscount ");
			if (entity.ExpireDate != null)
			query.Append("   and expire_date = @expireDate ");

			var parameters = new DynamicParameters();
			parameters.Add("@id", entity.Id);
			parameters.Add("@name", entity.Name);
			parameters.Add("@percentage", entity.Percentage);
			parameters.Add("@minimumInvoice" , entity.MinimumInvoice );
			parameters.Add("@maximumDiscount", entity.MaximumDiscount);
			parameters.Add("@expireDate", entity.ExpireDate);

			parameters.Add("@updatedId", updatedValue.Id);
			parameters.Add("@updatedName", updatedValue.Name);
			parameters.Add("@updatedPercentage", updatedValue.Percentage);
			parameters.Add("@updatedMinimumInvoice" , updatedValue.MinimumInvoice );
			parameters.Add("@updatedMaximumDiscount", updatedValue.MaximumDiscount);
			parameters.Add("@updatedExpireDate", updatedValue.ExpireDate);

			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> RemoveDiscountsMatchingAsync(Discounts entity)
		{
			var query = new StringBuilder();

			query.Append(" delete from public.discounts where true ");
			if (entity.Id != null)
			query.Append("   and id = @id ");
			if (entity.Name != null)
			query.Append("   and name = @name ");
			if (entity.Percentage != null)
			query.Append("   and percentage  = @percentage ");
			if (entity.MinimumInvoice  != null)
			query.Append("   and minimum_invoice  = @minimumInvoice  ");
			if (entity.MaximumDiscount != null)
			query.Append("   and maximum_discount = @maximumDiscount ");
			if (entity.ExpireDate != null)
			query.Append("   and expire_date = @expireDate ");

			var parameters = new DynamicParameters();
			parameters.Add("@id", entity.Id);
			parameters.Add("@name", entity.Name);
			parameters.Add("@percentage", entity.Percentage);
			parameters.Add("@minimumInvoice" , entity.MinimumInvoice );
			parameters.Add("@maximumDiscount", entity.MaximumDiscount);
			parameters.Add("@expireDate", entity.ExpireDate);

			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<Bills>> SelectBillsAsync(int pageSize = 10, int pageNumber = 1)
		{
			// Create string builder for query
			var query = new StringBuilder();

			// Create sql statement
			query.Append(" select ");
			query.Append("            id Id, ");
			query.Append("   user_id UserId, ");
			query.Append("   created_timestamp CreatedTimestamp, ");
			query.Append("   updated_timestamp UpdatedTimestamp, ");
			query.Append("   membership_id MembershipId, ");
			query.Append("     discount_id   DiscountId  ");
			query.Append(" from ");
			query.Append("   public.bills ");
			query.Append(" order by ");
			query.Append("   id ");
			query.Append(" offset (@pageSize * (@pageNumber - 1)) rows ");
			query.Append(" fetch next @pageSize rows only ");

			// Create parameters collection
			var parameters = new DynamicParameters();

			// Add parameters to collection
			parameters.Add("@pageSize", pageSize);
			parameters.Add("@pageNumber", pageNumber);

			// Retrieve result from database and convert to typed list
			return await Connection.QueryAsync<Bills>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<IEnumerable<Bills>> SelectBillsMatchingAsync(Bills entity, string? additionalWhere = null, params (string parameterName, object? parameterValue)[] additionalParameters)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" select ");
			query.Append("            id Id, ");
			query.Append("   user_id UserId, ");
			query.Append("   created_timestamp CreatedTimestamp, ");
			query.Append("   updated_timestamp UpdatedTimestamp, ");
			query.Append("   membership_id MembershipId, ");
			query.Append("     discount_id   DiscountId  ");
			query.Append(" from ");
			query.Append("   public.bills ");
			query.Append(" where true ");
			if (entity.    Id != null)
			query.Append("   and      id = @id ");
			if (entity.UserId != null)
			query.Append("   and user_id = @userId ");
			if (entity.MembershipId != null)
			query.Append("   and membership_id = @membershipId ");
			if (entity.DiscountId != null)
			query.Append("   and discount_id = @discountId ");

			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add(          "@id", entity.Id);
			parameters.Add(      "@userId", entity.UserId);
			parameters.Add("@membershipId", entity.MembershipId);
			parameters.Add(  "@discountId", entity.DiscountId);

			// Retrieve result from database and convert to entity class
			return await Connection.QueryAsync<Bills>(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> InsertBillsJustOnceAsync(Bills entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" insert into public.bills ");
			query.Append("   ( ");
			query.Append("           user_id, ");
			query.Append("     membership_id, ");
			query.Append("       discount_id  ");
			query.Append("   ) ");
			query.Append(" values ");
			query.Append("   ( ");
			query.Append("           @userId, ");
			query.Append("     @membershipId, ");
			query.Append("       @discountId  ");
			query.Append("   ) ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add(      "@userId", entity.      UserId);
			parameters.Add("@membershipId", entity.MembershipId);
			parameters.Add(  "@discountId", entity.  DiscountId);

			// Execute query in database
			return await Connection.ExecuteScalarAsync<long>(new CommandDefinition(query.Append(" returning id ").ToString(), parameters));
		}

		public async Task<long> UpdateBillsMatchingAsync(Bills entity, Bills updatedValue)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" update ");
			query.Append("   public.bills ");
			query.Append(" set ");
			query.Append("     created_timestamp = created_timestamp ");
			if (updatedValue.        Id != null)
			query.Append("   ,            id =           @updatedId ");
			if (updatedValue.    UserId != null)
			query.Append("   ,       user_id =       @updatedUserId ");
			if (updatedValue.MembershipId != null)
			query.Append("   , membership_id = @updatedMembershipId ");
			if (updatedValue.DiscountId != null)
			query.Append("   ,   discount_id =   @updatedDiscountId ");
			query.Append(" where true ");
			if (entity.    Id != null)
			query.Append("   and      id = @id ");
			if (entity.UserId != null)
			query.Append("   and user_id = @userId ");
			if (entity.MembershipId != null)
			query.Append("   and membership_id = @membershipId ");
			if (entity.DiscountId != null)
			query.Append("   and discount_id = @discountId ");
						
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add(      "@userId", entity.      UserId);
			parameters.Add("@membershipId", entity.MembershipId);
			parameters.Add(          "@id", entity.Id);
			parameters.Add(  "@discountId", entity.  DiscountId);

			parameters.Add(      "@updatedUserId", updatedValue.      UserId);
			parameters.Add("@updatedMembershipId", updatedValue.MembershipId);
			parameters.Add("@updatedId", updatedValue.Id);
			parameters.Add(  "@updatedDiscountId", updatedValue.  DiscountId);

			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}

		public async Task<long> RemoveBillsMatchingAsync(Bills entity)
		{
			// Create string builder for query
			var query = new StringBuilder();
			
			// Create sql statement
			query.Append(" delete from public.bills where true ");
			if (entity.    Id != null)
			query.Append("   and            id =           @id ");
			if (entity.UserId != null)
			query.Append("   and       user_id =       @userId ");
			if (entity.MembershipId != null)
			query.Append("   and membership_id = @membershipId ");
			if (entity.DiscountId != null)
			query.Append("   and   discount_id =   @discountId ");
			
			// Create parameters collection
			var parameters = new DynamicParameters();
			
			// Add parameters to collection
			parameters.Add(      "@userId", entity.      UserId);
			parameters.Add("@membershipId", entity.MembershipId);
			parameters.Add(          "@id", entity.Id);
			parameters.Add(  "@discountId", entity.  DiscountId);
			
			// Execute query in database
			return await Connection.ExecuteAsync(new CommandDefinition(query.ToString(), parameters));
		}
	}
}
