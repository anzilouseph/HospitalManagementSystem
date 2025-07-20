using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http.HttpResults;

namespace HMS.Entity
{
    [Table("Doctor")]
    public class Doctors
    {
        [Key]
        public Guid DoctorId { get; set; }    
        public string Name { get; set; } = string.Empty;
        public string Qualification { get; set; }
        public string DepartmentId { get; set; } = string.Empty;
        public string Email {  get; set; } = string.Empty;
        public bool IsDelete { get; set; }  

    }
}
