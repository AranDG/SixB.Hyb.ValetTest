namespace SixB.Hyb.ValetTest.Core.Models.ViewModels
{
    public class CreateBookingViewModel
    {
        public BookingViewModel Booking { get; set; } = new BookingViewModel();

        public IList<VehicleSize> VehicleSizes { get; set; } = new List<VehicleSize>();

        public IList<FlexibilityDay> FlexibilityDayOptions { get; set; } = new List<FlexibilityDay>();
    }
}
