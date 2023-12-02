using System;

namespace CinemaTicketBooking.Server.Scaffolds.Models.EntityLayer
{
	public class Memberships : IEntity
	{
		public Memberships()
		{
		}

		public Memberships(long id)
		{
			Id = id;
		}

		public long Id { get; set; }

		public string Name { get; set; } = null!;

		public DateTime CreatedTimestamp { get; set; }

		public DateTime UpdatedTimestamp { get; set; }

	}
}
