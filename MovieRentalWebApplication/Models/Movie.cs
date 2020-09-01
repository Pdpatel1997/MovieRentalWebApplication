using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace MovieRentalWebApplication.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genere { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int NumberOfStock { get; set;}
        public int NumberAvailable { get; set; }
    }
}