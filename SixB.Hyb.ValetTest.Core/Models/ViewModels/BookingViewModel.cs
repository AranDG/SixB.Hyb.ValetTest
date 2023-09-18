using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SixB.Hyb.ValetTest.Core.Models.ViewModels
{
    public class BookingViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Approved")]
        public bool IsApproved { get; set; }

        [Required(ErrorMessage = "A name is required")]
        public string Name { get; set; } = null!;

        [Display(Name = "Contact Number")]
        [Required(ErrorMessage = "A contact number is required")]
        public string ContactNumber { get; set; } = null!;

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "A valid email address is required")]
        [EmailAddress]
        public string EmailAddress { get; set; } = null!;

        [Display(Name = "Booking Date")]
        [Required(ErrorMessage = "A valid booking date is required")]
        public DateTime BookingDate { get; set; }

        [Required(ErrorMessage = "A flexibility option is required")]
        public int FlexibilityDayId { get; set; }

        [Display(Name = "Vehicle Size")]
        [Required(ErrorMessage = "A vehicle size is required")]
        public int VehicleSizeId { get; set; }

        [JsonPropertyName("FlexibilityDay.Name")]
        public string? FlexibilityDayDisplay { get; set; }

        [JsonPropertyName("VehicleSize.Name")]
        public string? VehicleSizeDisplay { get; set; }
    }
}
