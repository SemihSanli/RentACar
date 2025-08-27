using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.SendMessageCommands
{
    public class CreateSendMessageCommand:IRequest
    {
        public string SenderName { get; set; }
        public string SenderSurname { get; set; }
        public string SenderPhone { get; set; }
        public string SenderSubject { get; set; }
        public string SenderMessage { get; set; }
        public string SenderEmail { get; set; }
    }
}
