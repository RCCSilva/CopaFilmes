using CopaFilmes.Builders;
using CopaFilmes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CopaFilmesUnitTests
{
    public class WorldCupGameBuilderTests
    {

        private WorldCupGameBuilder _worldCupGameBuilder = new WorldCupGameBuilder();

        [Theory]
        [InlineData(7)]
        [InlineData(9)]
        public void build_GivenArrayOfMoviesWithLessThanOrGreaterThan8Movies_ThrowException(int size)
        {
            // Given
            var movies = Enumerable.Range(1, size).Select(x => new Movie());

            // Test -- Assert
            Assert.Throws<ArgumentException>(() => _worldCupGameBuilder.Build(movies.ToList()));
        }

        [Fact]
        public void build_Given8Movies_ReturnCorrectWorldCupGameTree()
        {
            // Given
            var movies = new List<Movie>();
            movies.Add(createMovie("Os Incríveis 2", 8.5m));
            movies.Add(createMovie("Jurassic World: Reino Ameaçado", 6.7m));
            movies.Add(createMovie("Oito Mulheres e um Segredo", 6.3m));
            movies.Add(createMovie("Hereditário", 7.8m));
            movies.Add(createMovie("Vingadores: Guerra Infinita", 8.8m));
            movies.Add(createMovie("Deadpool 2", 8.1m));
            movies.Add(createMovie("Han Solo: Uma História Star Wars", 7.2m));
            movies.Add(createMovie("Thor: Ragnarok", 7.9m));

            // Test
            var worldCupGame = _worldCupGameBuilder.Build(movies);

            // Assert
            Assert.Equal("Vingadores: Guerra Infinita", worldCupGame.Game.Winner.Title);
            Assert.Equal(8.8m, worldCupGame.Game.Winner.Rating);
        }

        private Movie createMovie(string title, decimal rating)
        {
            return new Movie
            {
                Title = title,
                Rating = rating
            };
        }
    }
}
