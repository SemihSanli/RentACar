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
    public class EfCarDal:GenericRepository<Car>,ICarDal
    {
        private readonly CQRSMediatRDbContext _context;
        public EfCarDal(CQRSMediatRDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> GetCarCount()
        {
            return await _context.Cars.CountAsync();
        }

        public async Task<List<Car>> GetCarsByBrandAsync(string carBrand)
        {
            return await _context.Cars.Where(x=>x.CarBrand==carBrand).ToListAsync();
        }

        public async Task<List<Car>> GetLast4CarAsync()
        {
            var values = await _context.Cars.Take(4).ToListAsync();
            return values;
        }
    }
}
