using System;
using System.Text.Json.Serialization;

namespace CinemaTicketBooking.Server.Scaffolds.Models.EntityLayer
{
	public class Staffs : BaseEntity
	{
		public Staffs() : base()
		{
		}

		public Staffs(long userId)
		{
			UserId = userId;
		}

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public long? UserId { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public DateTime? DateOfBirth { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public string? Email { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public string? Role { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public long? CinemaId { get; set; }
	}

	//public class ExtendedStaffs : Staffs
	//{
	//	public ExtendedStaffs() : base()
	//	{
	//	}

	//	public ExtendedStaffs(long userId) : base(userId)
	//	{
	//	}

	//	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	//	public Cinemas? Cinema { get; set; }
	//}
}
