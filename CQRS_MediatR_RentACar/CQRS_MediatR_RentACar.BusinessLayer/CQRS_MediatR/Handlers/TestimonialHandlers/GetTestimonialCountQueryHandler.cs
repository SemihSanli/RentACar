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
    public class GetTestimonialCountQueryHandler : IRequestHandler<GetTestimonialCountQuery, GetTestimonialCountQueryResult>
    {
        private readonly ITestimonialDal _testimonialDal;

        public GetTestimonialCountQueryHandler(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public async Task<GetTestimonialCountQueryResult> Handle(GetTestimonialCountQuery request, CancellationToken cancellationToken)
        {
            int count = await _testimonialDal.GetTestimonialsCount();
            return new GetTestimonialCountQueryResult { Count = count };
        }
    }
}
