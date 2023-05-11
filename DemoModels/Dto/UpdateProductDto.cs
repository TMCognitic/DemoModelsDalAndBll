using System.ComponentModel.DataAnnotations;

namespace DemoModels.Dto
{
    public class UpdateProductDto
    {
        [Required]
        [Range(0.01, double.MaxValue)]
        public double Price
        {
            get; set;
        }
    }
}
