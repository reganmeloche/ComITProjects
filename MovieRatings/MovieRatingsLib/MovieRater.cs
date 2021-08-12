using System;
using System.Collections.Generic;

namespace MovieRatingsLib
{
    public class MovieRater
    {
        IStoreMovies _movieStorage;

        public MovieRater(IStoreMovies movieStorage) {
            _movieStorage = movieStorage;
        }

        public Movie AddMovie(string title, string director, int year, List<string> genres) {
            var newMovie = new Movie(title, director, year, genres);
            _movieStorage.Save(newMovie);
            return newMovie;
        }

        public void DeleteMovie(Guid id) {
            _movieStorage.Remove(id);
        }

        public void RateMovie(Guid movieId, int value, string review, string username) {
            // TODO: Validation: prevent same user from two ratings. Or overwrite?

            var movie = _movieStorage.Get(movieId);
            if (movie != null) {
                var rating = new Rating(value, review, username);
                movie.Rate(rating);
            } else {
                throw new Exception($"Movie {movieId} does not exist");
            }
        }

        public List<Movie> GetAllMovies() {
            return _movieStorage.GetAll();
        }
    }
}
