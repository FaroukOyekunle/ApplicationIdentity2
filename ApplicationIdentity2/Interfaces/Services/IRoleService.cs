using ApplicationIdentity2.Identity;

namespace ApplicationIdentity2.Interfaces.Services
{
    public interface IRoleService
    {
        Role AddRoleAsync(Role role);
        Role UpdateRoleAsync(Role role);
        bool DeleteRoleAsync(Role role);
        Role GetRoleAsync(Guid id);
        IList<Role> GetRolesAsync();
    }
}
