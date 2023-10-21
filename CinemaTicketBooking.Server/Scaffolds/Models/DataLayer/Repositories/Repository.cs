using System.Data;
using CinemaTicketBooking.Server.Scaffolds.Models.EntityLayer;

namespace CinemaTicketBooking.Server.Scaffolds.Models.DataLayer.Contracts
{
	public class Repository
	{
		public Repository(IDbConnection connection)
		{
			Connection = connection;
		}

		protected IDbConnection Connection { get; }

	}
}
