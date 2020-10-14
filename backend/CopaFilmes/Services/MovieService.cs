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
        private HttpClient client = new HttpClient();
        
        public async Task<List<Movie>> GetAll()
        {
            List<Movie> movies = null;

            var response = await client.GetAsync("http://copafilmes.azurewebsites.net/api/filmes");

            if (response.IsSuccessStatusCode)
            {
                movies = await response.Content.ReadAsAsync<List<Movie>>();
            }

            return movies;
        }

        public List<Movie> GetByMovieId(List<string> movieIds)
        {
            var movieIdsSet = movieIds.ToHashSet();

            var movies = GetAll().Result;

            return movies.Where(movie => movieIdsSet.Contains(movie.Id)).ToList();
        }
    }
}
