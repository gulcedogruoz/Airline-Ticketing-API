using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.DTOs.FlightDTO
{
    public class PassengerInfoResponseDTO
    {
        public string PassengerName { get; set; }
        public int? SeatNumber { get; set; }
    }
}