using System;

namespace CinemaTicketBooking.Server.Scaffolds.Models.EntityLayer
{
	public class Showtimes : IEntity
	{
		public Showtimes()
		{
		}

		public Showtimes(long id)
		{
			Id = id;
		}

		public long Id { get; set; }

		public long MovieId { get; set; }

		public object StartTime { get; set; } = null!;

		public object CeaseTime { get; set; } = null!;

		public DateTime Date { get; set; }

		public long AuditoriumId { get; set; }

		public decimal Price { get; set; }

		public string Status { get; set; } = null!;

		public DateTime CreatedTimestamp { get; set; }

		public DateTime UpdatedTimestamp { get; set; }

	}
}
