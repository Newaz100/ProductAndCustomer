using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductAndCustomer.DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; } // For identifying existing products during updates

        [Required]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity must be zero or a positive number.")]
        public int StockQuantity { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Category cannot exceed 50 characters.")]
        public string Category { get; set; }
    }
}