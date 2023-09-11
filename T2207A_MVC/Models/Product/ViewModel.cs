using System;
using System.ComponentModel.DataAnnotations;

namespace T2207A_MVC.Models.Product
{
	public class ViewModel
	{
        [Required(ErrorMessage = "Please enter a product name")]
        [MinLength(6, ErrorMessage = "Please enter a minimum of 6 characters")]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Please enter price")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        [Display(Name = "Price")]
        public double price { get; set; }

        [Required(ErrorMessage = "Please select a category")]
        [Display(Name = "Category")]
        public string category { get; set; }

        [Required(ErrorMessage = "Please select a brand")]
        [Display(Name = "Brand")]
        public string brand { get; set; }

        [Required(ErrorMessage = "Please enter a description for the product")]
        [Display(Name = "Description")]
        public string description { get; set; }

        [Required]
        [Display(Name = "Image")]
        public string image { get; set; }
    }
}

