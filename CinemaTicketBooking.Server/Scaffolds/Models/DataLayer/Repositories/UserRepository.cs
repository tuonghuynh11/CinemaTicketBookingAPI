using CinemaTicketBooking.Server.Scaffolds.Models.DataLayer.Contracts;
using CinemaTicketBooking.Server.Scaffolds.Models.EntityLayer;

public class UserRepository : IUserRepository
{
    private readonly List<Users> _users;
    private readonly ILogger<UserRepository> _logger;

    public UserRepository(ILogger<UserRepository> logger)
    {
        _users = new List<Users>();
        _logger = logger;
    }

    public void Add(Users user)
    {
        _users.Add(user);
        Console.WriteLine($"User added: {user.Username}");
    }

    public Users FindByUsername(string username)
    {
        try
        {
            return _users.FirstOrDefault(u => u.Username == username);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in FindByUsername");
            throw; // Rethrow the exception after logging
        }
    }
}
