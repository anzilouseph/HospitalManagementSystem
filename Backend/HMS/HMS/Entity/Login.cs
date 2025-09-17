using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;

namespace HMS.Entity
{
    [Table("Login")]
    public class Login
    {
        [Key]
        public Guid LoginId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } =string.Empty;
        public string Salt { get; set; }
        public Guid RoleId { get; set; }
        public bool IsDeleted { get; set; }
        

    }
}
