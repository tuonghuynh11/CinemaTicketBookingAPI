using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CinemaTicketBooking.Server.Scaffolds.Models.EntityLayer
{
	public class Users : BaseEntity
	{
		public Users() : base()
		{
		}

		public Users(long id) : base()
		{
			Id = id;
		}

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public long? Id { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public string? Username { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public string? Password { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public string? FullName { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public string? PhoneNumber { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public string? Address { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public string? Sex { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public RoleEnum Role { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public string? Email { get; set; }


        public void SetPassword(string password)
        {
            Password = BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, this.Password);
        }
    }

}
