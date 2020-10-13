using CopaFilmes.Builders;
using CopaFilmes.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace CopaFilmes.Services
{
    public class WorldCupService
    {

        private MovieService _movieService = new MovieService();
        private WorldCupBuilder _worldCupBuilder = new WorldCupBuilder();

        public WorldCup Create(List<string> movieIds)
        {
            var movies = _movieService.GetByMovieId(movieIds);

            return _worldCupBuilder.Build(movies);
        }
    }
}
