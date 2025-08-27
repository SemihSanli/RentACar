using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.EntityLayer
{
    public class Booking
    {
        public int BookingID { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }

        public int CarID { get; set; }
        public Car Car { get; set; }
    }
}
