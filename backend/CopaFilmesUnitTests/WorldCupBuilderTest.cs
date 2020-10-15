using CopaFilmes.Builders;
using CopaFilmes.Models;
using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using CopaFilmes.Interfaces;

namespace CopaFilmesUnitTests
{
    public class WorldCupBuilderTest: IDisposable
    {
        private readonly Mock<IWorldCupGameBuilder> _worldCupGameBuilder;
        private readonly WorldCupBuilder _worldCupBuilder;

        public WorldCupBuilderTest()
        {
            _worldCupGameBuilder = new Mock<IWorldCupGameBuilder>();
            _worldCupBuilder = new WorldCupBuilder(_worldCupGameBuilder.Object);
        }

        public void Dispose() {}

        [Fact]
        public void Build_GivenMovies_CallWorldCupGameBuilder() 
        {
            // Arrange
            var worldCupGame = new WorldCupGame();
            _worldCupGameBuilder
                .Setup(x => x.Build(It.IsAny<List<Movie>>()))
                .Returns(worldCupGame);

            // Act
            var worldCup = _worldCupBuilder.Build(new List<Movie>());

            // Assert
            Assert.Equal(worldCupGame, worldCup.WorldCupGame);
        }
    }
}