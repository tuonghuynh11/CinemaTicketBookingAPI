using System;

namespace CinemaTicketBooking.Server.Scaffolds.Models.EntityLayer
{
	public class Feedbacks : IEntity
	{
		public Feedbacks()
		{
		}

		public Feedbacks(long id)
		{
			Id = id;
		}

		public long Id { get; set; }

		public long UserId { get; set; }

		public string Content { get; set; } = null!;

		public DateTime CreatedTimestamp { get; set; }

		public DateTime UpdatedTimestamp { get; set; }
	}
}
