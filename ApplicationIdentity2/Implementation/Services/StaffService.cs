using ApplicationIdentity2.DTOs;
using ApplicationIdentity2.Entities;
using ApplicationIdentity2.Identity;
using ApplicationIdentity2.Interfaces.Identity;
using ApplicationIdentity2.Interfaces.Repositories;
using ApplicationIdentity2.Interfaces.Services;

namespace ApplicationIdentity2.Implementation.Services
{
    public class StaffService: IStaffService
    {
        private readonly IStaffRepository _staffRepository;
        private readonly IUserRepository _userRepository;
        private readonly IIdentityService _identityService;
        private readonly IRoleRepository _roleRepository;

        public StaffService(IStaffRepository staffRepository, IUserRepository userRepository, IIdentityService identityService, IRoleRepository roleRepository)
        {
            _staffRepository = staffRepository;
            _userRepository = userRepository;
            _identityService = identityService;
            _roleRepository = roleRepository;
        }

        public BaseResponse AddStaffAsync(CreateStaffRequestModel request)
        {
            var authenticatedUser = int.Parse(_identityService.GetUserIdentity());
            var user = new User
            {
                UserName = request.Email,
                Password = request.Password,
                CreatedBy = authenticatedUser
            };
            _userRepository.AddUserAsync(user);
            var roles = _roleRepository.GetSelectedRolesAsync(request.UserRoles);
            foreach (var role in roles)
            {
                var userRole = new UserRole
                {
                    UserId = user.Id,
                    User = user,
                    RoleId = role.Id,
                    Role = role,
                    CreatedBy = authenticatedUser
                };
                user.UserRoles.Add(userRole);
            }
            _userRepository.UpdateUserAsync(user);
            var staff = new Staff
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                CreatedBy = authenticatedUser,
                StaffNumber = $"SP{Guid.NewGuid().ToString().Substring(0, 6)}",
                UserId = user.Id
            };
            _staffRepository.AddStaffAsync(staff);

            return new BaseResponse
            {
                Status = true,
                Message = "Succesfully added"
            };
        }

        public bool DeleteStaffAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public StaffResponseModel GetStaffAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public StaffsResponseModel GetStaffsAsync()
        {
            throw new System.NotImplementedException();
        }

        public BaseResponse UpdateStaffAsync(int id, Staff staff)
        {
            throw new System.NotImplementedException();
        }
    }
}
