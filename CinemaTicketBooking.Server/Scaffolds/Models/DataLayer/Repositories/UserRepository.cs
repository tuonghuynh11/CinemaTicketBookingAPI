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
        var query = "INSERT INTO public.users (username, password, full_name, phone_number, address, sex, email, role) VALUES (@Username, @Password, @FullName, @PhoneNumber, @Address, @Sex, @Email, @Role)";
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
    public async Task<Users> FindByEmail(string email)
    {
        var query = "SELECT * FROM public.users WHERE email = @Email";
        return await Connection.QueryFirstOrDefaultAsync<Users>(query, new { Email = email });
    }
    public async Task<Users> UpdatePassword(string username, string newPassword)
    {
        try
        {
            var updateQuery = "UPDATE public.users SET password = @Password " +
                              "WHERE username = @Username";

            // Update the password
            await Connection.ExecuteAsync(updateQuery, new { Password = newPassword, Username = username });

            // Fetch the updated user
            var selectQuery = "SELECT * FROM public.users WHERE username = @Username";
            return await Connection.QueryFirstOrDefaultAsync<Users>(selectQuery, new { Username = username });
        }
        catch (Exception ex)
        {
            // Log the exception for debugging purposes
            Console.WriteLine(ex.Message);

            // You might want to throw the exception or handle it accordingly
            throw;
        }
    }
    public async Task<Users> FindByUsernameOrPhoneNumberOrEmail(string identifier)
    {
        var query = "SELECT * FROM public.users WHERE username = @Identifier OR phone_number = @Identifier OR email = @Identifier";
        return await Connection.QueryFirstOrDefaultAsync<Users>(query, new { Identifier = identifier });
    }
}

