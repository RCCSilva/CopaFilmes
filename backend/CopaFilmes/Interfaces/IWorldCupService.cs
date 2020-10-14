using System.Collections.Generic;
using CopaFilmes.Models;

namespace CopaFilmes.Interfaces
{
    public interface IWorldCupService
    {
        WorldCup Create(List<string> movieIds);
    }
}