using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DwaysWeb.Models
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }

        [Required]
        [StringLength(150)]
        public string? BlogName { get; set; }
        public string BlogWriter { get; set; }

        [StringLength(3000)]
        [Required]
        public string? BlogPhoto { get; set; }

        [Required]
        [StringLength(10000)]
        public string BlogDescriptions { get; set; }
        [NotMapped]
        [FileExtensions]
        public IFormFile ImageUpload { get; set; }
        [Required]
        [StringLength(10000)]
        public string BlogArticle {  get; set; }
        public DateTime? BlogDate { get; set; }

    }
}
