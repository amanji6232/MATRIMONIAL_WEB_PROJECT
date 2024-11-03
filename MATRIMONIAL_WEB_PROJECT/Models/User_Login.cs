using Data_Access_Layer.Models;

namespace MATRIMONIAL_WEB_PROJECT.Models
{
    public class User_Login
    {
        public Int64 Id { get; set; }
        public List<Login> UserLogin { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Status { get; set; }
        public string Type { get; set; }
        public string? Image { get; set; }
    }
}
