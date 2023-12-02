using System;

namespace CinemaTicketBooking.Server.Scaffolds.Models.EntityLayer
{
	public class Tickets : IEntity
	{
		public Tickets()
		{
		}

		public Tickets(long id)
		{
			Id = id;
		}

		public long Id { get; set; }

		public long ShowtimeId { get; set; }

		public long UserId { get; set; }

		public DateTime CreatedTimestamp { get; set; }

		public DateTime UpdatedTimestamp { get; set; }

		public long MembershipId { get; set; }

	}
}
