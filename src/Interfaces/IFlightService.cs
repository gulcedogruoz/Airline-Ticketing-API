using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.DTOs.FlightDTO;
using src.Models;

namespace src.Interfaces
{
    public interface IFlightService
    {
        Task<Flight> AddFlightService(Flight flightModel);
        Task<List<QueryFlightResponseDTO>> SearchFlightsAsync(QueryFlightRequestDTO request);
        Task<List<PassengerInfoResponseDTO>> GetPassengerListAsync(string flightNumber, DateTime date, int page);

    }
}