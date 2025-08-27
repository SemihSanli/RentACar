using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.ContactResults
{
    public class GetContactByIdQueryResult
    {
        public int ContactID { get; set; }
        public string Address { get; set; }
        public string MailUs { get; set; }
        public string Phone { get; set; }
        public string Webside { get; set; }
    }
}
