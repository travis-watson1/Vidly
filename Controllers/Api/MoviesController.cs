using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        //GET /api/movies
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IEnumerable<Movie> GetMovies()
        {
            var movies = _context.Movies.ToList();

            return movies;
        }

        //GET /api/movies/1
        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        public async Task<IActionResult> GetMovie([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        //POST /api/movies
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public IActionResult CreateMovie([Microsoft.AspNetCore.Mvc.FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            _context.Movies.Add(movie);
            _context.SaveChanges();

            return Ok(movie);
        }


        // PUT /api/movies/1
        [Microsoft.AspNetCore.Mvc.HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute] int id,
            [Microsoft.AspNetCore.Mvc.FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (movie.Id == 0)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();

        }

        //DELETE /api/movies/1
        [Microsoft.AspNetCore.Mvc.HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie([FromRoute] int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return Ok(movie);
        }
    }
}