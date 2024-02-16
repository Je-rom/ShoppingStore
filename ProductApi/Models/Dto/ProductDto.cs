using System.ComponentModel.DataAnnotations;

namespace ProductApi.Models.Dto
{
    public class ProductDto
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public int Name { get; set; }
        [Range(1, 1000)]
        public int Price { get; set; }
        public int Description { get; set; }
        public int CategoryName { get; set; }
        public int ImageUrl { get; set; }
    }
}
