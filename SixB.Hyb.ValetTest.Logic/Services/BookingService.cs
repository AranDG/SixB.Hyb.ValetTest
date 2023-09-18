using SixB.Hyb.ValetTest.Core.Interfaces.Repositories;
using SixB.Hyb.ValetTest.Core.Interfaces.Services;
using SixB.Hyb.ValetTest.Core.Mappers;
using SixB.Hyb.ValetTest.Core.Models;
using SixB.Hyb.ValetTest.Core.Models.ViewModels;

namespace SixB.Hyb.ValetTest.Logic.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _dataStore;

        public BookingService(IBookingRepository dataStore)
        {
            _dataStore = dataStore;
        }

        public async Task<IList<BookingViewModel>> Get()
        {
            var bookings = await _dataStore.Get();

            return MappingUtilities.ConvertToViewModelList(bookings);
        }

        public async Task<BookingViewModel?> Get(int id)
        {
            var booking = await _dataStore.Get(id);

            return MappingUtilities.ConvertToViewModel(booking);
        }

        public async Task Create(BookingViewModel booking)
        {
            var bookingDto = MappingUtilities.ConvertToDto(booking);

            await _dataStore.Create(bookingDto);
        }

        public async Task Delete(int id)
        {
            await _dataStore.Delete(id);
        }

        public async Task Approve(int id)
        {
            await _dataStore.Approve(id);
        }

        public async Task Edit(BookingViewModel booking)
        {
            var bookingDto = MappingUtilities.ConvertToDto(booking);

            await _dataStore.Edit(bookingDto);
        }

        public async Task<IList<FlexibilityDay>> GetFlexibilityOptions()
        {
            return await _dataStore.GetFlexibilityDays();
        }

        public async Task<IList<VehicleSize>> GetVehicleSizeOptions()
        {
            return await _dataStore.GetVehicleSizes();
        }
    }
}
