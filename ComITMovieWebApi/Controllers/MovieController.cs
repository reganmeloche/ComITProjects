using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MovieWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        List<Movie> _movieList;

        public MovieController(List<Movie> movieList)
        {
            _movieList = movieList;
        }

        [HttpGet]
        public List<Movie> GetAllMovies()
        {
            return _movieList;
        }

        [HttpPost]
        public string CreateMovie(Movie myNewMovie)
        {   
            myNewMovie.Id = Guid.NewGuid();
            _movieList.Add(myNewMovie);
            return "Creating movie";
        }

        [HttpPut("{id}")]
        public string UpdateMovie(Guid id, Movie movieInfo)
        {
            for (int i = 0; i < _movieList.Count; i++) {
                if (_movieList[i].Id == id) {
                    _movieList[i].Title = movieInfo.Title;
                    _movieList[i].Director = movieInfo.Director;
                    _movieList[i].Year = movieInfo.Year;
                    break;
                }
            }
            return "Updating movie";
        }

        [HttpDelete("{id}")]
        public bool DeleteMovie(Guid id)
        {
            bool foundMovie = false;
            // Need to add logic to delete a movie
            for (int i = 0; i < _movieList.Count; i++) {
                if (_movieList[i].Id == id) {
                    Console.WriteLine("Found movie to delete");
                    _movieList.Remove(_movieList[i]);
                    foundMovie = true;
                    break;
                }
            }

            return foundMovie;
        }
    }
}
