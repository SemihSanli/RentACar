using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.BookingResults
{
    public class GetBookingWithCarNameQueryResult
    {
        public int BookingID { get; set; }
        public int CarID { get; set; }
        public string CarModel { get; set; }
        public string CarBrand { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }
    }
}
