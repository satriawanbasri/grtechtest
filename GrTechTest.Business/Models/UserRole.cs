using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrTechTest.Business.Models
{
    public class UserRole : Base
    {
        [MaxLength(128), Required, Index("IX_UserId_RoleId", 1, IsUnique = true)]
        public string UserId { get; set; }
        public User User { get; set; }
        [MaxLength(128), Required, Index("IX_UserId_RoleId", 2, IsUnique = true)]
        public string RoleId { get; set; }
        public Role Role { get; set; }
    }
}