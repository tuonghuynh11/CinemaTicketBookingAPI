using System;

namespace CinemaTicketBooking.Server.Scaffolds.Models.EntityLayer
{
	public class Auditoriums : IEntity
	{
		public Auditoriums()
		{
		}

		public Auditoriums(long? id)
		{
			Id = id;
		}

		public long? Id { get; set; }

		public string Name { get; set; }

		public long? CinemaId { get; set; }

		public DateTime? UpdatedTimestamp { get; set; }

		public DateTime? CreatedTimestamp { get; set; }

	}
}
