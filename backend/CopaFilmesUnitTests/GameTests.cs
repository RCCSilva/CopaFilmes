using CopaFilmes.Models;
using System;
using Xunit;

namespace CopaFilmesUnitTests
{
    public class GameTests
    {
        [Theory]
        [InlineData(1, 0, true)]
        [InlineData(10, 9.999, true)]
        [InlineData(-1, -2, true)] // Não é esperado
        [InlineData(0, 1, false)]
        [InlineData(9.999, 10, false)]
        [InlineData(-2, -1, false)]
        public void Winner_GivenWinnerAWithHigherRating_ReturnWinnerAAsWinner(
            decimal ratingA, 
            decimal ratingB,
            bool isFirstWinner
            )
        {
            var movieA = new Movie { Rating = ratingA };
            var movieB = new Movie { Rating = ratingB };

            var game =  new Game
            {
                MovieA = movieA,
                MovieB = movieB
            };

            var expectedWinner = isFirstWinner ? movieA : movieB;
            var expectedLooser = isFirstWinner ? movieB : movieA;

            Assert.Equal(expectedWinner, game.Winner);
            Assert.Equal(expectedLooser, game.Looser);
        }


        [Theory]
        [InlineData("One Ring to Rule Them All", "Another Ring Which Will not Rule", false)]
        // Without space
        [InlineData("AZ", "AA", false)]
        [InlineData("AA", "AZ", true)]
        // With space
        [InlineData("A Z", "A A", false)]
        [InlineData("A A", "A Z", true)]
        // Difference between lower case and upper case
        [InlineData("a", "A", true)]
        [InlineData("A", "a", false)]
        public void Winner_GivenMoviesWithEqualRating_ReturnWinnerWithSmallerTitle(
            string titleA, 
            string titleB,
            bool isFirstWinner
            )
        {
            var movieA = new Movie { Title = titleA, Rating = 8.0m };
            var movieB = new Movie { Title = titleB, Rating = 8.0m };

            var game = new Game
            {
                MovieA = movieA,
                MovieB = movieB
            };


            var expectedWinner = isFirstWinner ? movieA : movieB;
            var expectedLooser = isFirstWinner ? movieB : movieA;

            Assert.Equal(expectedWinner, game.Winner);
            Assert.Equal(expectedLooser, game.Looser);
        }
    }
}
