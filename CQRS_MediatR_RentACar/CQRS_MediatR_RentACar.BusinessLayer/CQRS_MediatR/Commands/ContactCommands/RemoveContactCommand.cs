using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.ContactCommands
{
    public class RemoveContactCommand:IRequest
    {
        public int ContactID { get; set; }

        public RemoveContactCommand(int contactID)
        {
            ContactID = contactID;
        }
    }
}
