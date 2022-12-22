using API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class BookDTO
    {
        [Key]
        public int bookId { get; set; }
        public string name { get; set; }
        public Nullable<int> genreId { get; set; }

        //public virtual genre genre { get; set; }
    }
}