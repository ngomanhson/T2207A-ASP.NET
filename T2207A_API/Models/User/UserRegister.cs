using System;
using System.ComponentModel.DataAnnotations;
namespace T2207A_API.Models.User
{
    public class UserRegister
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string full_name { get; set; }
        [Required]
        [MinLength(6)]
        public string password { get; set; }
    }
}
