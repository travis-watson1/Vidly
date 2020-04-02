using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
using Vidly.Models.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer{Name="Customer 1"},
                new Customer{Name="Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            return Content("id=" + id);
        }


        public IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie{ Id=1, Name="Shrek"},
                new Movie{ Id=2, Name="Wall-e"}
            };
        }


        // movies
        public IActionResult Index()
        {
            var movies = GetMovies();
            return View(movies);
        }


        [Route("movies/released/{year:regex(\\d{{4}})}/{month:regex(\\d{{2}}):range(1,12)}")]
        public IActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }




    }
}
