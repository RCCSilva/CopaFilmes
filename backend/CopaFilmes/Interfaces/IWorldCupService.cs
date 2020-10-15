using System.Collections.Generic;
using CopaFilmes.Models;
using System.Threading.Tasks;

namespace CopaFilmes.Interfaces
{
    public interface IWorldCupService
    {
        Task<WorldCup> Create(List<string> movieIds);
    }
}