using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.AboutCommands
{
    public class RemoveAboutCommand:IRequest
    {
        public int AboutID { get; set; }

        public RemoveAboutCommand(int aboutID)
        {
            AboutID = aboutID;
        }
    }
}
