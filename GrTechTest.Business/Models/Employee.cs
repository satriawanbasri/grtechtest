using System.ComponentModel.DataAnnotations;

namespace GrTechTest.Business.Models
{
    public class Employee : Base
    {
        [MaxLength(256), Required]
        public string FirstName { get; set; }
        [MaxLength(256), Required]
        public string LastName { get; set; }
        [MaxLength(256)]
        public string FullName { get; set; }
        [MaxLength(128)]
        public string CompanyId { get; set; }
        public Company Company { get; set; }
        [MaxLength(256)]
        public string Email { get; set; }
        [MaxLength(128)]
        public string Phone { get; set; }
    }
}