using ApplicationIdentity2.Identity;

namespace ApplicationIdentity2.Interfaces.Identity
{
    public interface IRoleRepository
    {
        Role AddRoleAsync(Role role);
        Role UpdateRoleAsync(Role role);
        bool DeleteRoleAsync(Role role);
        Role GetRoleAsync(Guid id);
        IList<Role> GetRolesAsync();
        IList<Role> GetSelectedRolesAsync(IList<Guid> ids);
    }
}
