namespace SixB.Hyb.ValetTest.Core.Models.ViewModels
{
    public class BookingIndexViewModel
    {
        public IList<BookingViewModel> Bookings { get; set; } = new List<BookingViewModel>();
    }
}
