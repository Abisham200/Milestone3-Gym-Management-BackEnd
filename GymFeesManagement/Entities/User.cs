namespace GymFeesManagement.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string PasswordHash { get; set; }
        public UserRoles Roles { get; set; }
    }

    public enum UserRoles
    {
        Admin,
        Member
    }
}
