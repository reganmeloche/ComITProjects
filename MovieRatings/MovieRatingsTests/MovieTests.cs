using System;
using System.Collections.Generic;
using Xunit;

using MovieRatingsLib;
using MovieRatingsListDB;

namespace MovieTests
{
    public class MovieTests
    {
        [Fact]
        public void TestValidRatings()
        {
            var sut = new Movie("Jurassic Park", "Steve Spielberg", 1993, new List<string>());

            var rating1 = new Rating(3, "ok", "test");
            var rating2 = new Rating(4, "ok", "test");
            sut.Rate(rating1);
            sut.Rate(rating2);

            Assert.Equal(3.5, sut.AverageRating);
        }
    }
}
