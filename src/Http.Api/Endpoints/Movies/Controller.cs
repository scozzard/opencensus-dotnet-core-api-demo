using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Http.Api.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Http.Api.Endpoints.Movies
{
    [ApiController]
    [Route("movies")]
    public class Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var movies = new List<Movie>
            {
                new Movie()
                {
                    Id = 1,
                    Title = "Broken Arrow",
                    Cast = "John Travolta, Christian Slater, Samantha Mathis",
                    Genre = "Action, Adventure, Thriller",
                    Year = 1996
                },
                new Movie()
                {
                    Id = 2,
                    Title = "Michael",
                    Cast = "John Travolta, Andie MacDowell",
                    Genre = "Comedy, Drama, Fantasy",
                    Year = 1996
                },
                new Movie()
                {
                    Id = 3,
                    Title = "Phenomenon",
                    Cast = "John Travolta, Kyra Sedgwick, Forest Whitaker",
                    Genre = "Drama, Fantasy, Romance",
                    Year = 1996
                }
            };
            
            return Ok(movies);
        }
    }
}