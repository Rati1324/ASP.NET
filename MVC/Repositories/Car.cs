//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Repositories
{
    using System;
    using System.Collections.Generic;
    
    public partial class Car
    {
        public int CarId { get; set; }
        public Nullable<int> Brand { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Model { get; set; }
        public virtual Brand Brand1 { get; set; }
    }
}
