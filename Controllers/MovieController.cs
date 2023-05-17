using DAWM_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DAWM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        public static readonly List<Movie> movies = new List<Movie> { new Models.Movie() { Id = "1", Title = "Marksman", Category = "Thriller", Image = "https://m.media-amazon.com/images/M/MV5BMzI4M2E5ZWYtOGIxMy00ZWI4LTkxMzMtZGFiNWJkOWU5MzgwXkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_.jpg", Rating = 5, MainActor = "Liam Neeson" } };

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
                newMovie.Id = System.Guid.NewGuid().ToString();

                movies.Add(newMovie);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Cannot add new movie");
            }
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateMovie([FromRoute] string id, [FromBody] Movie updatedMovie)
        {
            var movieToUpdate = movies.FirstOrDefault(i => i.Id == id);
            if (movieToUpdate == null)
            {
                return NotFound("Invalid movie ID");
            }

            movieToUpdate.Title = updatedMovie.Title;
            movieToUpdate.Category = updatedMovie.Category;
            movieToUpdate.Rating = updatedMovie.Rating;
            movieToUpdate.Image = updatedMovie.Image;
            movieToUpdate.MainActor = updatedMovie.MainActor;
            return Ok(movieToUpdate);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(string id)
        {
            var movieToDelete = movies.FirstOrDefault(i => i.Id == id);
            if (movieToDelete == null)
            {
                return NotFound("Invalid movie ID");
            }

            movies.Remove(movieToDelete);
            return Ok(movieToDelete);
        }
    }
}
