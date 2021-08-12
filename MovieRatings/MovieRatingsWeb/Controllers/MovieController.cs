using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using MovieRatingsWeb.Models;
using MovieRatingsLib;

namespace MovieRatingsWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private MovieRater _movieRater;

        public MovieController(MovieRater movieRater)
        {
            _movieRater = movieRater;
        }

        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return _movieRater.GetAllMovies();
        }   

        [HttpPost]
        public void CreateNew(MovieWebModel model) {
            _movieRater.AddMovie(model.Title, model.Director, model.Year, new List<string>());
        }

        [HttpDelete("{id}")]
        public void DeleteMovie(Guid id) {
            _movieRater.DeleteMovie(id);
        }





        // [HttpPost("{id}/rate")]
        // public void Rate(Guid id, MovieRatingWebModel model) {
        //     _movieRater.RateMovie(id, model.Rating, model.Review, model.Username);
        // }
    }

}
