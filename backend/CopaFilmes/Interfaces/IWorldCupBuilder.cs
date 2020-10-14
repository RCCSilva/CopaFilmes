using System.Collections.Generic;
using CopaFilmes.Models;

namespace CopaFilmes.Interfaces
{
    public interface IWorldCupBuilder
    {
        WorldCup Build(List<Movie> movies);
    }
}