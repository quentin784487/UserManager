namespace UserManager.API.Models.User
{
    public class UserViewModel : TrackedEntityViewModel
    {
        public int? Id { get; set; } = 0;
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public bool IsActive { get; set; }
    }
}
