using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.TestimonialCommands
{
    public class CreateTestimonialCommand:IRequest
    {
        public string TestimonialName { get; set; }
        public string TestimonialTitle { get; set; }
        public string TestimonialReviewScore { get; set; }
        public string TestimonialComment { get; set; }
        public string TestimonialImageURL { get; set; }
    }
}
