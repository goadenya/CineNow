using AutoMapper;
using AutoMapper.QueryableExtensions;
using CineNow.Application.Interfaces.Repositories;
using CineNow.Domain.Entities;
using CineNow.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CineNow.Application.Features.Movies.Queries.GetAllMovies
{
    public record GetAllMoviesQuery : IRequest<Result<List<GetAllMoviesDto>>>;

    internal class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, Result<List<GetAllMoviesDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllMoviesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllMoviesDto>>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            var movies = await _unitOfWork.Repository<Movie>().Entities
                   .ProjectTo<GetAllMoviesDto>(_mapper.ConfigurationProvider)
                   .ToListAsync(cancellationToken);

            return await Result<List<GetAllMoviesDto>>.SuccessAsync(movies);
        }
    }
}
