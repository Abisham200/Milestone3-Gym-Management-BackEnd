using GymFeesManagement.Enum;

namespace GymFeesManagement.Entities
{
    public class SendMailRequest
    {
        public string? Name { get; set; }
        public string? Otp { get; set; }
        public User? User { get; set; }
        public string? Email { get; set; }
        public EmailTypes EmailType { get; set; }
    }
}
