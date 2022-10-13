using ApplicationIdentity2.Context;
using ApplicationIdentity2.Entities;
using ApplicationIdentity2.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ApplicationIdentity2.Implementation.Repositories
{
    public class StaffRepository: IStaffRepository
    {
        private readonly ApplicationIdentityContext _applicationIdentityContext;

        public StaffRepository(ApplicationIdentityContext applicationIdentityContext)
        {
            _applicationIdentityContext = applicationIdentityContext;
        }

        public Staff AddStaffAsync(Staff staff)
        {
            _applicationIdentityContext.Staffs.Add(staff);
            _applicationIdentityContext.SaveChanges();
            return staff;
        }

        public bool DeleteStaffAsync(Staff staff)
        {
            _applicationIdentityContext.Staffs.Remove(staff);
            _applicationIdentityContext.SaveChanges();
            return true;
        }

        public Staff GetStaffAsync(Guid id)
        {
            var staff = _applicationIdentityContext.Staffs.Where(x => x.Id == id).SingleOrDefault();
            return staff;
        }

        public IList<Staff> GetStaffsAsync()
        {
            var staffs = _applicationIdentityContext.Staffs.ToList();
            return staffs;
        }

        public Staff UpdateStaffAsync(Staff staff)
        {
            _applicationIdentityContext.Staffs.Update(staff);
            _applicationIdentityContext.SaveChanges();
            return staff;
        }
    }
}
