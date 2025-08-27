using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.EntityLayer
{
    public class Location
    {
        public int LocationID { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string StateCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
