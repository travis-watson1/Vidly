using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Models;
using Vidly.Models.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        public IActionResult Edit(int id)
        {
            return Content("id=" + id);
        }


        // movies
        public IActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }        
        
        
        public IActionResult Details(int id)
        {
            var movies = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movies == null)
            {
                return NotFound();
            }

            return View(movies);
        }

        public IActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }


        public IActionResult Save()
        {
            throw new NotImplementedException();
        }

        
        [Route("movies/released/{year:regex(\\d{{4}})}/{month:regex(\\d{{2}}):range(1,12)}")]
        public IActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }


    }
}
