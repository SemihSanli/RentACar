using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.CarCommands
{
    public class CreateCarCommand:IRequest
    {
        public string CarImageURL { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public decimal CarReview { get; set; }
        public decimal CarPrice { get; set; }
        public string CarSeat { get; set; }
        public string CarTransmission { get; set; }
        public string CarFuel { get; set; }
        public string CarYear { get; set; }
        public string CarKM { get; set; }
        public string IsAutoOrManual { get; set; }
    }
}
