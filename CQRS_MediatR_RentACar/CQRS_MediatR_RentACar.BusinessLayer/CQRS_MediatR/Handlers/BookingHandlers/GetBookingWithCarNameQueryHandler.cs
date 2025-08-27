using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.BookingQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.BookingResults;
using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.BookingHandlers
{
    public class GetBookingWithCarNameQueryHandler : IRequestHandler<GetBookingWithCarNameQuery, List<GetBookingWithCarNameQueryResult>>
    {
        private readonly IBookingDal _bookingDal;

        public GetBookingWithCarNameQueryHandler(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public async Task<List<GetBookingWithCarNameQueryResult>> Handle(GetBookingWithCarNameQuery request, CancellationToken cancellationToken)
        {
            var values = await _bookingDal.GetBookingWithCarName();
            return values.Select(x => new GetBookingWithCarNameQueryResult
            {
                BookingID = x.BookingID,
                CarID = x.CarID,
                CarBrand = x.Car.CarBrand,
                CarModel = x.Car.CarModel,
                DropOffDate = x.DropOffDate,
                PickUpDate = x.PickUpDate,
            }).ToList();
        }
    }
}
