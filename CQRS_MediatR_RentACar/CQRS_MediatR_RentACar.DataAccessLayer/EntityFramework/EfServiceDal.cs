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
    public class EfServiceDal:GenericRepository<Service>,IServiceDal
    {
        private readonly CQRSMediatRDbContext _context;
        public EfServiceDal(CQRSMediatRDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> ServiceCount()
        {
            return await _context.Services.CountAsync();
        }
    }
}
