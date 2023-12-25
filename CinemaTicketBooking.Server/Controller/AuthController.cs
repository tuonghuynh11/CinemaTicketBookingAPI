using CinemaTicketBooking.Server.Scaffolds.Models;
using CinemaTicketBooking.Server.Scaffolds.Models.DataLayer.Contracts;
using CinemaTicketBooking.Server.Scaffolds.Models.EntityLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CinemaTicketBooking.Server.Controller
{
    [ApiController]
    [Route("api/[controller]")]  // This sets the base route for this controller to "api/auth"
    public class AuthController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IUserRepository userRepository;
        public Users user = new Users();

        public AuthController(IUserRepository userRepository, IConfiguration configuration)
        {
            this.userRepository = userRepository;
            _configuration = configuration;
        }

        // Endpoint for registration: api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestModel model)
        {
            try
            {
                if (userRepository == null)
                {
                    Console.WriteLine("userRepository is null");
                    return StatusCode(500, "Internal Server Error");
                }
                // Check if the request is valid
                if (string.IsNullOrWhiteSpace(model.Username) ||
                    string.IsNullOrWhiteSpace(model.Password) ||
                    string.IsNullOrWhiteSpace(model.Fullname) ||
                    string.IsNullOrWhiteSpace(model.PhoneNumber) ||
                    string.IsNullOrWhiteSpace(model.Address) ||
                    string.IsNullOrWhiteSpace(model.Sex))
                {
                    return BadRequest("Please fill in all required fields.");
                }

                // Check if the username already exists
                var existingUser = userRepository.FindByUsername(model.Username);
                if (existingUser != null)
                {
                    return BadRequest("Username already exists.");
                }

                var newUser = new Users
                {
                    Username = model.Username,
                    Password = model.Password, // Note: In a production environment, you should hash the password
                    FullName = model.Fullname,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    Sex = model.Sex,
                };

                // Optionally, hash the password before storing it
                // newUser.SetPassword(model.Password);

                userRepository.Add(newUser); // Save the user to the database

                // Optionally, you can return additional information or a success status
                return Ok(new { message = "Registration successful", username = newUser.Username });
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine(ex.Message);

                // Return a generic error message to the client
                return StatusCode(500, "Internal Server Error");
            }
        }


        // Endpoint for login: api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel model)
        {
            try
            {
                // Find user in the database
                var user = userRepository.FindByUsername(model.Username);
                if (user == null)
                {
                    return BadRequest("User not found !");
                }

                // Check the password
                if (!BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
                {
                    return BadRequest("Wrong Password");
                }

                string token = GenerateJwtToken(user);
                return Ok(token);
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine(ex.Message);

                // Return a generic error message to the client
                return StatusCode(500, "Internal Server Error");
            }
        }

        private string GenerateJwtToken(Users user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
