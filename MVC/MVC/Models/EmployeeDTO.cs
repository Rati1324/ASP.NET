using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class EmployeeDTO
    {
        public int EmployeeID { get; set; }
        public string Position { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<int> Salary { get; set; }

        [Required(ErrorMessage ="This field is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="This field is required")]
        public string LastName { get; set; }
    }
}