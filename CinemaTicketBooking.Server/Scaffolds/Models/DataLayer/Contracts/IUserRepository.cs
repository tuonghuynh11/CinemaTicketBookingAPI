using CinemaTicketBooking.Server.Scaffolds.Models.EntityLayer;
using System.Data;

namespace CinemaTicketBooking.Server.Scaffolds.Models.DataLayer.Contracts
{
    public interface IUserRepository
    {
        Task Add(Users user);
        Task<Users> FindByUsernameOrPhoneNumber(string identifier);
        Task<Users> FindByUsername(string username);
        Task<Users> FindByPhoneNumber(string phoneNumber);
        Task<Users> FindByEmail(string email);
        Task<Users> FindByUsernameOrPhoneNumberOrEmail (string identifier);
        Task<Users> UpdatePassword(string username, string newPassword);
    }
}
