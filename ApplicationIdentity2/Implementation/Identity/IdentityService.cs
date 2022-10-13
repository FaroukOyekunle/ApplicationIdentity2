using ApplicationIdentity2.Identity;
using ApplicationIdentity2.Interfaces.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace ApplicationIdentity2.Implementation.Identity
{
    public class IdentityService: IIdentityService
    {
        private readonly IUserRepository? _userRepository;
        private readonly IHttpContextAccessor? _contextAccessor;
        private readonly IConfiguration? _configuration;

        public IdentityService(IUserRepository? userRepository, IHttpContextAccessor? contextAccessor, IConfiguration? configuration)
        {
            _userRepository = userRepository;
            _contextAccessor = contextAccessor;
            _configuration = configuration;
        }

        public bool CheckPasswordAsync(User user, string password)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            if (user.Password == password)
            {
                return true;
            }
            return false;
        }

        public User FindByUserNameAsync(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException(nameof(userName));
            }
            var user = _userRepository.GetUserAsync(userName);
            return user;
        }

        public IList<string> GetRolesAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            var roles = _userRepository.GetUserRolesAsync(user);
            return roles;
        }

        public string GetUserIdentity()
        {
            var user = _contextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return user;
        }

        public void SetUserClaimsAsync(User user, IEnumerable<string> roles)
        {
            IList<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.UserName)
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authenticationProperties = new AuthenticationProperties();
            var principal = new ClaimsPrincipal(claimsIdentity);
            _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);
        }
    }
}
