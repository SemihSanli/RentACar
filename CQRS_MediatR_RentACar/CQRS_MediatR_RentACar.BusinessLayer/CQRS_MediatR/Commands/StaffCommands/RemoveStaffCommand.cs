using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.StaffCommands
{
    public class RemoveStaffCommand:IRequest
    {
        public int StaffID { get; set; }

        public RemoveStaffCommand(int staffID)
        {
            StaffID = staffID;
        }
    }
}
