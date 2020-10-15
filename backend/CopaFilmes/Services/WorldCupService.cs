using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CopaFilmes.Models;
using CopaFilmes.Interfaces;

namespace CopaFilmes.Services
{
    public class WorldCupService: IWorldCupService
    {

        private readonly IMovieService _movieService;
        private readonly IWorldCupBuilder _worldCupBuilder;

        private readonly int worldCupMovieAmount = 8;

        public WorldCupService(IMovieService movieService, IWorldCupBuilder worldCupBuilder) {
            _movieService = movieService;
            _worldCupBuilder = worldCupBuilder;
        }

        public async Task<WorldCup> Create(List<string> movieIds)
        {
            if (movieIds.Count != worldCupMovieAmount)
            {
                throw new ArgumentException("Create should be called with 8 movieIdss");
            }

            var movies = await _movieService.GetByMovieId(movieIds);

            if (movies.Count != worldCupMovieAmount) 
            {
                throw new ArgumentException("Given IDs did not match 8 movies from the database");
            }

            return _worldCupBuilder.Build(movies);
        }
    }
}
