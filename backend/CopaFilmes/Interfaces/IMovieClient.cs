using System;
using System.Collections.Generic;
using CopaFilmes.Models;
using System.Threading.Tasks;

namespace CopaFilmes.Interfaces
{
    public interface IMovieClient
    {
        Task<List<Movie>> GetAll();
    }
}