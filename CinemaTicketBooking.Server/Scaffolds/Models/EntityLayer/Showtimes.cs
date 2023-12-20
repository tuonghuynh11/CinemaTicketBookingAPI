using System;
using System.Text.Json.Serialization;

namespace CinemaTicketBooking.Server.Scaffolds.Models.EntityLayer
{
	public class Showtimes : BaseEntity
	{
		public Showtimes() : base()
		{
		}

		public Showtimes(long id) : base()
		{
			Id = id;
		}

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public long? Id { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public long? MovieId { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public TimeSpan? StartTime { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public TimeSpan? CeaseTime { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public DateTime? Date { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public long? AuditoriumId { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public decimal? Price { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public string? Status { get; set; }
	}
}
