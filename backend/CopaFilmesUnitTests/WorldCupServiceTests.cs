using CopaFilmes.Builders;
using CopaFilmes.Models;
using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using CopaFilmes.Interfaces;
using System.Net.Http;
using CopaFilmes.Services;
using System.Threading.Tasks;

namespace CopaFilmesUnitTests
{
    public class WorldCupServiceTests: IDisposable
    {

        private WorldCupService _worldCupService;
        
        private Mock<IMovieService> _movieService;
        private Mock<IWorldCupBuilder> _worldCupBuilder; 

        public WorldCupServiceTests()
        {
            _movieService = new Mock<IMovieService>();
            _worldCupBuilder = new Mock<IWorldCupBuilder>();
            _worldCupService = new WorldCupService(_movieService.Object, _worldCupBuilder.Object);
        }

        public void Dispose() {}

        [Fact]
        public async void Create_GivenLessThan8MovieIds_ThrowException() {
            // Arrange
            var movieIds = new List<string>(
                 new string[] {"id1", "id2", "id3", "id4", "id5", "id6", "id7" }
            );
            var movies = new List<Movie>();

            _movieService.Setup(x => x.GetByMovieId(movieIds))
                .Returns(Task.FromResult(movies));

            // Act
            var ex = await Assert.ThrowsAsync<ArgumentException>(async () => 
                await _worldCupService.Create(movieIds)
            );

            // Assert
            Assert.Equal("Create should be called with 8 movieIdss", ex.Message);
        }

        [Fact]
        public async void Create_Given8MovieIdsIfReturnedMovieListLessThan8_ThrowException() {
            // Arrange
            var movieIds = new List<string>(
                 new string[] {"id1", "id2", "id3", "id4", "id5", "id6", "id7", "id8" }
            );
            var movies = new List<Movie>(
                new Movie[] { new Movie { Id = "id1" } }
            );

            _movieService.Setup(x => x.GetByMovieId(movieIds))
                .Returns(Task.FromResult(movies));

            // Act
            var ex = await Assert.ThrowsAsync<ArgumentException>(async () => 
                await _worldCupService.Create(movieIds)
            );

            // Assert
            Assert.Equal("Given IDs did not match 8 movies from the database", ex.Message);
        }

        [Fact]
        public async void Create_Given8MovieIdsIfReturns8Movies_ReturnWorldCup() {
            // Arrange
            var movieIds = new List<string>(
                 new string[] {"id1", "id2", "id3", "id4", "id5", "id6", "id7", "id8" }
            );
            var movies = new List<Movie>(
                new Movie[] { 
                    new Movie { Id = "id1" },
                    new Movie { Id = "id2" },
                    new Movie { Id = "id3" },
                    new Movie { Id = "id4" },
                    new Movie { Id = "id5" },
                    new Movie { Id = "id6" },
                    new Movie { Id = "id7" },
                    new Movie { Id = "id8" }
                }
            );

            var worldCup = new WorldCup();

            _movieService.Setup(x => x.GetByMovieId(movieIds))
                .Returns(Task.FromResult(movies));

            _worldCupBuilder.Setup(x => x.Build(movies))
                .Returns(worldCup);

            // Act
            var worldCupResponse = await _worldCupService.Create(movieIds);

            // Assert
            Assert.Equal(worldCup, worldCupResponse);
        }
    }
}