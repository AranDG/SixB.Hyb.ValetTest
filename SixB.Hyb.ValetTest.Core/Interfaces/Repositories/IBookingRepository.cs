using SixB.Hyb.ValetTest.Core.Models.DTOs;
using SixB.Hyb.ValetTest.Core.Models;

namespace SixB.Hyb.ValetTest.Core.Interfaces.Repositories
{
    public interface IBookingRepository
    {
        Task<IList<BookingDto>> Get();
        Task<BookingDto> Get(int id);
        Task Create(BookingDto booking);
        Task Edit(BookingDto booking);
        Task Delete(int id);
        Task Approve(int id);
        Task<IList<FlexibilityDay>> GetFlexibilityDays();
        Task<IList<VehicleSize>> GetVehicleSizes();
    }
}
