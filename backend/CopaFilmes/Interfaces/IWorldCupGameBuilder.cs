using System.Collections.Generic;
using CopaFilmes.Models;

namespace CopaFilmes.Interfaces
{
    public interface IWorldCupGameBuilder
    {
        WorldCupGame Build(List<Movie> movies);
    }
}