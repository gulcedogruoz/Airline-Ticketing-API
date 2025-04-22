using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.DTOs.FlightDTO
{
    public class QueryPassengerListRequestDTO
    {
        public string FlightNumber { get; set; } = "";
        public DateTime Date { get; set; }
        public int Page { get; set; } = 1;
    }
}