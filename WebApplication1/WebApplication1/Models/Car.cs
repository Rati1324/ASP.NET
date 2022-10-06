namespace WebApplication1.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Car")]
    public partial class Car
    {
        public int id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public int? year { get; set; }

        public int? horsePower { get; set; }

        public int? transmissionType { get; set; }

        public int? fuelType { get; set; }

        public int? bodyType { get; set; }

        public int? speed { get; set; }

        [Column(TypeName = "money")]
        public decimal? price { get; set; }

        [StringLength(50)]
        public string licenseNumber { get; set; }

        public virtual CarBodyType CarBodyType { get; set; }

        public virtual FuelType FuelType1 { get; set; }

        public virtual TransmissionType TransmissionType1 { get; set; }
    }
}
