using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace homework_2.Models {
	public class User {
		public int Id { get; set; }

		[Display(Name = "User Name")]
		[Required(ErrorMessage = "This field is required")]
		[StringLength(5)]
		public string Name { get; set; }

		[Required(ErrorMessage = "This field is required")]
		[Range(18, 100, ErrorMessage = "Must be between 18 and 100")]
		public int Age { get; set; }

		[Required(ErrorMessage = "This field is required")]
		[RegularExpression(".+@.+\\..+", ErrorMessage = "Wrong Email format")]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		[Display(Name="Confirm password")]
		[Compare("Password", ErrorMessage = "Passwords don't match")]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }
	}
}