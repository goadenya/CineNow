using CineNow.Domain.Common;
using CineNow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineNow.Application.Features.Movies.Commands.CreateMovie
{
    public class MovieCreatedEvent : BaseEvent
    {
        public Movie Movie { get; set; }

        public MovieCreatedEvent(Movie movie)
        {
            Movie = movie;
        }
    }
}
