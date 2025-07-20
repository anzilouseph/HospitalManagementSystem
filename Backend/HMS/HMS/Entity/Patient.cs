using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http.HttpResults;

namespace HMS.Entity
{
    [Table("Patient")]
    public class Patient
    {
        [Key]
        public Guid PatientId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; } = 0;
        public string Dob { get; set; } = string.Empty;
        public string ImageUrl { get; set; }
        public bool IsDeleted { get; set; }
        public string Password {  get; set; }
        public string Salt { get; set; }

        public Login LogDetails {get;set;}

    }
}
