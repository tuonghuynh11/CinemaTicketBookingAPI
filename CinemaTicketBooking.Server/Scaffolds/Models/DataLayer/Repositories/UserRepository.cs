using System.Data;
using System.Text;
using Dapper;
using CinemaTicketBooking.Server.Scaffolds.Models.EntityLayer;
using CinemaTicketBooking.Server.Scaffolds.Models.DataLayer.Contracts;

public class UserRepository : Repository, IUserRepository
{
    public UserRepository(IDbConnection connection) : base(connection)
    {
    }

    public async Task Add(Users user)
    {
        var query = "INSERT INTO public.users (username, password, full_name, phone_number, address, sex, role) VALUES (@Username, @Password, @FullName, @PhoneNumber, @Address, @Sex, @Role)";
        await Connection.ExecuteAsync(query, user);
    }


    public async Task<Users> FindByUsernameOrPhoneNumber(string identifier)
    {
        var query = "SELECT * FROM public.users WHERE username = @Identifier OR phone_number = @Identifier";
        return await Connection.QueryFirstOrDefaultAsync<Users>(query, new { Identifier = identifier });
    }
    public async Task<Users> FindByUsername (string username)
    {
        var query = "SELECT * FROM public.users WHERE username = @Username";
        return await Connection.QueryFirstOrDefaultAsync<Users>(query, new { Username = username });
    }
    public async Task<Users> FindByPhoneNumber(string phoneNumber)
    {
        var query = "SELECT * FROM public.users WHERE phone_number = @phoneNumber";
        return await Connection.QueryFirstOrDefaultAsync<Users>(query, new { PhoneNumber = phoneNumber });
    }

}

