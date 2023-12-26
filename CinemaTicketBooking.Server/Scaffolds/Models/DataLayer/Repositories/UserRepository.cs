﻿using System.Data;
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
        var query = "INSERT INTO public.users (username, password, full_name, phone_number, address, sex) VALUES (@Username, @Password, @FullName, @PhoneNumber, @Address, @Sex)";
        await Connection.ExecuteAsync(query, user);
    }

    public async Task<Users> FindByUsername(string username)
    {
        var query = "SELECT * FROM public.users WHERE username = @Username";
        return await Connection.QueryFirstOrDefaultAsync<Users>(query, new { Username = username });
    }
}

