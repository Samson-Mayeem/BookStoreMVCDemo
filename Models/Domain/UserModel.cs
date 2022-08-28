namespace BookStoreMVCDemo.Models.Domain
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public UserRole Role { get; set; }

    }
    public enum UserRole { Admin, User}
}
