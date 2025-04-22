using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.DTOs.FlightDTO;
using src.Interfaces;

namespace src.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/tickets")]
    [ApiVersion("1.0")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost("buy")]
        [Authorize]
        public async Task<IActionResult> BuyTicket([FromBody] BuyTicketRequestDTO request)
        {
            var result = await _ticketService.BuyTicketAsync(request);

            if (result.Status == "FlightNotFound")
                return NotFound("Flight not found");

            if (result.Status == "SoldOut")
                return BadRequest("Flight is sold out");

            return Ok(result);
        }

        [HttpPost("checkin")]
        public async Task<IActionResult> CheckIn([FromBody] CheckInRequestDTO request)
        {
            var result = await _ticketService.CheckInAsync(request);

            return result.Status switch
            {
                "Success" => Ok(result),
                "AlreadyCheckedIn" => Ok(result),
                "PassengerNotFound" => NotFound("Passenger not found on this flight"),
                "FlightNotFound" => NotFound("Flight not found"),
                _ => BadRequest("Unknown error")
            };
        }
    }
}