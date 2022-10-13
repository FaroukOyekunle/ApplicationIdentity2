using ApplicationIdentity2.Entities;

namespace ApplicationIdentity2.Interfaces.Repositories
{
    public interface IStaffRepository
    {
        Staff AddStaffAsync(Staff staff);
        Staff UpdateStaffAsync(Staff staff);
        bool DeleteStaffAsync(Staff staff);
        Staff GetStaffAsync(Guid id);
        IList<Staff> GetStaffsAsync();
    }
}
