using System;
using System.Text.Json.Serialization;

namespace CinemaTicketBooking.Server.Scaffolds.Models.EntityLayer
{
	public class Orders : BaseEntity
	{
		public Orders() : base()
		{
		}

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public long? TicketId { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public long? FoodAndDrinkId { get; set; }
	}
}
