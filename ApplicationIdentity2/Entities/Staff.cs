using ApplicationIdentity2.Contracts;
using ApplicationIdentity2.Identity;

namespace ApplicationIdentity2.Entities
{
    public class Staff: AuditableEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }    
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? StaffNumber { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }
    }
}
