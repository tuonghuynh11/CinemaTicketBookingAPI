using System;

namespace CinemaTicketBooking.Server.Scaffolds.Models.EntityLayer
{
	public class FoodAndDrinks : IEntity
	{
		public FoodAndDrinks()
		{
		}

		public FoodAndDrinks(long? id)
		{
			Id = id;
		}

		public long? Id { get; set; }

		public string Name { get; set; }

		public string Category { get; set; }

		public string Description { get; set; }

		public DateTime? CreatedTimestamp { get; set; }

		public DateTime? UpdatedTimestamp { get; set; }

		public string ImageUrl { get; set; }

	}
}
