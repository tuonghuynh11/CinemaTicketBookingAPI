using CinemaTicketBooking.Server.Scaffolds.Models.EntityLayer;

namespace CinemaTicketBooking.Server.Scaffolds.Models.DataLayer.Contracts
{
    public interface IUserRepository
    {
        void Add(Users user);
        Users FindByUsername(string username);
        // Other necessary methods
    }
}
