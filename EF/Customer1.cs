using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductAndCustomer.EF
{
    public class Customer1
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Phone number must be between 10 and 15 digits")]
        public string Phone { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Joined")]
        public DateTime DateJoined { get; set; }
    }
}