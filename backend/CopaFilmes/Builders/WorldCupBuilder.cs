using CopaFilmes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmes.Builders
{
    public class WorldCupBuilder
    {
        private WorldCupGameBuilder _worldCupGameBuilder = new WorldCupGameBuilder();
        public WorldCup Build(List<Movie> movies)
        {

            var worldCupGame = _worldCupGameBuilder.build(movies);

            return new WorldCup 
            { 
                WorldCupGame = worldCupGame
            };
        }
    }
}
