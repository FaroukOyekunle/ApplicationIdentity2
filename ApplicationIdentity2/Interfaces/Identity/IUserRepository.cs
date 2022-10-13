using ApplicationIdentity2.Identity;

namespace ApplicationIdentity2.Interfaces.Identity
{
    public interface IUserRepository
    {
        User AddUserAsync(User user);
        User UpdateUserAsync(User user);
        bool DeleteUserAsync(User user);
        User GetUserAsync(Guid id);
        User GetUserAsync(string username);
        IList<User> GetUsersAsync();
        IList<string> GetUserRolesAsync(User user);
    }
}
