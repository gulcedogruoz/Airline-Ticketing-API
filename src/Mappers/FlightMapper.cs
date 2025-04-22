using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.DTOs.FlightDTO;
using src.Models;

namespace src.Mappers
{
    public static class FlightMapper
    {
        public static Flight ToFlightFromAddFlightRequestDTO(this AddFlightRequestDTO flightRequestDTO)
        {
            return new Flight
            {
                AirportFrom = flightRequestDTO.AirportFrom,
                AirportTo = flightRequestDTO.AirportTo,
                Capacity = flightRequestDTO.Capacity,
                DateFrom = flightRequestDTO.DateFrom,
                DateTo = flightRequestDTO.DateTo,
                Duration = flightRequestDTO.Duration
            };
        }

        public static FlightDTO ToFlightDTO(this Flight flightModel)
        {
            return new FlightDTO
            {
                FlightNumber = flightModel.FlightNumber,
                DateFrom = flightModel.DateFrom,
                DateTo = flightModel.DateTo,
                Duration = flightModel.Duration,
                AirportFrom = flightModel.AirportFrom,
                AirportTo = flightModel.AirportTo,
                Capacity = flightModel.Capacity
            };
        }
    }
}