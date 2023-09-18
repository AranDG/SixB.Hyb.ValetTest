using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SixB.Hyb.ValetTest.Core.Interfaces.Services;
using SixB.Hyb.ValetTest.Core.Models.ViewModels;
using SixB.Hyb.ValetTest.Core.Models;
using SixB.Hyb.ValetTest.Core.Enums;

namespace SixB.Hyb.ValetTest.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IBookingService _bookingService;

        public AdminController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new BookingIndexViewModel
            {
                Bookings = await _bookingService.Get()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookingService.Delete(id);

            var alert = new Alert
            {
                Type = AlertType.Success,
                Message = "Booking deleted"
            };
            TempData.Put("Alert", alert);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Approve(int id)
        {
            await _bookingService.Approve(id);

            var alert = new Alert
            {
                Type = AlertType.Success,
                Message = "Booking approved"
            };
            TempData.Put("Alert", alert);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Create()
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

        public async Task<IActionResult> Edit(int id)
        {
            var booking = await _bookingService.Get(id);

            if (booking == null)
            {
                return RedirectToAction("Index");
            }

            var model = new EditBookingViewModel
            {
                Booking = booking,
                FlexibilityDayOptions = await _bookingService.GetFlexibilityOptions(),
                VehicleSizes = await _bookingService.GetVehicleSizeOptions()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BookingViewModel booking)
        {
            if (!ModelState.IsValid)
            {
                var model = new EditBookingViewModel
                {
                    Booking = booking,
                    FlexibilityDayOptions = await _bookingService.GetFlexibilityOptions(),
                    VehicleSizes = await _bookingService.GetVehicleSizeOptions()
                };

                return View(model);
            }

            await _bookingService.Edit(booking);

            var alert = new Alert
            {
                Type = AlertType.Success,
                Message = "Booking updated"
            };
            TempData.Put("Alert", alert);

            return RedirectToAction("Index");
        }
    }
}
