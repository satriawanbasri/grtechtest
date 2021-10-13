using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GrTechTest.Business.Models
{
    public class User : Base
    {
        [MaxLength(256), Required]
        public string Email { get; set; }
        [MaxLength(512), Required]
        public string Password { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}