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
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly ITestimonialDal _testimonialDal;

        public UpdateTestimonialCommandHandler(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public  async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var values = await _testimonialDal.GetByIdAsync(request.TestimonialID);
            values.TestimonialImageURL = request.TestimonialImageURL;
            values.TestimonialName = request.TestimonialName;
            values.TestimonialComment = request.TestimonialComment;
            values.TestimonialReviewScore = request.TestimonialReviewScore;
            values.TestimonialTitle = request.TestimonialTitle;
        }
    }
}
