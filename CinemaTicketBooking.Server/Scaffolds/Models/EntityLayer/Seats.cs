using System;

namespace CinemaTicketBooking.Server.Scaffolds.Models.EntityLayer
{
	public class Seats : IEntity
	{
		public Seats()
		{
		}

		public Seats(long id)
		{
			Id = id;
		}

		public long Id { get; set; }

		public long AuditoriumId { get; set; }

		public long RowNumber { get; set; }

		public long ColNumber { get; set; }

		public DateTime CreatedTimestamp { get; set; }

		public DateTime UpdatedTimestamp { get; set; }

	}
}
