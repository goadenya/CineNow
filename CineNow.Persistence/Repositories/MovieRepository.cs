using CineNow.Application.Interfaces.Repositories;
using CineNow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineNow.Persistence.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IGenericRepository<Movie> _repository;

        public MovieRepository(IGenericRepository<Movie> repository)
        {
            _repository = repository;
        }

        public async Task<Movie> GetMovieByImdbIdAsync(string imdbId)
        {
            return await _repository.Entities
                .FirstOrDefaultAsync(x => x.ImdbId == imdbId);
        }
    }
}
