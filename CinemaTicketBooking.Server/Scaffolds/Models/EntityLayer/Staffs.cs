using System;
using System.Runtime.Serialization;
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
        public RoleEnum? Role { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public long? CinemaId { get; set; }
	}
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RoleEnum
    {
        [EnumMember(Value = "Customer")]
        Customer = 1,
        [EnumMember(Value = "Staff")]
        Staff = 2,
        [EnumMember(Value = "Manager")]
        Manager = 3,
        [EnumMember(Value = "Admin")]
        Admin = 4
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
