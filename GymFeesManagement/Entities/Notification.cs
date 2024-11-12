namespace GymFeesManagement.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public int Description { get; set; }
        public MemberDetail? Member {  get; set; }
        public int MemberId { get; set; }
    }
}
