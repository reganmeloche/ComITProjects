using System;
using System.Collections.Generic;

namespace Unit3Examples
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
        public Movie() {
            Year = 1990;
            Title = "Unkown";
            Director = "Unknown";
            _ratings = new List<int>();
            Id = Guid.NewGuid();
        }


        public Movie(string title, string director, int year) {
            Id = Guid.NewGuid();
            Title = title;
            Director = director;
            Year = year;

            _ratings = new List<int>();
            
        }


        public Guid Id { get; private set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }
        private List<int> _ratings;
        

        // Property approach to average rating
        public double AverageRating { 
            get {
                int sum = 0;

                for (int i = 0; i < _ratings.Count; i++) {
                    sum += _ratings[i];
                }

                double average = (double)sum / (double)_ratings.Count;
                return Math.Round(average, 1);
            }
        }

        public void AddRating(int ratingToAdd) {
            if (ratingToAdd >= 1 && ratingToAdd <= 5) {
                Console.WriteLine($"Added rating of {ratingToAdd} to {Title}.");
                _ratings.Add(ratingToAdd);
            } else {
                throw new Exception($"Invalid rating: {ratingToAdd}. Please enter value between 1 and 5");
            }
            
        }

        // Method approach to average rating
        public double GetAverageRating() {
            int sum = 0;

            for (int i = 0; i < _ratings.Count; i++) {
                sum += _ratings[i];
            }

            double average = (double)sum / (double)_ratings.Count;
            return Math.Round(average, 1);
        }

        public void PrintDetails() {
            Console.WriteLine($"Movie Title: {Title}");
            Console.WriteLine($"Director: {Director}");
            Console.WriteLine($"Year: {Year}\n");
        }
    }

}
