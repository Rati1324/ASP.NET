namespace Midterm.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Car")]
    public partial class Car
    {
		[Key]
        public int id { get; set; }

        [StringLength(50)]
		[Required(ErrorMessage = "This field is required")]
        public string name { get; set; }

		[Range(1970, 2022, ErrorMessage = "Enter a valid year")]
		[Required(ErrorMessage = "This field is required")]
        public int? year { get; set; }


		[Required(ErrorMessage = "This field is required")]
        public int? horsePower { get; set; }

		[Required(ErrorMessage = "This field is required")]
        public int? speed { get; set; }

        [Column(TypeName = "money")]
		[Required(ErrorMessage = "This field is required")]
        public decimal? price { get; set; }
    }
}
