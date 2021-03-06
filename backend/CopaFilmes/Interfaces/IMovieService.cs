using System;
using System.Collections.Generic;
using CopaFilmes.Models;
using System.Threading.Tasks;

namespace CopaFilmes.Interfaces
{
    public interface IMovieService
    {
        Task<List<Movie>> GetAll();
        Task<List<Movie>> GetByMovieId(List<string> movieIds);
    }
}