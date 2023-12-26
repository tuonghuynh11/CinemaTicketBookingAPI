using CinemaTicketBooking.Server.Scaffolds.Models.EntityLayer;
using System.Data;

namespace CinemaTicketBooking.Server.Scaffolds.Models.DataLayer.Contracts
{
    public interface IUserRepository
    {
        Task Add(Users user);
        Task<Users> FindByUsername(string username);
    }
}
