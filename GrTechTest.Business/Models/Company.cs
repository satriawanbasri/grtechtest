using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GrTechTest.Business.Models
{
    public class Company : Base
    {
        [MaxLength(128), Required]
        public string Name { get; set; }
        [MaxLength(256)]
        public string Email { get; set; }
        [MaxLength(128)]
        public string LogoFileId { get; set; }
        [MaxLength(256)]
        public string Website { get; set; }
        public List<Employee> Employees { get; set; }
    }
}