using CineNow.Application.DTOs;
using CineNow.Application.Interfaces.RapidMovieService;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CineNow.Infrastructure.Services
{
    public class RapidClient : IRapidClient
    {
        private readonly IConfiguration _configuration;
        public RapidClient(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<RapidMovieDto>> GetMoviesAsync()
        {
            var movieDtoList = new List<RapidMovieDto>();

            using (var client = new HttpClient())
            {
                var response = await client.SendAsync(GetHttpRequestMessage());

                movieDtoList = await ParseResponseToMovieDtos(response);
            }

            return movieDtoList;
        }

        private async Task<List<RapidMovieDto>> ParseResponseToMovieDtos(HttpResponseMessage response)
        {
            var movieDtoList = new List<RapidMovieDto>();

            try
            {
                response.EnsureSuccessStatusCode();

                var movieDtoArray = await response.Content.ReadFromJsonAsync<RapidMovieDto[]>();

                movieDtoList = movieDtoArray.ToList();
            }
            catch (Exception ex)
            {
                new Exception(ex.Message, ex);
            }

            return movieDtoList;
        }

        private HttpRequestMessage GetHttpRequestMessage()
        {
            return new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
                {
                    { "x-rapidapi-key", _configuration["Api:Rapid:Key"] },
                    { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
                },
            };
        }
    }

}

