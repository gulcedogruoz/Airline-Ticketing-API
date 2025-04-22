using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.DTOs.FlightDTO
{
    public class CheckInResponseDTO
    {
        public string Status { get; set; }  = "";
        public int? SeatNumber { get; set; } 
    }
}