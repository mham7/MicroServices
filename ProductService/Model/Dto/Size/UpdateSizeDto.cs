using System.ComponentModel.DataAnnotations;

namespace ProductService.Model.Dto.Size
{
    public class UpdateSizeDto
    {
        [Required]
        public int SizeId { get; set; }

        [Required]
        public string SizeName { get; set; } = null!;
    }
}
