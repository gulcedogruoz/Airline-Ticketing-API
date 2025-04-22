using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Data;
using src.DTOs.FlightDTO;
using src.Interfaces;
using src.Models;

namespace src.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly ApplicationDBContext _context;
        public FlightRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Flight> AddFlightAsync(Flight flightModel)
        {
            await _context.Flights.AddAsync(flightModel);
            await _context.SaveChangesAsync();

            return flightModel;
        }

        public async Task<List<Flight>> GetAllFlights()
        {
            return await _context.Flights.ToListAsync();
        }

        public async Task<List<PassengerInfoResponseDTO>> GetPassengerListWithTicketsAsync(string flightNumber, DateTime date, int page, int pageSize)
        {
            const int PageSize = 10;

            var flight = await _context.Flights
                .FirstOrDefaultAsync(f => f.FlightNumber == flightNumber);

            if (flight == null)
            {
                return new List<PassengerInfoResponseDTO>();
            }

            var tickets = await _context.Tickets
                .Include(t => t.Passenger)
                .Where(t => t.Flight.Id == flight.Id) // önemli! ID üzerinden ilişki
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .Select(t => new PassengerInfoResponseDTO
                {
                    PassengerName = t.Passenger.FullName,
                    SeatNumber = t.SeatNumber
                })
                .ToListAsync();

            return tickets;
        }
    }
}