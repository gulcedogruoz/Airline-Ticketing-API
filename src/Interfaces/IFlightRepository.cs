using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.DTOs.FlightDTO;
using src.Models;

namespace src.Interfaces
{
    public interface IFlightRepository
    {
        Task<Flight> AddFlightAsync(Flight flightModel);
        Task<List<Flight>> GetAllFlights();
        Task<List<PassengerInfoResponseDTO>> GetPassengerListWithTicketsAsync(string flightNumber, DateTime date, int page, int pageSize);
    }
}