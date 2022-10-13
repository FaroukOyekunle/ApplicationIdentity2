using ApplicationIdentity2.Identity;
using ApplicationIdentity2.Interfaces.Identity;
using ApplicationIdentity2.Interfaces.Services;

namespace ApplicationIdentity2.Implementation.Services
{
    public class RoleService: IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public Role AddRoleAsync(Role role)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteRoleAsync(Role role)
        {
            throw new System.NotImplementedException();
        }

        public Role GetRoleAsync(Guid id)
        {
            throw new System.NotImplementedException();
        }

        public IList<Role> GetRolesAsync()
        {
            var roles = _roleRepository.GetRolesAsync();
            return roles;
        }

        public Role UpdateRoleAsync(Role role)
        {
            throw new System.NotImplementedException();
        }
    }
}
