using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Data;
using src.DTOs.FlightDTO;
using src.Interfaces;
using src.Models;

namespace src.Services
{
    public class TicketService : ITicketService
    {
        private readonly ApplicationDBContext _context;
        private readonly IFlightRepository _flightRepository;

        public TicketService(ApplicationDBContext context, IFlightRepository flightRepository)
        {
            _context = context;
            _flightRepository = flightRepository;
        }

        public async Task<BuyTicketResponseDTO> BuyTicketAsync(BuyTicketRequestDTO request)
        {
            var flights = await _flightRepository.GetAllFlights();
            var flight = flights
                .FirstOrDefault(f =>
                    f.FlightNumber == request.FlightNumber &&
                    f.DateFrom.Date == request.Date.Date);


            if (flight == null)
            {
                return new BuyTicketResponseDTO { TicketNumber = "", Status = "FlightNotFound" };
            }

            int availableSeats = flight.Capacity - flight.Passengers.Count;
            int passengersToAdd = request.PassengerNames.Count;

            if (availableSeats < passengersToAdd)
            {
                return new BuyTicketResponseDTO { Status = "SoldOut" };
            }

            foreach (var name in request.PassengerNames)
            {
                var passenger = new Passenger { FullName = name };
                _context.Passengers.Add(passenger);

                var ticket = new Ticket
                {
                    Flight = flight,
                    Passenger = passenger,
                    IsCheckedIn = false,
                    SeatNumber = null
                };

                _context.Tickets.Add(ticket);
            }

            await _context.SaveChangesAsync();

            string ticketNumber = $"TKT-{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}";

            return new BuyTicketResponseDTO
            {
                TicketNumber = ticketNumber,
                Status = "Success"
            };
        }

        public async Task<CheckInResponseDTO> CheckInAsync(CheckInRequestDTO request)
        {
            var flight = await _context.Flights
                .Include(f => f.Tickets)
                    .ThenInclude(t => t.Passenger)
                .FirstOrDefaultAsync(f =>
                    f.FlightNumber == request.FlightNumber &&
                    f.DateFrom.Date == request.Date.Date);

            if (flight == null)
            {
                return new CheckInResponseDTO { Status = "FlightNotFound" };
            }

            var ticket = flight.Tickets
                .FirstOrDefault(t => t.Passenger.FullName == request.PassengerName);

            if (ticket == null)
            {
                return new CheckInResponseDTO { Status = "PassengerNotFound" };
            }

            if (ticket.IsCheckedIn)
            {
                return new CheckInResponseDTO
                {
                    Status = "AlreadyCheckedIn",
                    SeatNumber = ticket.SeatNumber
                };
            }

            var takenSeats = flight.Tickets
                .Where(t => t.IsCheckedIn && t.SeatNumber.HasValue)
                .Select(t => t.SeatNumber.Value)
                .ToList();

            int seatNumber = 1;
            while (takenSeats.Contains(seatNumber))
            {
                seatNumber++;
            }

            ticket.SeatNumber = seatNumber;
            ticket.IsCheckedIn = true;

            await _context.SaveChangesAsync();

            return new CheckInResponseDTO
            {
                Status = "Success",
                SeatNumber = seatNumber
            };
        }
        
    }

}