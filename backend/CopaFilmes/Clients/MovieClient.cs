using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using CopaFilmes.Models;
using CopaFilmes.Interfaces;

namespace CopaFilmes.Clients
{
    public class MovieClient: IMovieClient
    {
        private HttpClient _httpClient;

        private string baseUrl = "http://copafilmes.azurewebsites.net/api/filmes";

        public MovieClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Movie>> GetAll()
        {
            List<Movie> movies = null;

            var response = await _httpClient.GetAsync(baseUrl);

            if (response.IsSuccessStatusCode)
            {
                movies = await response.Content.ReadAsAsync<List<Movie>>();
            }

            return movies;
        }
    }
}