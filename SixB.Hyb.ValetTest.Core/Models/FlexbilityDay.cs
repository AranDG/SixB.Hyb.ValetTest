using System.ComponentModel.DataAnnotations;

namespace SixB.Hyb.ValetTest.Core.Models
{
    public class FlexibilityDay
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required(ErrorMessage = "A number of days is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Number of days must be greater than 0")]
        public int Days { get; set; }
    }
}
