using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.DTOs.FlightDTO
{
    public class BuyTicketResponseDTO
    {
        public string TicketNumber { get; set; } = "";
        public string Status { get; set; } = "";
    }
}