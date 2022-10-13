using ApplicationIdentity2.Context;
using ApplicationIdentity2.Identity;
using ApplicationIdentity2.Interfaces.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ApplicationIdentity2.Implementation.Identity
{
    public class RoleStore: IRoleRepository
    {
        private readonly ApplicationIdentityContext _applicationIdentityContext;

        public RoleStore(ApplicationIdentityContext applicationIdentityContext)
        {
            _applicationIdentityContext = applicationIdentityContext;
        }

        public Role AddRoleAsync(Role role)
        {
            _applicationIdentityContext.Roles.Add(role);
            _applicationIdentityContext.SaveChanges();
            return role;
        }

        public bool DeleteRoleAsync(Role role)
        {
            _applicationIdentityContext.Roles.Remove(role);
            _applicationIdentityContext.SaveChanges();
            return true;
        }

        public Role GetRoleAsync(Guid id)
        {
            var role = _applicationIdentityContext.Roles.Include(x => x.UserRoles).ThenInclude(u => u.User).Where(x => x.Id == id).SingleOrDefault();
            return role;
        }

        public IList<Role> GetRolesAsync()
        {
            var roles = _applicationIdentityContext.Roles.Include(x => x.UserRoles).ThenInclude(u => u.User).ToList();
            return roles;
        }

        public IList<Role> GetSelectedRolesAsync(IList<Guid> ids)
        {
            var roles = _applicationIdentityContext.Roles.Where(x => ids.Contains(x.Id)).ToList();
            return roles;
        }

        public Role UpdateRoleAsync(Role role)
        {
            _applicationIdentityContext.Roles.Update(role);
            _applicationIdentityContext.SaveChanges();
            return role;
        }
    }
}
