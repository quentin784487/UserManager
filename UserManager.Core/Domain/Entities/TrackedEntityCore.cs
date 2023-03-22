namespace UserManager.Core.Domain.Entities
{
    public class TrackedEntityCore
    {
        public string CreatedBy { get; set; } = "";
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string ModifiedBy { get; set; } = "";
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}
