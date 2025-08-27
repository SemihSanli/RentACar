using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.TestimonialCommands;
using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using CQRS_MediatR_RentACar.DataAccessLayer.EntityFramework;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.TestimonialHandlers
{
    public class RemoveTestimonialCommandHandler : IRequestHandler<RemoveTestimonialCommand>
    {
        private readonly ITestimonialDal _testimonialDal;

        public RemoveTestimonialCommandHandler(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public async Task Handle(RemoveTestimonialCommand request, CancellationToken cancellationToken)
        {
            var values = await _testimonialDal.GetByIdAsync(request.TestimonialID);
            await _testimonialDal.DeleteAsync(values);
        }
    }
}
