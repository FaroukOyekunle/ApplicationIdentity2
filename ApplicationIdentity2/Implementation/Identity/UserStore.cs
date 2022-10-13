using ApplicationIdentity2.Context;
using ApplicationIdentity2.Identity;
using ApplicationIdentity2.Interfaces.Identity;
using Microsoft.EntityFrameworkCore;

namespace ApplicationIdentity2.Implementation.Identity
{
    public class UserStore: IUserRepository
    {
        private readonly ApplicationIdentityContext _applicationIdentityContext;

        public UserStore(ApplicationIdentityContext applicationIdentityContext)
        {
            _applicationIdentityContext = applicationIdentityContext;
        }

        public User AddUserAsync(User user)
        {
            _applicationIdentityContext.Users.Add(user);
            _applicationIdentityContext.SaveChanges();
            return user;
        }

        public bool DeleteUserAsync(User user)
        {
            _applicationIdentityContext.Users.Remove(user);
            _applicationIdentityContext.SaveChanges();
            return true;
        }

        public User GetUserAsync(Guid id)
        {
            var user = _applicationIdentityContext.Users.Include(x => x.UserRoles).ThenInclude(r => r.Role).Where(x => x.Id == id).SingleOrDefault();
            return user;
        }

        public User GetUserAsync(string username)
        {
            var user = _applicationIdentityContext.Users.Include(x => x.UserRoles).ThenInclude(r => r.Role).Where(x => x.UserName == username).SingleOrDefault();
            return user;
        }

        public IList<User> GetUsersAsync()
        {
            var users = _applicationIdentityContext.Users.Include(x => x.UserRoles).ThenInclude(r => r.Role).ToList();
            return users;
        }

        public User UpdateUserAsync(User user)
        {
            _applicationIdentityContext.Users.Update(user);
            _applicationIdentityContext.SaveChanges();
            return user;
        }

        public IList<string> GetUserRolesAsync(User user)
        {
            var userRoles = _applicationIdentityContext.UserRoles.Include(u => u.Role)
                .Where(u => u.User == user)
                .Select(r => r.Role.Name)
                .ToList();
            return userRoles;
        }
    }
}
