using UserManager.Shared.Models;

namespace UserManager.Core.Domain.Entities
{
    public class UserCore : TrackedEntityCore, IAggregateRoot
    {
        public long Id { get; set; }
        public string Firstname { get; set; } = "";
        public string Lastname { get; set; } = "";
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string Email { get; set; } = "";
        public bool IsActive { get; set; }
    }
}
