using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.DTOs.FlightDTO
{
    public class AddFlightRequestDTO
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int Duration { get; set; }

        public string AirportFrom { get; set; } = "";
        public string AirportTo { get; set; } = "";

        public int Capacity { get; set; }
    }
}