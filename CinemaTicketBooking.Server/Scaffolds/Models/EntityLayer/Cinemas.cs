using System;

namespace CinemaTicketBooking.Server.Scaffolds.Models.EntityLayer
{
	public class Cinemas : IEntity
	{
		public Cinemas()
		{
		}

		public Cinemas(long? id)
		{
			Id = id;
		}

		public long? Id { get; set; }

		public string Name { get; set; }

		public string Address { get; set; }

		public DateTime? CreatedTimestamp { get; set; }

		public DateTime? UpdatedTimestamp { get; set; }

	}
}
