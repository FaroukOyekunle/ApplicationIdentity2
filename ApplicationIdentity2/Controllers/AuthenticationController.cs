using ApplicationIdentity2.Interfaces.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationIdentity2.Controllers
{
    public class AuthenticationController: Controller
    {
        private readonly IConfiguration _configuration;
        //private readonly UserManager<User> _userManager;
        private readonly IIdentityService _identityService;

        public AuthenticationController(IConfiguration configuration, IIdentityService identityService)
        {
            _configuration = configuration;
            //_userManager = userManager;
            _identityService = identityService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string userName, string password)
        {
            var user = _identityService.FindByUserNameAsync(userName);
            if (user != null)
            {
                var isValidPassword = _identityService.CheckPasswordAsync(user, password);
                if (isValidPassword)
                {
                    var roles = _identityService.GetRolesAsync(user);
                    _identityService.SetUserClaimsAsync(user, roles);
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.Message = "Invalid Credential";
                return View();
            }
            ViewBag.Message = "Invalid Credential";
            return View();
        }


        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
