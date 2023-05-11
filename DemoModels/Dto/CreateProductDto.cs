using System.ComponentModel.DataAnnotations;

namespace DemoModels.Dto
{
#nullable disable
    public class CreateProductDto
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }
        [Required]
        [Range(0.01, double.MaxValue)]
        public double Price { get; set; }
    }
}
