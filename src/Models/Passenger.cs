using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Models
{
    public class Passenger
    {
        public int Id { get; set; }

        public string FullName { get; set; } = "";
        
        public List<Ticket> Tickets { get; set; } = [];
    }
}