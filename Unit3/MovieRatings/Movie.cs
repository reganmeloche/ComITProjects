using System;
using System.Collections.Generic;

namespace MovieRatings
{
    class Movie {
        static int minimumRating = 1;
        static int maximumRating = 5;

        // Public properties (Get only)
        public string Title { get; private set; }

        public string Director { get; private set; }

        public int RuntimeInMinutes { get; private set; }

        public int Year {get; private set;}

        public string Genre { get; private set; }

        // Private data
        List<int> ratings;

        // Constructor: Special method to build object
        // When you instantiate the movie with a 2 strings and an int, this constructor gets called
        // example: var someMovie = new Movie("Toy Story", "Unkown", 1995);
        public Movie(string theTitle, string theDirector, int theYear) {

            if (theYear < 1895 || theYear > DateTime.Now.Year) {
                throw new Exception("Invalid year");
            } 
            
            Title = theTitle;
            Director = theDirector;
            Year = theYear;
            ratings = new List<int>();
        }


        /*** Public methods ***/
        public void ChangeMovieInfo(string newTitle, string newDirector) {
            // Validation...
            Title = newTitle;
            Director = newDirector;
        }

        // Class method. Since it is public, we can access it from the Main function
        // Since it is a class method (defined in the class), it hsa access to the data members of the class
        public void PrintDetails() {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Director: {Director}");
            Console.WriteLine($"Year: {Year}");
            Console.WriteLine($"Runtime: {RuntimeInMinutes}");
            //Console.WriteLine($"Rating: {rating}");
            //Console.WriteLine($"Total Rating: {totalRating}");
            Console.WriteLine("-------------");
        }

        // Rate the movie with a value from 1-5
        public void Rate(int theRating) {
            // enforce that theRating is between and including 1-5
            if (theRating >= minimumRating && theRating <= maximumRating) {
                ratings.Add(theRating);
            } else {
                throw new Exception("Invalid rating entered");
            }
        }

        // Get an average rating for the movie
        public double GetAverageRating() {
            double sum = 0;
            for (int i = 0; i < ratings.Count; i++) {
                sum += ratings[i];
            }

            double averageRating = sum / ratings.Count;
            double roundedRating = Math.Round(averageRating, 2);
            return roundedRating;
        }


        public static bool IsRatingValid(int potentialRating) {
            if (potentialRating >= minimumRating && potentialRating <= maximumRating) {
                return true;
            } else {
                return false;
            }
        }
    }
}