using System;

namespace CinemaTicketBooking.Server.Scaffolds.Models.EntityLayer
{
	public class Reservations : IEntity
	{
		public Reservations()
		{
		}

		public long? ShowtimeId { get; set; }

		public long? SeatId { get; set; }

		public long? TicketId { get; set; }

		public DateTime? CreatedTimestamp { get; set; }

		public DateTime? UpdatedTimestamp { get; set; }

	}
}
