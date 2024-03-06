using System.ComponentModel.DataAnnotations;

namespace ProductService.Model.Dto.Colour
{
    public class AddColourDto
    {
        

        [Required]
        public required string ColorName { get; set; }
    }
}
