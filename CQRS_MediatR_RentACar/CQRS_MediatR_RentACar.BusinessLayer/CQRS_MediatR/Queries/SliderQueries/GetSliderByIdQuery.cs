using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.SliderResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.SliderQueries
{
    public class GetSliderByIdQuery:IRequest<GetSliderByIdQueryResult>
    {
        public int SliderID { get; set; }

        public GetSliderByIdQuery(int sliderID)
        {
            SliderID = sliderID;
        }
    }
}
