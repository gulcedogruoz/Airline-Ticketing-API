using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.DTOs.FlightDTO;

namespace src.Interfaces
{
    public interface ITicketService
    {
        Task<BuyTicketResponseDTO> BuyTicketAsync(BuyTicketRequestDTO request);
        Task<CheckInResponseDTO> CheckInAsync(CheckInRequestDTO request);
    }
}