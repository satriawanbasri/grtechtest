using System;
using System.ComponentModel.DataAnnotations;

namespace GrTechTest.Business.Models
{
    public class Base
    {
        [MaxLength(128), Required]
        public string Id { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime UpdatedOn { get; set; }
        [MaxLength(128), Required]
        public string CreatedBy { get; set; }
        [MaxLength(128), Required]
        public string UpdatedBy { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    }
}