using ApplicationIdentity2.Identity;

namespace ApplicationIdentity2.Interfaces.Identity
{
    public interface IIdentityService
    {
        User FindByUserNameAsync(string userName);
        bool CheckPasswordAsync(User user, string password);
        IList<string> GetRolesAsync(User user);
        void SetUserClaimsAsync(User user, IEnumerable<string> roles);
        string GetUserIdentity();
    }
}
