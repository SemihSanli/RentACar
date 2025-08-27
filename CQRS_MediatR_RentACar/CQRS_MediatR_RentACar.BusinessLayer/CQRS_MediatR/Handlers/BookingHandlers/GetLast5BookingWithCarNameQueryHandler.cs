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
    public class GetLast5BookingWithCarNameQueryHandler : IRequestHandler<GetLast5BookingWithCarNameQuery, List<GetLast5BookingWithCarNameQueryResult>>
    {
        private readonly IBookingDal _bookingDal;

        public GetLast5BookingWithCarNameQueryHandler(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public async Task<List<GetLast5BookingWithCarNameQueryResult>> Handle(GetLast5BookingWithCarNameQuery request, CancellationToken cancellationToken)
        {
            var values = await _bookingDal.GetLast5BookingWithCarName();
            return values.Select(x => new GetLast5BookingWithCarNameQueryResult
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
