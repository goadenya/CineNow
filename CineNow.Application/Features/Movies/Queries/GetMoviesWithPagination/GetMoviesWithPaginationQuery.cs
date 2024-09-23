using AutoMapper;
using AutoMapper.QueryableExtensions;
using CineNow.Application.Extensions;
using CineNow.Application.Features.Movies.Queries.GetMoviesWithPagination;
using CineNow.Application.Interfaces.Repositories;
using CineNow.Domain.Common.Enums;
using CineNow.Domain.Entities;
using CineNow.Shared;
using MediatR;
using System.Linq.Dynamic.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineNow.Application.Features.Movies.Queries.GetMoviesWithPagination
{
    public record GetMoviesWithPaginationQuery : IRequest<PaginatedResult<GetMoviesWithPaginationDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string OrderOption { get; set; } = "Rank";

        public GetMoviesWithPaginationQuery() { }

        public GetMoviesWithPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}

internal class GetMoviesWithPaginationQueryHandler : IRequestHandler<GetMoviesWithPaginationQuery, PaginatedResult<GetMoviesWithPaginationDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetMoviesWithPaginationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PaginatedResult<GetMoviesWithPaginationDto>> Handle(
        GetMoviesWithPaginationQuery query, 
        CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Movie>().Entities
            .ProjectTo<GetMoviesWithPaginationDto>(_mapper.ConfigurationProvider)
            .ToPaginatedListAsync(query.PageNumber, query.PageSize, query.OrderOption, cancellationToken);
    }
}
