namespace CybageConnect_API.Models
{
    public class RegistrationModel
    {
        public string FullName { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string UserPassword { get; set; } = null!;

        public string Email { get; set; } = null!;

        public long MobileNumber { get; set; }
    }
}
