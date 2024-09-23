using AutoMapper;
using CineNow.Application.Common.Mappings;
using CineNow.Application.Interfaces.Repositories;
using CineNow.Domain.Common.Enums;
using CineNow.Domain.Entities;
using CineNow.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CineNow.Application.Features.Movies.Commands.CreateMovie
{
    public record CreateMovieCommand : IRequest<Result<int>>, IMapFrom<Movie>
    {
        public int? Rank { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? BigImageUrl { get; set; }
        public List<string>? Genre { get; set; }
        public string? ThumbnailUrl { get; set; }
        public string? Rating { get; set; }
        public int? Year { get; set; }
        public string? ImdbId { get; set; }
        public string? ImdbLink { get; set; }
        public List<Showtime>? Showtimes { get; set; }
        public List<Language>? AudioLanguages { get; set; }
        public List<Language>? SubtitleLanguages { get; set; }
    }

    internal class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateMovieCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateMovieCommand command, CancellationToken cancellationToken)
        {
            var movie = new Movie()
            {
                Title = command.Title,
                Rating = command.Rating,
                Year = command.Year,
                BigImageUrl = command.BigImageUrl,
                Description = command.Description,
                Genre = command.Genre,
                Image = command.Image,
                ImdbId = command.ImdbId,
                ImdbLink = command.ImdbLink,
                Rank = command.Rank,
                ThumbnailUrl = command.ThumbnailUrl,
            };

            await _unitOfWork.Repository<Movie>().AddAsync(movie);
            movie.AddDomainEvent(new MovieCreatedEvent(movie));
            await _unitOfWork.SaveAsync(cancellationToken);
            return await Result<int>.SuccessAsync(movie.Id, "Movie Created.");
        }
    }
}
