using System;
using System.Collections.Generic;
using PasswordGenerator;

namespace MovieRatings
{
    class MovieRunner
    {
        public static void Run()
        {
            // Instantiating a new movie.
            // Since I've passed in three arguments (string, string, int), it builds the object using the constructor with 3 arguments
            var myMovie = new Movie("JurassicPark", "Steven Spielberg", 1993);

            myMovie.ChangeMovieInfo("Jurassic Park", "Steven Spielberg");

            // PrintDetails is a public method on the Movie class, so we can access it from Main
            // Note that the fields that were not assigned in the constructor are given default values 
            myMovie.PrintDetails();

            int requiredNumberOfRatings = 5;
            int currentNumberOfValidRatings = 0;

            while (currentNumberOfValidRatings < requiredNumberOfRatings) {
                Console.WriteLine($"Please enter a rating between 1 and 5 for the movie {myMovie.Title}");
                string userInput = Console.ReadLine();
                
                int intRating = 0; 
                try {
                    intRating = Convert.ToInt32(userInput);
                } catch {
                    Console.WriteLine("Error: Please enter a valid integer between 1 and 5");
                    continue;
                }

                try {
                    myMovie.Rate(intRating);
                    currentNumberOfValidRatings++; 
                }
                catch {
                    Console.WriteLine($"Invalid rating {intRating}");
                } 
            }

            double averageRating = myMovie.GetAverageRating();
            Console.WriteLine($"The average rating is: {averageRating}");
        }

    }
}


/*
var theHashtags = new List<string>(){ "hashtag1", "firstpost" };
// theHashtags.Add("hashtag1");
// theHashtags.Add("firstpost");

var myPost = new Post(
    "Hello, this is my first post!", 
    theHashtags, 
    "test_user");

myPost.PrintDetails();

*/