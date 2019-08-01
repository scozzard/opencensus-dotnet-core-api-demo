using System.Collections.Generic;
using Http.Api.Domain;
using Http.Api.Endpoints.Movies;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Http.Api.Tests.Unit.Endpoints.Movies
{
    public class ControllerTests
    {
        [Fact]
        public void GetAll_Should_Return_A_List_Of_Movies_That_Were_Released_In_The_Nineties_And_Star_John_Travolta()
        {
            //-- Arrange
            var controller = new Controller();
            
            //-- Act
            var result = controller.GetAll();
            
            //-- Assert
            var response = Assert.IsType<OkObjectResult>(result);
            var responseObject = Assert.IsType<List<Movie>>(response.Value);

            foreach (var movie in responseObject)
            {
                Assert.Contains("John Travolta", movie.Cast);
                Assert.True(movie.Year > 1989 && movie.Year < 2000);     
            }
        }
    }
}