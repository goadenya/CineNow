using CineNow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CineNow.Application.Interfaces.Repositories
{
    public interface IMovieRepository
    {
        Task<Movie> GetMovieByImdbIdAsync(string imdbId);
    }
}
