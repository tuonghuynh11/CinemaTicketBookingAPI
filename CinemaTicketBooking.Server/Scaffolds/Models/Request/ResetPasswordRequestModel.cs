namespace CinemaTicketBooking.Server.Scaffolds.Models.ModelLayer
{
    public class ResetPasswordRequestModel
    {
        public string Username { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
