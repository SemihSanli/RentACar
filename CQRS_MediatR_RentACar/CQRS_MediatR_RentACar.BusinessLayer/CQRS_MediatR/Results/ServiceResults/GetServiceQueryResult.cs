using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.ServiceResults
{
    public class GetServiceQueryResult
    {
        public int ServiceID { get; set; }
        public string ServiceEntryTitle { get; set; }
        public string ServiceIconURL { get; set; }
        public string ServiceArticleTitle { get; set; }
        public string ServiceArticleDescription { get; set; }
    }
}
