using System;
using System.ComponentModel.DataAnnotations;
namespace T2207A_API.Models.User
{
	public class UserLogin
	{
		[Required]
		public string email { get; set; }

        [Required]
		[MinLength(6)]
        public string password { get; set; }
    }
}

