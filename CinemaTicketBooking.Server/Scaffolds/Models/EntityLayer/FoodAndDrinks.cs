using System;

namespace CinemaTicketBooking.Server.Scaffolds.Models.EntityLayer
{
	public class FoodAndDrinks : IEntity
	{
		public FoodAndDrinks()
		{
		}

		public FoodAndDrinks(long id)
		{
			Id = id;
		}

		public long Id { get; set; }

		public string Name { get; set; } = null!;

		public string Category { get; set; } = null!;

		public string ImageUrl { get; set; } = null!;

		public string Description { get; set; } = null!;

		public DateTime CreatedTimestamp { get; set; }

		public DateTime UpdatedTimestamp { get; set; }
	}
}
