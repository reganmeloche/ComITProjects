using System;
using System.Collections.Generic;

namespace Unit3ExamplesHint
{
    /*
    Challenge:
    - 1. Add a data member for a unique Id to the Movie class
    - 2. Add a data member for a collection of numerical ratings
    - 3. Add a constructor that initializes all the data members of a movie
    - 4. Add a method that allows you to add a rating between 1 and 5 (inclusive) to the movie
    - 5. Add a mechanism that allows you to get the average rating of a movie
    */
    public class Movie {
        /*** Constructors ***/
        public Movie(/* Add in parameters*/) {
            // Add constructor code here (#3)
        }
        
        /*** Data members ***/
        // Add Id data member here (#1)
        public string Title { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }

        // Add List<int> data member here (#2)

        
        
        /*** Methods ***/
        public void RateMovie(int rating) {
            // Code for adding a rating goes here (#4)
        }

        public float GetAverageRating() {
            // Code for calculating the average rating goes here (#5)
            return 0f;
        }

        public void PrintDetails() {
            Console.WriteLine($"Movie Title: {Title}");
            Console.WriteLine($"Director: {Director}");
            Console.WriteLine($"Year: {Year}\n");
        }
    }

}
