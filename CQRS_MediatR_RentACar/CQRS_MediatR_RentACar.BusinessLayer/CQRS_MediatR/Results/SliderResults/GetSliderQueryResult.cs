using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.SliderResults
{
    public class GetSliderQueryResult
    {
        public int SliderID { get; set; }
        public string SliderTitle { get; set; }
        public string SliderSubTitle { get; set; }
    }
}
