using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.DTOs;
using src.DTOs.FlightDTO;
using src.Interfaces;
using src.Mappers;
using src.Models;

namespace src.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/flights")]
    [ApiVersion("1.0")]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;
        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddFlight([FromBody] AddFlightRequestDTO request)
        {
            try
            {
                var flightModel = request.ToFlightFromAddFlightRequestDTO();
                await _flightService.AddFlightService(flightModel);
        
                return Ok(new ResponseDTO<FlightDTO>("success", "Flight created successfully", flightModel.ToFlightDTO()));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDTO<object>("failed", $"Failed to create flight: {ex}", null));
            }
        }

        [HttpGet]
        public async Task<IActionResult> SearchFlights([FromQuery] QueryFlightRequestDTO request)
        {
            var flights = await _flightService.SearchFlightsAsync(request);
            return Ok(flights);
        }

        [HttpGet("{flightNumber}/passengers")]
        [Authorize]
        public async Task<IActionResult> GetPassengerList(
            string flightNumber,
            [FromQuery] DateTime date,
            [FromQuery] int page = 1)
        {
            var passengers = await _flightService.GetPassengerListAsync(flightNumber, date, page);
            return Ok(passengers);
        }

    }
}