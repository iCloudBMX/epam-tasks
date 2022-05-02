using System.ComponentModel.DataAnnotations;

namespace MvcPrinciples.Models
{
    public class EditProductViewModel
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        
        [Required]
        public decimal Price { get; set; }

        [Required]
        [MinLength(10)]
        public string QuantityPerUnit { get; set; }
    }
}
