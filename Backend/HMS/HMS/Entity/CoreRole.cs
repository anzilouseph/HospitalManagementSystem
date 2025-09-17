using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http.HttpResults;

namespace HMS.Entity
{
    [Table("CoreRole")]
    public class CoreRole
    {
        [Key]
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsDeleted { get; set; }

    }
}
