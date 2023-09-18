using Microsoft.AspNetCore.Identity;
using SixB.Hyb.ValetTest.Core.Models.DTOs;
using SixB.Hyb.ValetTest.Core.Models;

namespace SixB.Hyb.ValetTest.Repository
{
    internal class InitialSeedData
    {
        public static readonly List<VehicleSize> VehicleTypes = new List<VehicleSize>
        {
            new () { Id = 1, Name = "Small" },
            new () { Id = 2, Name = "Medium" },
            new () { Id = 3, Name = "Large" },
            new () { Id = 4, Name = "Van" },
        };

        public static readonly List<FlexibilityDay> FlexibilityDays = new List<FlexibilityDay>
        {
            new () { Id = 1, Days = 1, Name = "+/- 1 Day" },
            new () { Id = 2, Days = 2, Name = "+/- 2 Days" },
            new () { Id = 3, Days = 3, Name = "+/- 3 Days" },
        };

        public static readonly List<BookingDto> Bookings = new List<BookingDto>
        {
            new ()
            {
                BookingDate = DateTime.Now,
                ContactNumber = "+44 (0) 1472 750 221",
                FlexibilityDayId = 1,
                EmailAddress = "ivanajob@yourcompany.co.uk",
                Id = 1,
                IsApproved = true,
                Name = "Ivana",
                VehicleSizeId = 2
            },
            new ()
            {
                BookingDate = DateTime.Now.AddDays(-4),
                ContactNumber = "787454215",
                FlexibilityDayId = 3,
                EmailAddress = "bram.stoker@nhs-blood-donations.com",
                Id = 2,
                IsApproved = false,
                Name = "Bram",
                VehicleSizeId = 4
            }
        };

        const string email = "admin@djvalet.com";

        public static readonly List<ApplicationUser> Users = new List<ApplicationUser>
        {
            new ()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = email,
                NormalizedUserName = email.ToUpperInvariant(),
                Email = email,
                NormalizedEmail = email.ToUpperInvariant(),
                LockoutEnabled = false,
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Password1")
            }
        };
    }
}
