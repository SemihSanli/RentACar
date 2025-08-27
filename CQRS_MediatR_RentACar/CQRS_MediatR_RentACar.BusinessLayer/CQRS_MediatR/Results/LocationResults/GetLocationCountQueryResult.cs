using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.LocationResults
{
    public class GetLocationCountQueryResult
    {
        public int Count { get; set; }
    }
}
