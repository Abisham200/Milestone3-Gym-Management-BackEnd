using GymFeesManagement.Enum;

namespace GymFeesManagement.Entities
{
    public class EmailTemplate
    {
        public Guid Id { get; set; }
        public EmailTypes emailTypes { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
