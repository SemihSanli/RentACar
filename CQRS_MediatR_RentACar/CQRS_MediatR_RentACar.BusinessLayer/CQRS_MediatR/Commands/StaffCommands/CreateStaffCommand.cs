using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.StaffCommands
{
    public class CreateStaffCommand:IRequest
    {
        public string StaffImageURL { get; set; }
        public string StaffFullName { get; set; }
        public string StaffTitle { get; set; }
        public string StaffFacebook { get; set; }
        public string StaffLinkedin { get; set; }
        public string StaffX { get; set; }
        public string StaffInstagram { get; set; }
    }
}
