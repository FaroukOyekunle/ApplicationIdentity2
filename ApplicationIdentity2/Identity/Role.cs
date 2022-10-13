using ApplicationIdentity2.Contracts;

namespace ApplicationIdentity2.Identity
{
    public class Role: AuditableEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
    }
}
