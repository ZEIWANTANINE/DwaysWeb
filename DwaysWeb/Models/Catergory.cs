using System.ComponentModel.DataAnnotations;

namespace DwaysWeb.Models
{
    public class Catergory
    {
        [Key]
        [Required]
        public int CatergoryId { get; set; }
        [Required]
        
        public string? Name { get; set; }
        [StringLength(300)]
        public string? Slug { get; set; }
    }
}
