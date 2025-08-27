using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.CarCommands
{
    public class RemoveCarCommand:IRequest
    {
        public int CarID { get; set; }

        public RemoveCarCommand(int carID)
        {
            CarID = carID;
        }
    }
}
