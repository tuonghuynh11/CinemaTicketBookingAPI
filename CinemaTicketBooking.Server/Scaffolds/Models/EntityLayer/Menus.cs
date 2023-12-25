using System;
using System.Text.Json.Serialization;

namespace CinemaTicketBooking.Server.Scaffolds.Models.EntityLayer
{
	public class Menus : BaseEntity
	{
		public Menus() : base()
		{
		}

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public long? CinemaId { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public long? FoodAndDrinkId { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public string? ServingSize { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public bool? Availability { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public decimal? Price { get; set; }
	}

	public class ExtendedMenus : Menus
	{
		public ExtendedMenus() : base()
		{
		}

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public FoodAndDrinks? FoodAndDrink { get; set; }
	}
}
