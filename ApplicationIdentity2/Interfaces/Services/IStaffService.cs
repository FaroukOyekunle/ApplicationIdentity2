using ApplicationIdentity2.DTOs;
using ApplicationIdentity2.Entities;

namespace ApplicationIdentity2.Interfaces.Services
{
    public interface IStaffService
    {
        BaseResponse AddStaffAsync(CreateStaffRequestModel request);
        BaseResponse UpdateStaffAsync(int id, Staff staff);
        bool DeleteStaffAsync(int id);
        StaffResponseModel GetStaffAsync(int id);
        StaffsResponseModel GetStaffsAsync();
    }
}
