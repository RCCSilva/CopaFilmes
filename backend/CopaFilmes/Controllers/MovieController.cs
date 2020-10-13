using CopaFilmes.Builders;
using CopaFilmes.Models;
using CopaFilmes.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController: Controller
    {
        private MovieService _movieService = new MovieService();

        public async Task<IEnumerable<Movie>> Get()
        {
            var movies = await _movieService.GetAll();
            return movies;
        }
    }
}
