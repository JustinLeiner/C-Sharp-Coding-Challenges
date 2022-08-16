using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcmeFlix.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AcmeFlix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieManagementController : Controller
    {

        private IMovieRepository _movieRepository = new InMemoryMovieRepository();

        /*
         * Gets all the movies
         */
        [HttpGet]
        public async Task<ActionResult<List<MovieManagement>>> Get()
        {
            var movies = _movieRepository.GetAll();
            return Ok(movies);
        }

        /*
         * Gets a movie based on the passed in Id
         */
        [HttpGet("{Id}")]
        public async Task<ActionResult<MovieManagement>> Get (int Id)
        {
            var movie = _movieRepository.GetAll().Where(movie => movie.Id == Id);
            if (movie == null)
                return BadRequest("--Movie not found--");
            return Ok(movie);
        }

        /*
         * Adds a Movie to the MovieManagement List
         */
        [HttpPost]
        public async Task<ActionResult<List<MovieManagement>>> AddMovie(MovieManagement movie)
        {
            var movieInList = _movieRepository.GetAll().FirstOrDefault(m => m.Equals(movie));
            if(movieInList == null)
            {
                var allMovies = _movieRepository.Add(movie);
                return Ok(allMovies);
            }
            else
            {
                return BadRequest("Movie already exists in list");
            }
        }

        /*
         * Locates an existing Movie and updates its details
         */
        [HttpPut]
        public async Task<ActionResult<List<MovieManagement>>> UpdateMovie(MovieManagement requestChanges)
        {
            var movie = _movieRepository.GetAll().FirstOrDefault(movie => movie.Id == requestChanges.Id);
            if (movie == null)
                return BadRequest("Movie not found.");

            _movieRepository.Update(movie, requestChanges);
            return Ok(_movieRepository.GetAll());
        }

        /*
         * Locates an existing Movie based on its Id and deletes it
         */
        [HttpDelete("{Id}")]
        public async Task<ActionResult<MovieManagement>> Delete(int Id)
        {
            var movie = _movieRepository.GetAll().Where(movie => movie.Id == Id);
            if (movie == null)
                return BadRequest("Movie not found.");
            var DeleteMovie = _movieRepository.Delete((MovieManagement)movie);
            return Ok(_movieRepository.GetAll());
        }


    }
}