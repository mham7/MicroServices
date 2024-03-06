using System.ComponentModel.DataAnnotations;

namespace ProductService.Model.Dto.Size
{
    public class AddSizeDto
    {

        [Required]
        public string SizeName { get; set; } = null!;
    }
}
