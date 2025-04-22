using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.DTOs.FlightDTO
{
    public class QueryFlightResponseDTO
    {
        public string FlightNumber { get; set; } = "";
        public int Duration { get; set; }

    }
}