using SixB.Hyb.ValetTest.Core.Interfaces.Repositories;
using SixB.Hyb.ValetTest.Core.Models.DTOs;
using SixB.Hyb.ValetTest.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace SixB.Hyb.ValetTest.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Approve(int id)
        {
            var booking = await _context.Bookings.SingleOrDefaultAsync(x => x.Id == id);

            if (booking == null)
            {
                throw new Exception($"Booking with id #{id} not found");
            }

            booking.IsApproved = true;

            _context.Update(booking);
            await _context.SaveChangesAsync();
        }

        public async Task Create(BookingDto booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var booking = await _context.Bookings.SingleOrDefaultAsync(x => x.Id == id);

            if (booking == null)
            {
                throw new Exception($"Booking with id #{id} not found");
            }

            _context.Remove(booking);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(BookingDto booking)
        {
            var existingBooking = await _context.Bookings.SingleOrDefaultAsync(x => x.Id == booking.Id);

            if (existingBooking == null)
            {
                throw new Exception($"Booking with id #{booking.Id} not found");
            }

            existingBooking.BookingDate = booking.BookingDate;
            existingBooking.ContactNumber = booking.ContactNumber;
            existingBooking.EmailAddress = booking.EmailAddress;
            existingBooking.FlexibilityDayId = booking.FlexibilityDayId;
            existingBooking.IsApproved = booking.IsApproved;
            existingBooking.Name = booking.Name;
            existingBooking.VehicleSizeId = booking.VehicleSizeId;

            _context.Update(existingBooking);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<BookingDto>> Get()
        {
            return await _context.Bookings
                .Include(b => b.FlexibilityDay)
                .Include(b => b.VehicleSize)
                .ToListAsync();
        }

        public async Task<BookingDto> Get(int id)
        {
            var booking = await _context.Bookings.SingleOrDefaultAsync(x => x.Id == id);

            if (booking == null)
            {
                throw new Exception($"Booking with id #{id} not found");
            }

            return booking;
        }

        public async Task<IList<FlexibilityDay>> GetFlexibilityDays()
        {
            return await _context.FlexibilityDays.ToListAsync();
        }

        public async Task<IList<VehicleSize>> GetVehicleSizes()
        {
            return await _context.VehicleSizes.ToListAsync();
        }
    }
}
