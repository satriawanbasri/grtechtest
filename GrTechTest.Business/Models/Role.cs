using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrTechTest.Business.Models
{
    public class Role : Base
    {
        [MaxLength(128), Required, Index(IsUnique = true)]
        public string Code { get; set; }
        [MaxLength(256)]
        public string Description { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}