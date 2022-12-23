using API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class UserDTO
    {
        //[Required]
        //public string UserName { get; set; }
        //[Required]
        //[DataType(DataType.Password)]
        //public string Password { get; set; }

        public int uId { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<int> roleId { get; set; }

        public virtual role role { get; set; }
    }
}