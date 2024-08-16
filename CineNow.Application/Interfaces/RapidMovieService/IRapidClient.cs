using CineNow.Application.DTOs;
using CineNow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineNow.Application.Interfaces.MoviesService
{
    public interface IRapidClient
    {
        Task<List<RapidMovieDto>> GetMoviesAsync();
    }
}
