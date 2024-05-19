using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DwaysWeb.Models
{
    public class Products
    {

        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(150)]
        public string? ProductName { get; set; }

        [StringLength(3000)]
        public string? ProductDescription { get; set; }

        [StringLength(9000)]

        public string? ProductPhoto { get; set; }
        [NotMapped]
        [FileExtensions]
        public IFormFile ImageUpload {  get; set; }  
        [Required]
        
        public decimal ProductPrice { get; set; }
        [Required]
        public int CatergoryId { get; set; }

        public Catergory? Catergory { get; set; }
    }
}
