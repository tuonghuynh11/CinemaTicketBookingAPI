using System;

namespace CinemaTicketBooking.Server.Scaffolds.Models.EntityLayer
{
	public class Menus : IEntity
	{
		public Menus()
		{
		}

		public long CinemaId { get; set; }

		public long FoodAndDrinkId { get; set; }

		public string ServingSize { get; set; } = null!;

		public bool Availability { get; set; }

		public decimal Price { get; set; }

		public DateTime CreatedTimestamp { get; set; }

		public DateTime UpdatedTimestamp { get; set; }

	}
}
