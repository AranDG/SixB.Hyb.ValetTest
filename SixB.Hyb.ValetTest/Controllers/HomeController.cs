using Microsoft.AspNetCore.Mvc;
using SixB.Hyb.ValetTest.Core.Enums;
using SixB.Hyb.ValetTest.Core.Interfaces.Services;
using SixB.Hyb.ValetTest.Core.Models;
using SixB.Hyb.ValetTest.Core.Models.ViewModels;

namespace SixB.Hyb.ValetTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookingService _bookingService;

        public HomeController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new CreateBookingViewModel
            {
                FlexibilityDayOptions = await _bookingService.GetFlexibilityOptions(),
                VehicleSizes = await _bookingService.GetVehicleSizeOptions()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookingViewModel booking)
        {
            if (!ModelState.IsValid)
            {
                var model = new CreateBookingViewModel
                {
                    Booking = booking,
                    FlexibilityDayOptions = await _bookingService.GetFlexibilityOptions(),
                    VehicleSizes = await _bookingService.GetVehicleSizeOptions()
                };

                return View(model);
            }

            await _bookingService.Create(booking);

            var alert = new Alert
            {
                Type = AlertType.Success,
                Message = "Booking created"
            };
            TempData.Put("Alert", alert);

            return RedirectToAction("Index");
        }
    }
}