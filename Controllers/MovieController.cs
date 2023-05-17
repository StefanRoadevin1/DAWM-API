using DAWM_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DAWM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        public static readonly List<Movie> movies = new List<Movie> { new Models.Movie() { Id = 1, Title = "Marksman", Category = "Thriller",ReleaseYear=2022, Rating = 5, MainActor = "Liam Neeson" } };

        [HttpGet]
        public IActionResult GetAllmovies()
        {
            return Ok(movies);
        }

        [HttpPost]
        public IActionResult CreateMovie([FromBody] Movie newMovie)
        {
            try
            {
                movies.Add(newMovie);
                return Ok(newMovie);
            }
            catch (Exception ex)
            {
                return BadRequest("Cannot add new movie");
            }
        }

        [HttpPut]
        public IActionResult UpdateMovie([FromBody] Movie updatedMovie)
        {
            var movieToUpdate = movies.FirstOrDefault(i => i.Id == updatedMovie.Id);
            if (movieToUpdate == null)
            {
                return NotFound("Invalid movie ID");
            }

            movieToUpdate.Title = updatedMovie.Title;
            movieToUpdate.Category = updatedMovie.Category;
            movieToUpdate.Rating = updatedMovie.Rating;
            movieToUpdate.ReleaseYear = updatedMovie.ReleaseYear;
            movieToUpdate.MainActor = updatedMovie.MainActor;
            return Ok(movieToUpdate);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie([FromBody] Movie deleteMovie)
        {
            var movieToDelete = movies.FirstOrDefault(i => i.Id == deleteMovie.Id);
            if (movieToDelete == null)
            {
                return NotFound("Invalid movie ID");
            }

            movies.Remove(movieToDelete);
            return Ok(movieToDelete);
        }
    }
}
