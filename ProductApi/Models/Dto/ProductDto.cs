﻿using System.ComponentModel.DataAnnotations;

namespace ServiceEmailApi.Models.Dto
{
    public class ProductDto
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Range(1, 1000)]
        public double Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string? ImageUrl { get; set; }
    }
}
