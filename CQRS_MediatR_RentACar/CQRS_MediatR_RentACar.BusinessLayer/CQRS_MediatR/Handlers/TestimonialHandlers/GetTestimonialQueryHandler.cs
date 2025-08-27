using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.TestimonialQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.StaffResults;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.TestimonialResults;
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
    public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryResult>>
    {
        private readonly ITestimonialDal _testimonialDal;

        public GetTestimonialQueryHandler(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
        {
            var values = await _testimonialDal.GetListAsync();
            return values.Select(x => new GetTestimonialQueryResult
            {
                TestimonialTitle = x.TestimonialTitle,
                TestimonialReviewScore = x.TestimonialReviewScore,
                TestimonialName = x.TestimonialName,
                TestimonialComment = x.TestimonialComment,
                TestimonialImageURL = x.TestimonialImageURL,
                TestimonialID = x.TestimonialID,
            }).ToList();
        }
    }
}
