using HMS.Entity;

namespace HMS.DTO
{
    public class EmployeeForCreationDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public string? Phone { get; set; }
        public string? Qualification { get; set; }
        public Guid RoleId { get; set; }
        public Guid DepartmentId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? Password { get; set; }    
    }
}
