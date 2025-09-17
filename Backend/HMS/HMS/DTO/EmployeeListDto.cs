namespace HMS.DTO
{
    public class EmployeeListDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Qualification { get; set; } = string.Empty;
        public Guid DepartmentId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string RoleName { get; set; }
    }
}
