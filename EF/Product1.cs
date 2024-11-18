using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductAndCustomer.EF
{
    public class Product1
    {
        [Key]
        public int ProductId { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        [Required, StringLength(50)]
        public string Category { get; set; }
    }
}