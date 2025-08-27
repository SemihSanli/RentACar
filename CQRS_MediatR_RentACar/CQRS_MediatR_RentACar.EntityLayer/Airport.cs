using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.EntityLayer
{
    public class Airport
    {
        public int AirportID { get; set; }
        public string Name { get; set; }
        public string Iata { get; set; }
        public string Icao { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int Elevation { get; set; }
        public int Utc_offset { get; set; }
        public string Dst { get; set; }
        public string Timezone { get; set; }
    }
}
