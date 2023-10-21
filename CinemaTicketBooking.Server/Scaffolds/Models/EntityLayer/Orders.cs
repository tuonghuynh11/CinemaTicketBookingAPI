using System;

namespace CinemaTicketBooking.Server.Scaffolds.Models.EntityLayer
{
	public class Orders : IEntity
	{
		public Orders()
		{
		}

		public long? TicketId { get; set; }

		public long? FoodAndDrinkId { get; set; }

		public DateTime? CreatedTimestamp { get; set; }

		public DateTime? UpdatedTimestamp { get; set; }

	}
}
