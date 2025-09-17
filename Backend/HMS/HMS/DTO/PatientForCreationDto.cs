namespace HMS.DTO
{
    public class PatientForCreationDto
    {
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public int? Age { get; set; } = 0;
        public string? Dob { get; set; } = string.Empty;
        public IFormFile? ImageUrl { get; set; }
        public string Password { get; set; }

    }
}
