using System;
using System.ComponentModel.DataAnnotations;
namespace T2207A_API.Models.Category
{
	public class CreateCategory
	{
		[Required(ErrorMessage = "Please enter category")]
		[MinLength(3, ErrorMessage = "Enter at least 3 characters")]
		[MaxLength(255, ErrorMessage = "Enter up to 255 characters")]
		public string name { get; set; }
	}
}

