using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Models
{
    public class Ticket
    {
        public int Id{ get; set; }

        public string FlightNumber { get; set; } = "";
        public Flight Flight { get; set; }

        public int PassengerId { get; set; }
        public Passenger Passenger { get; set; } 

        public bool IsCheckedIn { get; set; } = false;
        public int? SeatNumber { get; set; }

        
    }
}