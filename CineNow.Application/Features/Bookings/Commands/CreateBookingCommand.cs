using AutoMapper;
using CineNow.Application.Interfaces.Repositories;
using CineNow.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CineNow.Application.Features.Bookings.Commands
{
    //public class CreateBookingCommand : IRequest<Result<int>>, IMapFrom<Booking>
    //{
    //    public int? ShowTimeId { get; set; }
    //    public Guid? Code { get; set; }
    //}

    //internal class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, Result<int>>
    //{
    //    private readonly IUnitOfWork _unitOfWork;
    //    private readonly IMapper _mapper;

    //    public CreateBookingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    //    {
    //        _unitOfWork = unitOfWork;
    //        _mapper = mapper;
    //    }
    //}
}
