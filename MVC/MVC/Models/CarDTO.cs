using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class CarDTO
    {
        public int CarId { get; set; }
        public Nullable<int> Brand { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Model { get; set; }
        public virtual BrandDTO Brand1 { get; set; }
    }
}