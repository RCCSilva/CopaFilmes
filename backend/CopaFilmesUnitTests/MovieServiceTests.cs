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
    public class MovieServiceTests: IDisposable
    {

        private MovieService _movieService;
        private Mock<IMovieClient> _movieClient;

        public MovieServiceTests()
        {
            _movieClient = new Mock<IMovieClient>();
            _movieService = new MovieService(_movieClient.Object);
        }

        public void Dispose() {}

        [Fact]
        public async void GetAll_GivenMovieListFromHttpClient_ReturnMovieList() 
        {
            // Arrange
            var movies = new List<Movie>();
            
            _movieClient.Setup(x => x.GetAll())
                .Returns(Task.FromResult(movies));

            // Act
            var moviesResponse = await _movieService.GetAll();

            // Assert
            Assert.Equal(movies, moviesResponse);
            Assert.Empty(moviesResponse);
        }

        [Fact]
        public async void GetByMovieId_GivenEmptyList_returnEmptyList()
        {
            // Arrange
            var movies = new List<Movie>();
            
            _movieClient.Setup(x => x.GetAll())
                .Returns(Task.FromResult(movies));

            var movieIds = new List<string>(new string[] { "id1", "id2", "id3" });

            // Act
            var moviesResponse = await _movieService.GetByMovieId(movieIds);

            // Assert
            Assert.Equal(movies, moviesResponse);
            Assert.Empty(moviesResponse);
        }

        [Fact]
        public async void GetByMovieId_GivenMovieListWithoutMatch_returnEmptyList()
        {
            // Arrange
            var movies = new List<Movie>(new Movie[] { new Movie{Id = "id10" }});
            
            _movieClient.Setup(x => x.GetAll())
                .Returns(Task.FromResult(movies));

            var movieIds = new List<string>(new string[] { "id1", "id2", "id3" });

            // Act
            var moviesResponse = await _movieService.GetByMovieId(movieIds);

            // Assert
            Assert.Empty(moviesResponse);
        }

        [Fact]
        public async void GetByMovieId_GivenMovieListWitMatch_returnMovieList()
        {
            // Arrange
            var movies = new List<Movie>(new Movie[] { new Movie{Id = "id1" }});
            
            _movieClient.Setup(x => x.GetAll())
                .Returns(Task.FromResult(movies));

            var movieIds = new List<string>(new string[] { "id1", "id2", "id3" });

            // Act
            var moviesResponse = await _movieService.GetByMovieId(movieIds);

            // Assert
            Assert.Equal(movies, moviesResponse);
            Assert.Single(moviesResponse);
        }

        [Fact]
        public async void GetByMovieId_GivenMovieListWithMultipleMatches_returnMovieList()
        {
            // Arrange
            var movies = new List<Movie>(new Movie[] { new Movie{ Id = "id1" }, new Movie{ Id = "id3" }});
            
            _movieClient.Setup(x => x.GetAll())
                .Returns(Task.FromResult(movies));

            var movieIds = new List<string>(new string[] { "id1", "id2", "id3" });

            // Act
            var moviesResponse = await _movieService.GetByMovieId(movieIds);

            // Assert
            Assert.Equal(2, moviesResponse.Count);
            Assert.Equal(moviesResponse, moviesResponse);
        }
    }
}