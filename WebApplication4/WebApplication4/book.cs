//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication4
{
    using System;
    using System.Collections.Generic;
    
    public partial class book
    {
        public int bookId { get; set; }
        public string name { get; set; }
        public Nullable<int> categoryId { get; set; }
        public Nullable<int> genreId { get; set; }
    
        public virtual productCategory productCategory { get; set; }
        public virtual genre genre { get; set; }
    }
}
