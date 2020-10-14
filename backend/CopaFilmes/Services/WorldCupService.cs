using CopaFilmes.Builders;
using CopaFilmes.Models;
using System.Collections.Generic;
using CopaFilmes.Interfaces;

namespace CopaFilmes.Services
{
    public class WorldCupService: IWorldCupService
    {

        private readonly IMovieService _movieService;
        private readonly IWorldCupBuilder _worldCupBuilder;

        public WorldCupService(IMovieService movieService, IWorldCupBuilder worldCupBuilder) {
            _movieService = movieService;
            _worldCupBuilder = worldCupBuilder;
        }

        public WorldCup Create(List<string> movieIds)
        {
            var movies = _movieService.GetByMovieId(movieIds);

            return _worldCupBuilder.Build(movies);
        }
    }
}
