using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using CopaFilmes.Models;
using CopaFilmes.Interfaces;

namespace CopaFilmes.Services
{
    public class MovieService: IMovieService
    {
        private IMovieClient _movieClient;

        public MovieService (IMovieClient movieClient)
        {
            _movieClient = movieClient;
        }
        
        public async Task<List<Movie>> GetAll()
        {
            return await _movieClient.GetAll();
        }

        public async Task<List<Movie>> GetByMovieId(List<string> movieIds)
        {
            var movieIdsSet = movieIds.ToHashSet();

            var movies = await GetAll();

            return movies.Where(movie => movieIdsSet.Contains(movie.Id)).ToList();
        }
    }
}
