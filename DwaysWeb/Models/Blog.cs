using System.ComponentModel.DataAnnotations;

namespace DwaysWeb.Models
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }

        [Required]
        [StringLength(150)]
        public string? BlogName { get; set; }

        [StringLength(3000)]
        [Required]
        public string? BlogPhoto { get; set; }
    }
}
