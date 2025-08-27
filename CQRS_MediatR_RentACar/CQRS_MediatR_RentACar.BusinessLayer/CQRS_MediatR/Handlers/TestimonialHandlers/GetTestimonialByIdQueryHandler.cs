using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.TestimonialQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.TestimonialResults;
using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.TestimonialHandlers
{
    public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdResult>
    {
        private readonly ITestimonialDal _testimonialDal;

        public GetTestimonialByIdQueryHandler(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public async Task<GetTestimonialByIdResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _testimonialDal.GetByIdAsync(request.TestimonialID);
            return new GetTestimonialByIdResult
            {
                TestimonialID = values.TestimonialID,
                TestimonialComment = values.TestimonialComment,
                TestimonialImageURL = values.TestimonialImageURL,
                TestimonialName = values.TestimonialName,
                TestimonialReviewScore = values.TestimonialReviewScore,
                TestimonialTitle = values.TestimonialTitle,
            };
        }
    }
}
