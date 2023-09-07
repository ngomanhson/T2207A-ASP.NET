using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace T2207A_MVC.Entities
{
	[Table("brands")]
	public class Brand
	{
		[Key]
		public int id { get; set; }

		[Required]
		public string name { get; set; }

        public ICollection<Product> products { get; set; }
    }
}

