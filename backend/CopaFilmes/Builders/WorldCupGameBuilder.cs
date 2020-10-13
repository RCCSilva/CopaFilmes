using CopaFilmes.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.Builders
{
    public class WorldCupGameBuilder
    {
        public WorldCupGame build(List<Movie> movies)
        {
            if (movies.Count() != 8)
            {
                throw new ArgumentException("Movies list should have exactly 8 movies");
            }

            var firstWorldCupGames = createFirstRound(movies);

            return createWorldCupGame(firstWorldCupGames);
        }

        private WorldCupGame createWorldCupGame(List<WorldCupGame> games)
        {
            if (games.Count() == 1)
            {
                return games.First();
            }

            List<WorldCupGame> worldCupGames = new List<WorldCupGame>();

            for (int i = 0; i < games.Count(); i += 2)
            {
                var myGames = games.GetRange(i, 2);

                var game = new Game
                {
                    MovieA = myGames.First().Game.Winner,
                    MovieB = myGames.Last().Game.Winner
                };
                var worldCupGame = new WorldCupGame
                {
                    Game = game,
                    PriorGameA = myGames.First(),
                    PriorGameB = myGames.Last()
                };

                worldCupGames.Add(worldCupGame);
            }

            return createWorldCupGame(worldCupGames);
        }

        private List<WorldCupGame> createFirstRound(List<Movie> movies)
        {
            movies.Sort();

            var start = 0;
            var end = movies.Count() - 1;

            List<WorldCupGame> games = new List<WorldCupGame>();

            while (start < end)
            {
                var game = new Game
                {
                    MovieA = movies.ElementAt(start),
                    MovieB = movies.ElementAt(end)
                };
                games.Add(new WorldCupGame
                {
                    Game = game,
                    PriorGameA = null,
                    PriorGameB = null
                });

                start += 1;
                end -= 1;
            }

            return games;
        }
    }
}