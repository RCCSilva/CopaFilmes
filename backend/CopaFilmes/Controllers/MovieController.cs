using CopaFilmes.Models;
using CopaFilmes.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CopaFilmes.Interfaces;

namespace CopaFilmes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController: Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService) {
            _movieService = movieService;
        }

        public async Task<IEnumerable<Movie>> Get()
        {
            var movies = await _movieService.GetAll();
            return movies;
        }
    }
}
