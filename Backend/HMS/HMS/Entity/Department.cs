using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http.HttpResults;

namespace HMS.Entity
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public string Description { get; set; }
        public bool IsDeleted {  get; set; }

    }
}
