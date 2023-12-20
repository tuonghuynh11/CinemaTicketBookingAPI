using System;
using System.Text.Json.Serialization;

namespace CinemaTicketBooking.Server.Scaffolds.Models.EntityLayer
{
	public class FoodAndDrinks : BaseEntity
	{
		public FoodAndDrinks() : base()
		{
		}

		public FoodAndDrinks(long id) : base()
		{
			Id = id;
		}

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public long? Id { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public string? Name { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public string? Category { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public string? ImageUrl { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public string? Description { get; set; }
	}
}
