using CineNow.Application.DTOs;
using CineNow.Application.Features.Movies.Queries.GetAllMovies;
using CineNow.Application.Features.Movies.Queries.GetMovieById;
using CineNow.Application.Features.Movies.Queries.GetMoviesWithPagination;
using CineNow.Shared;
using CineNow.WebAPI.Controllers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CineNowAPI.Controllers
{
    public class MoviesController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<GetAllMoviesDto>>>> GetMovies()
        {
            return await _mediator.Send(new GetAllMoviesQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<GetMovieByIdDto>>> GetMovieById([FromRoute] int id)
        {
            return await _mediator.Send(new GetMovieByIdQuery(id));
        }

        [HttpGet]
        [Route("paged")]
        public async Task<ActionResult<PaginatedResult<GetMoviesWithPaginationDto>>> GetMoviesWithPagination([FromQuery] GetMoviesWithPaginationQuery query)
        {
            var validator = new GetMoviesWithPaginationValidator();

            // Call Validate or ValidateAsync and pass the object which needs to be validated
            var result = validator.Validate(query);

            if (result.IsValid)
            {
                return await _mediator.Send(query);
            }

            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            return BadRequest(errorMessages);
        }
    }
}
