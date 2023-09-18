using SixB.Hyb.ValetTest.Core.Models.ViewModels;
using SixB.Hyb.ValetTest.Core.Models;

namespace SixB.Hyb.ValetTest.Core.Interfaces.Services
{
    public interface IBookingService
    {
        Task<IList<BookingViewModel>> Get();
        Task<BookingViewModel?> Get(int id);
        Task Create(BookingViewModel booking);
        Task Delete(int id);
        Task Approve(int id);
        Task Edit(BookingViewModel booking);
        Task<IList<FlexibilityDay>> GetFlexibilityOptions();
        Task<IList<VehicleSize>> GetVehicleSizeOptions();
    }
}
