using CineNow.Domain.Common;
using CineNow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineNow.Application.Features.Movies.Commands.ImportMovies
{
    public class MovieImportedEvent : BaseEvent
    {
        public Movie Movies { get; set; }

        public MovieImportedEvent(Movie movie)
        {
            Movies = movie;
        }
    }
}
