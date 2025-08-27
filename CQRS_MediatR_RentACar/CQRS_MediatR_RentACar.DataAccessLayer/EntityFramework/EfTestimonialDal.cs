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
    public class EfTestimonialDal:GenericRepository<Testimonial>,ITestimonialDal
    {
        private readonly CQRSMediatRDbContext _context;
        public EfTestimonialDal(CQRSMediatRDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> GetTestimonialsCount()
        {
          return await _context.Testimonials.CountAsync();
           
        }
    }
}
