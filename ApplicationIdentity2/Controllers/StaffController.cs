using ApplicationIdentity2.DTOs;
using ApplicationIdentity2.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ApplicationIdentity2.Controllers
{
    public class StaffController: Controller
    {
        private readonly IRoleService _roleService;
        private readonly IStaffService _staffService;
        public StaffController(IStaffService staffService, IRoleService roleService)
        {
            _staffService = staffService;
            _roleService = roleService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult RegisterStaff()
        {
            var roles = _roleService.GetRolesAsync();
            ViewData["Roles"] = new SelectList(roles, "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult RegisterStaff(CreateStaffRequestModel request)
        {
            _staffService.AddStaffAsync(request);
            return RedirectToAction("Index");
        }
    }
}
