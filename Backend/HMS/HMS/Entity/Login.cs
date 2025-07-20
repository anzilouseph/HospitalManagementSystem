using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;

namespace HMS.Entity
{
    [Table("LoginTable")]
    public class Login
    {
        [Key]
        public Guid LoginId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool IsDeleted { get; set; }
        

    }
}
