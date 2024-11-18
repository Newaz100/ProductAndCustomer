using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductAndCustomer.DTOs
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; } // For identifying existing customers during updates

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format.")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Phone number must be between 10 and 15 characters.")]
        public string Phone { get; set; }

        [StringLength(250, ErrorMessage = "Address cannot exceed 250 characters.")]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        [Display(Name = "Date Joined")]
        public DateTime DateJoined { get; set; }
    }
}