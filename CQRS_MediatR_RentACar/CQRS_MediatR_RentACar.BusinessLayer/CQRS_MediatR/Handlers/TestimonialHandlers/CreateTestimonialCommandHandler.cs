using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.TestimonialCommands;
using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using CQRS_MediatR_RentACar.DataAccessLayer.EntityFramework;
using CQRS_MediatR_RentACar.EntityLayer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.TestimonialHandlers
{
    public class CreateTestimonialCommandHandler : IRequestHandler<CreateTestimonialCommand>
    {
        private readonly ITestimonialDal _testimonialDal;

        public CreateTestimonialCommandHandler(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public async Task Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
        {
            await _testimonialDal.InsertAsync(new Testimonial
            {
                TestimonialComment = request.TestimonialComment,
                TestimonialImageURL = request.TestimonialImageURL,
                TestimonialName = request.TestimonialName,
                TestimonialReviewScore = request.TestimonialReviewScore,
                TestimonialTitle = request.TestimonialTitle,
            });
        }
    }
}
