using AutoMapper;
using CineNow.Application.Common.Mappings;
using CineNow.Application.Interfaces.RapidMovieService;
using CineNow.Application.Interfaces.Repositories;
using CineNow.Domain.Entities;
using CineNow.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineNow.Application.Features.Movies.Commands.ImportMovies
{
    public class ImportMoviesCommand : IRequest<Result<List<int>>> { }

    internal class ImportMoviesCommandHandler : IRequestHandler<ImportMoviesCommand, Result<List<int>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRapidClient _rapidClient;
        private readonly IMapper _mapper;

        public ImportMoviesCommandHandler(IUnitOfWork unitOfWork, IRapidClient rapidClient, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _rapidClient = rapidClient;
            _mapper = mapper;
        }

        public async Task<Result<List<int>>> Handle(ImportMoviesCommand request, CancellationToken cancellationToken)
        {
            //if (MoviesExists())
            //{
            //    return await Result<List<int>>.SuccessAsync(new List<int>(), "Movies already exists.");
            //}

            List<Movie> movies = await GetMoviesAsync();

            await SaveMoviesAsync(movies, cancellationToken);

            return await Result<List<int>>.SuccessAsync(
                movies.Select(x => x.Id).ToList(), 
                "Movies imported"
                );
        }

        private async Task SaveMoviesAsync(List<Movie> movies, CancellationToken cancellationToken)
        {
            await _unitOfWork.Repository<Movie>().UpdateRangeAsync(movies);

            foreach (var movie in movies)
            {
                movie.AddDomainEvent(new MovieImportedEvent(movie));
            }

            await _unitOfWork.SaveAsync(cancellationToken);
        }

        private async Task<List<Movie>> GetMoviesAsync()
        {
            var movieDtos = await _rapidClient.GetMoviesAsync();

            return movieDtos.Select(x => new Movie()
            {
                CreatedBy = 0,
                CreatedDate = DateTime.Now,
                Title = x.title,
                Description = x.description,
                Year = x.year,
                Image = x.image,
                BigImageUrl = x.big_image,
                Rank = x.rank,
                Rating = x.rating,
                RatingAsNumber = float.Parse(x.rating, CultureInfo.InvariantCulture.NumberFormat),
                ThumbnailUrl = x.thumbnail,
                ImdbLink = x.imdb_link,
                ImdbId = x.imdbid,
                Genre = x.genre,
            }).ToList();
        }

        private bool MoviesExists()
        {
            return _unitOfWork.Repository<Movie>().Entities.Any();
        }
    }
}
