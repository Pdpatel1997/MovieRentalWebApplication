using MovieRentalWebApplication.Dtos;
using MovieRentalWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web.Http;

namespace MovieRentalWebApplication.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        VideoRentalDbContext db;

        public NewRentalsController()
        {
            db = new VideoRentalDbContext();
        }
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            if (newRental.MovieIds.Count == 0)
                return BadRequest("Please select MovieIds");

            var customer = db.Customers.SingleOrDefault(s => s.CustomerId == newRental.CustomerId);
            if (customer == null)
                return BadRequest("Cusomer is not valid");


            var movies = db.Movies.Where(s => newRental.MovieIds.Contains(s.Id)).ToList();

            if (movies.Count != newRental.MovieIds.Count)
                return BadRequest("One or more movie are invalid.");


            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");
                movie.NumberAvailable--;
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRanted = DateTime.Now
                };

                db.Rentals.Add(rental);
            }
            db.SaveChanges();
            return Ok();
        }
    }
}
