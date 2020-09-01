using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions.Impl;
using MovieRentalWebApplication.Models;

namespace MovieRentalWebApplication.Controllers
{
    public class MoviesController : Controller
    {
        VideoRentalDbContext db = new VideoRentalDbContext();
        // GET: Movies
        public ActionResult Index()
        {
            List<Movie> movies = db.Movies.ToList();
            return View(movies);
        }

        public ActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMovie(Movie movie)
        {
            db.Movies.Add(movie);
            db.SaveChanges();
            return RedirectToAction("Index","Movies");
        }

        public ActionResult EditMovie(int Id)
        {
            Movie movie = db.Movies.Where(s => s.Id == Id).SingleOrDefault();
            return View(movie);
        }

        [HttpPost]
        public ActionResult EditMovie(Movie movie)
        {
            Movie existingMovie = db.Movies.Where(s => s.Id == movie.Id).SingleOrDefault();

            if(existingMovie!=null)
            {
                existingMovie.Name = movie.Name;
                existingMovie.Genere = movie.Genere;
                existingMovie.ReleaseDate = movie.ReleaseDate;
                existingMovie.NumberOfStock = movie.NumberOfStock;

                db.SaveChanges();
            }
            return RedirectToAction("Index","Movies");
        }
    }
}