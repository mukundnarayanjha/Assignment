using Assignment.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.API.Data.Interface
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetAllBookingAsync();
        Task<IEnumerable<Booking>> GetAllBookingByIdAsync(Guid userId, DateTime bookingDate);
        Task<IEnumerable<Booking>> GetAllBookingByMultiplexIdAsync(Guid multiplexId, DateTime bookingDate);        
        Task<string> AddBookingAsync(Booking model);
    }
}
