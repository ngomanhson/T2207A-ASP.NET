using System;
using System.ComponentModel.DataAnnotations;
namespace T2207A_MVC.Models.Brand
{
	public class ViewModel
	{
        [Required(ErrorMessage = "Please enter a brand name")]
        [MinLength(6, ErrorMessage = "Please enter a minimum of 6 characters")]
        [Display(Name = "Name")]
        public string name { get; set; }

    }
}

