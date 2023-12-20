using System.Text.Json.Serialization;

namespace CinemaTicketBooking.Server.Scaffolds.Models.EntityLayer
{
	public abstract class BaseEntity : IEntity
	{
		public BaseEntity() { }

		[JsonIgnore(Condition = JsonIgnoreCondition.Always)]
		public DateTime? CreatedTimestamp { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.Always)]
		public DateTime? UpdatedTimestamp { get; set; }
	}
}
