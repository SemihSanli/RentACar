namespace CQRS_MediatR_RentACar.UILayer.DTOs.AirportDTOs
{
    public class AirportRapidApiDTO
    {

        public class Rootobject
        {
            public Datum[] data { get; set; }
            public Meta meta { get; set; }
        }

        public class Meta
        {
            public Pagination pagination { get; set; }
        }

        public class Pagination
        {
            public int total { get; set; }
            public int per_page { get; set; }
            public int current_page { get; set; }
            public int last_page { get; set; }
            public int from { get; set; }
            public int to { get; set; }
        }

        public class Datum
        {
            public string name { get; set; }
            public string iata { get; set; }
            public string icao { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public int elevation { get; set; }
            public int utc_offset { get; set; }
            public string dst { get; set; }
            public string timezone { get; set; }
            public Country country { get; set; }
        }

        public class Country
        {
            public string name { get; set; }
            public string iso2 { get; set; }
        }

    }
}
