using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Interfaces;
using src.Models;

namespace src.Repositories
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly ApplicationDBContext _context;
        public PassengerRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Passenger>> GetAllPassengers()
        {
             return await _context.Passengers.ToListAsync();
        }
    }
}