using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace MovieRentalWebApplication.Models
{
    public class Rental
    {
        public int id { get; set; }
        [Required]
        public Customer Customer { get; set; }
        [Required]
        public Movie Movie { get; set; }
        public DateTime DateRanted { get; set; }
        public DateTime? DateReturned{ get; set; }
    }
}