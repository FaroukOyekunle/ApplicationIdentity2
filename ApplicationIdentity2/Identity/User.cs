using ApplicationIdentity2.Contracts;
using ApplicationIdentity2.Entities;

namespace ApplicationIdentity2.Identity
{
    public class User: AuditableEntity
    {
        public string? UserName { get; set; }    
        public string? Password { get; set; }
        public Staff? Staff { get; set; }
        public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
    }
}
