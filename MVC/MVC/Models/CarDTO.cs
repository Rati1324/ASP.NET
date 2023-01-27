using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class CarDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Nullable<int> Role { get; set; }
    }
}