using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Models
{
    public class Flight
    {
        public int Id { get; set; }

        public string FlightNumber { get; set; } = "";

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int Duration { get; set; }

        public string AirportFrom { get; set; } = "";
        public string AirportTo { get; set; } = "";

        public int Capacity { get; set; }

        public bool IsRoundTrip { get; set; } = false;
        
        public List<Passenger> Passengers { get; set; } =[];
        public List<Ticket> Tickets { get; set; } = [];
    }
}