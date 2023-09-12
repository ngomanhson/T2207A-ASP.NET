using System;
using System.ComponentModel.DataAnnotations;
namespace T2207A_MVC.Models
{
	public class CategoryViewModel
	{
		[Required(ErrorMessage = "Please enter a category name")]
		[MinLength(6, ErrorMessage = "Please enter a minimum of 6 characters")]
		[Display(Name = "Name")]
		public string name { get; set; }
    }
}

