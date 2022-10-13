namespace ApplicationIdentity2.DTOs
{
    public class StaffDto
    {
        public Guid StaffId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? StaffNumer { get; set; }
    }

    public class StaffResponseModel : BaseResponse
    {
        public StaffDto? Data { get; set; }
    }

    public class StaffsResponseModel : BaseResponse
    {
        public IList<StaffDto>? Data { get; set; }
    }

    public class CreateStaffRequestModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public IList<Guid> UserRoles { get; set; } = new List<Guid>();
    }

    public class LoginStaffResponseModel
    {
        public string? Email { get; set; }
        public string? Password { get; set; }    

    }
}
