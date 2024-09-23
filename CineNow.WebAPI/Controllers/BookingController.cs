using CineNow.Application.Features.Movies.Commands.ImportMovies;
using CineNow.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CineNowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("import")]
        public async Task<ActionResult<Result<List<int>>>> ImportMovies()
        {
            return await _mediator.Send(new ImportMoviesCommand());
        }
    }
}
