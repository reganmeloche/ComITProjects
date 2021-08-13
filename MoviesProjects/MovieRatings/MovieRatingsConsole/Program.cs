using System;
using System.Collections.Generic;

using MovieRatingsLib;
using MovieRatingsListDB;

namespace MovieRatingsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var storage = new MovieStoreList();
            var movieRater = new MovieRater(storage);

            Console.WriteLine("Adding movies...\n");
            var movie1 = movieRater.AddMovie("Jurassic park", "Steven Spielberg", 1993, new List<string>() {"Thriller"});
            var movie2 = movieRater.AddMovie("Toy Story", "John Lasseter", 1995, new List<string>() {"Animation", "Comedy"});
            var movie3 = movieRater.AddMovie("Titanic", "James Cameron", 1997, new List<string>() {"Drama"});

            Console.WriteLine("Enter your username:");
            var username = Console.ReadLine();

            while (true) {
                var allMovies = movieRater.GetAllMovies();
                Console.WriteLine("\n---- All movies ----");
                foreach (var movie in allMovies) {
                    Console.WriteLine(movie.ToString());
                }
                Console.WriteLine("------------------");

                Console.WriteLine("Enter a movie Id to rate it, or q to exit:");
                var userInput = Console.ReadLine();

                if (userInput == "q") { break; }
                var movieId = Guid.Parse(userInput);

                Console.WriteLine("Enter your rating (1-5):");
                var ratingInput = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter a review (<20 words):");
                var reviewInput = Console.ReadLine();

                movieRater.RateMovie(movieId, ratingInput, reviewInput, username);
                Console.WriteLine("Movie rating applied. \n\n");
            }

        }
    }
}
