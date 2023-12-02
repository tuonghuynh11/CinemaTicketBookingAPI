using System;

namespace CinemaTicketBooking.Server.Scaffolds.Models.EntityLayer
{
	public class Users : IEntity
	{
		public Users()
		{
		}

		public Users(long id)
		{
			Id = id;
		}

		public long Id { get; set; }

		public string Username { get; set; } = null!;

		public string Password { get; set; } = null!;

		public DateTime CreatedTimestamp { get; set; }

		public DateTime UpdatedTimestamp { get; set; }

	}
}
