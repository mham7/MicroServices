using System.ComponentModel.DataAnnotations;

namespace ProductService.Model.Dto.Colour
{
    public class UpdateColourDto
    {
        [Required]
        public int ColorId { get; set; }

        [Required]
        public required string ColorName { get; set; }
    }
}
