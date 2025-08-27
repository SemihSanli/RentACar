using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.SliderCommands
{
    public class RemoveSliderCommand:IRequest
    {
        public int SliderID { get; set; }

        public RemoveSliderCommand(int sliderID)
        {
            SliderID = sliderID;
        }
    }
}
