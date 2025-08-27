using CQRS_MediatR_RentACar.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.DataAccessLayer.Abstract
{
    public interface IBookingDal:IGenericDal<Booking>
    {
        Task<List<Booking>> GetLast5BookingWithCarName();
        Task<List<Booking>> GetBookingWithCarName();
    }
}
