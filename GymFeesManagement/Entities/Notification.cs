namespace GymFeesManagement.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public int Description { get; set; }
        public User? user {  get; set; }
        public int UserId { get; set; }
    }
}
