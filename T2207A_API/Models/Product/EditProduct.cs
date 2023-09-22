using System;
using System.ComponentModel.DataAnnotations;

namespace T2207A_API.Models.Product
{
	public class EditProduct
	{
        [Required]
        public int id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Enter at least 3 characters")]
        [MaxLength(255, ErrorMessage = "Enter up to 255 characters")]
        public string name { get; set; }

        [Required(ErrorMessage = "Please enter price")]
        public decimal price { get; set; }

        [Required(ErrorMessage = "Please enter description")]
        public string description { get; set; }

        [Required(ErrorMessage = "Please enter description")]
        [MinLength(10, ErrorMessage = "Enter at least 10 characters")]
        public string thumbnai { get; set; }


        [Required(ErrorMessage = "Please enter qty")]
        public int qty { get; set; }

        [Required(ErrorMessage = "Please enter category")]
        public int category { get; set; }
    }
}

