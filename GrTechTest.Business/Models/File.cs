using System.ComponentModel.DataAnnotations;

namespace GrTechTest.Business.Models
{
    public class File : Base
    {
        [MaxLength(256)]
        public string FileName { get; set; }
        [MaxLength(128)]
        public string ContentType { get; set; }
        [Required]
        public byte[] DataByte { get; set; }
    }
}