using AutoMapper;
using CineNow.Application.Interfaces.Repositories;
using CineNow.Domain.Entities;
using CineNow.Shared;
using MediatR;

namespace CineNow.Application.Features.Movies.Queries.GetMovieById
{
    public class GetMovieByIdQuery : IRequest<Result<GetMovieByIdDto>>
    {
        public int Id { get; set; }

        public GetMovieByIdQuery()
        {
            
        }

        public GetMovieByIdQuery(int id)
        {
            Id = id;
        }
    }

    internal class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, Result<GetMovieByIdDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetMovieByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetMovieByIdDto>> Handle(GetMovieByIdQuery query, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<Movie>().GetByIdAsync(query.Id);

            var movie = _mapper.Map<GetMovieByIdDto>(entity);

            return await Result<GetMovieByIdDto>.SuccessAsync(movie);
        }
    }
}
