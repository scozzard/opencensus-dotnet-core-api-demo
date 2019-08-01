using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Http.Api.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Http.Api.Endpoints.Actors
{
    [ApiController]
    [Route("actors")]
    public class Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var actors = new List<Actor>
            {
                new Actor()
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Travolta"
                }
            };
            
            return Ok(actors);
        }
    }
}