using Assignment.API.Common.Repository;
using Assignment.API.Data.Interface;
using Assignment.API.Models;
using Assignment.API.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.API.Data.Implementation
{
    public class BookingService : RepositoryBase<Booking>, IBookingService
    {
        public BookingService(AssignmentDBContext context) : base(context)
        { }

        public async Task<string> AddBookingAsync(Booking model)
        {
            Create(model);
            await SaveAsync();
            return model.Id.ToString();
        }

        public async Task<IEnumerable<Booking>> GetAllBookingAsync()
        {
            var bookings = await FindAllAsync();
            return bookings.OrderBy(x => x.CreatedDate);
        }

        public async Task<IEnumerable<Booking>> GetAllBookingByIdAsync(Guid userId, DateTime bookingDate)
        {
            var allBookings = await FindByConditionAync(o => o.UserId.Equals(userId) && o.CreatedDate.Equals(bookingDate));
            return allBookings;
        }

        public async Task<IEnumerable<Booking>> GetAllBookingByMultiplexIdAsync(Guid multiplexId, DateTime bookingDate)
        {
            var bookingsList = await FindByConditionAync(o => o.MultiplexId.Equals(multiplexId) && o.CreatedDate.Equals(bookingDate));
            return bookingsList;
        }
    }
}
