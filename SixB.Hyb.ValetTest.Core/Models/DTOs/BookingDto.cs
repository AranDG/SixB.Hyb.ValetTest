namespace SixB.Hyb.ValetTest.Core.Models.DTOs
{
    public class BookingDto
    {
        public int Id { get; set; }
        public bool IsApproved { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime BookingDate { get; set; }
        public int FlexibilityDayId { get; set; }
        public int VehicleSizeId { get; set; }
        public FlexibilityDay FlexibilityDay { get; set; }
        public VehicleSize VehicleSize { get; set; }
    }
}
