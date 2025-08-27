using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using CQRS_MediatR_RentACar.DataAccessLayer.Concrete;
using CQRS_MediatR_RentACar.DataAccessLayer.Repositories;
using CQRS_MediatR_RentACar.EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.DataAccessLayer.EntityFramework
{
    public class EfBookingDal:GenericRepository<Booking>,IBookingDal
    {
        private readonly CQRSMediatRDbContext _context;
        public EfBookingDal(CQRSMediatRDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Booking>> GetBookingWithCarName()
        {
            var values = await _context.Bookings.Include(x => x.Car).ToListAsync();
            return values;
        }

        public async Task<List<Booking>> GetLast5BookingWithCarName()
        {
            var values = await _context.Bookings.Include(x => x.Car).Take(5).ToListAsync();
            return values;
        }
    }
}
