namespace BusTicketingWebApplication.Models.DTOs
{
    public class UserDataDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string? Role { get; set; }
        public string? Token { get; set; }


        public string? Email { get; set; }
        public string? Phone { get; set; }

        public string? City { get; set; }

        public int? Pincode { get; set; }
    }
}
