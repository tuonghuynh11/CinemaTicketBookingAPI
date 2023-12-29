namespace CinemaTicketBooking.Server.Scaffolds.Models.ModelLayer
{
    public class ForgotPasswordRequestModel
    {
        public string Username { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
