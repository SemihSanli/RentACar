using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.EntityLayer
{
    public class Testimonial
    {
        public int TestimonialID { get; set; }
        public string TestimonialName { get; set; }
        public string TestimonialTitle { get; set; }
        public string TestimonialReviewScore { get; set; }
        public string TestimonialComment { get; set; }
        public string TestimonialImageURL { get; set; }
    }
}
