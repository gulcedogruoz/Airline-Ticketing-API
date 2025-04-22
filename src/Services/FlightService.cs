using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.DTOs.FlightDTO;
using src.Helpers;
using src.Interfaces;
using src.Models;
using src.Repositories;

namespace src.Services
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IPassengerRepository _passengerRepository;
        public FlightService(IFlightRepository flightRepository, IPassengerRepository passengerRepository)
        {
            _flightRepository = flightRepository;
            _passengerRepository = passengerRepository;
        }

        public async Task<Flight> AddFlightService(Flight flightModel)
        {
            flightModel.FlightNumber = FlightNumberGenerator.GenerateFlightNumber();
            await _flightRepository.AddFlightAsync(flightModel);

            return flightModel;
        }

        public async Task<List<QueryFlightResponseDTO>> SearchFlightsAsync(QueryFlightRequestDTO request)
        {
            var flights = await _flightRepository.GetAllFlights();
            var flightsResponse = flights
                .Where(f =>
                    f.DateFrom >= request.DateFrom &&
                    f.DateTo <= request.DateTo &&
                    f.AirportFrom == request.AirportFrom &&
                    f.AirportTo == request.AirportTo &&
                    (f.Capacity - f.Passengers.Count()) >= request.NumberOfPeople
                )
                .Skip((request.Page - 1) * 10)
                .Take(10)
                .Select(f => new QueryFlightResponseDTO
                {
                    FlightNumber = f.FlightNumber,
                    Duration = f.Duration,
                }).ToList();
            return flightsResponse;
        }
        public async Task<List<PassengerInfoResponseDTO>> GetPassengerListAsync(string flightNumber, DateTime date, int page)
        {
            const int PageSize = 10;
            return await _flightRepository.GetPassengerListWithTicketsAsync(flightNumber, date, page, PageSize);
        }

    }
}