using CopaFilmes.Models;
using System.Collections.Generic;
using CopaFilmes.Interfaces;

namespace CopaFilmes.Builders
{
    public class WorldCupBuilder: IWorldCupBuilder
    {
        private readonly IWorldCupGameBuilder _worldCupGameBuilder;

        public WorldCupBuilder(IWorldCupGameBuilder worldCupGameBuilder) {
            _worldCupGameBuilder = worldCupGameBuilder;
        }

        public WorldCup Build(List<Movie> movies)
        {
            var worldCupGame = _worldCupGameBuilder.Build(movies);

            return new WorldCup 
            { 
                WorldCupGame = worldCupGame
            };
        }
    }
}
