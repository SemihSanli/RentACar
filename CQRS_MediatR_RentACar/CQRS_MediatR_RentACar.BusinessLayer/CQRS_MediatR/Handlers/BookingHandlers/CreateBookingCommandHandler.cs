using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.BookingCommands;
using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using CQRS_MediatR_RentACar.EntityLayer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.BookingHandlers
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand>
    {
        private readonly IBookingDal _bookingDal;

        public CreateBookingCommandHandler(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public async Task Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            await _bookingDal.InsertAsync(new Booking
            {
                CarID = request.CarID,
                DropOffDate = request.DropOffDate,
                PickUpDate = request.PickUpDate,
            });
        }
    }
}
