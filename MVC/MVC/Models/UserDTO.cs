using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class UserDTO
    {
        public int UserId { get; set; }
        [Required(ErrorMessage ="This field is required")]
        public string Username { get; set; }
        [Required(ErrorMessage ="This field is required")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8)]
        public string Password { get; set; }
        public Nullable<int> Role { get; set; }
    }
}