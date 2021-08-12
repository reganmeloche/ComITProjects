using System;
using System.Collections.Generic;
using Xunit;

using MovieRatingsLib;
using MovieRatingsListDB;

namespace MovieRatingsTests
{
    public class MovieRaterTests
    {
        [Fact]
        public void TestValidRatings()
        {
            var storage = new MovieStoreList();
            var sut = new MovieRater(storage);

            var movie = sut.AddMovie("Jurassic Park", "Steve Spielberg", 1993, new List<string>());
            sut.RateMovie(movie.Id, 4, "ok", "test");
            sut.RateMovie(movie.Id, 3, "ok", "test");

            Assert.Equal(3.5, movie.AverageRating);
        }

        [Fact]
        public void TestInvalidRating()
        {
            var storage = new MovieStoreList();
            var sut = new MovieRater(storage); // sut = system under test

            var movie = sut.AddMovie("Jurassic Park", "Steven Spielberg", 1993, new List<string>());

            Assert.Throws<Exception>(() => sut.RateMovie(movie.Id, 6, "ok", "test"));
        }

        [Fact]
        public void TestInvalidMovie()
        {
            var storage = new MovieStoreList();
            var sut = new MovieRater(storage); // sut = system under test
            
            var movie = sut.AddMovie("Jurassic Park", "Steven Spielberg", 1993, new List<string>());
            var invalidGuid = Guid.NewGuid();

            Assert.Throws<Exception>(() => sut.RateMovie(invalidGuid, 2, "ok", "test"));
        }
    }
}
