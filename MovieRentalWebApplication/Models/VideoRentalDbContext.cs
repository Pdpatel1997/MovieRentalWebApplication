using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieRentalWebApplication.Models
{
    public class VideoRentalDbContext:DbContext
    {
        public VideoRentalDbContext() : base(@"Data Source=DESKTOP-HA86C8R; initial catalog=VedioRentalDatabase; integrated security=true" )
        { 
        
        }

        public DbSet<Movie> Movies{ get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Rental> Rentals { get; set; }
    }
}