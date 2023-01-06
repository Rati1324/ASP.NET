using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class MovieDTO
    {
        public int movieId { get; set; }
        public string name { get; set; }
        public Nullable<int> genreId { get; set; }

    }
}