using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.DTOs.FlightDTO
{
    public class QueryFlightRequestDTO
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string AirportFrom { get; set; } = "";
        public string AirportTo { get; set; } = "";
        public int NumberOfPeople { get; set; }
        public bool IsRoundTrip { get; set; } = false;
        public int Page { get; set; } = 1;
    }
}