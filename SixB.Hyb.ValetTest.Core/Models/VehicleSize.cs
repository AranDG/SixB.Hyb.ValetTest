using System.ComponentModel.DataAnnotations;

namespace SixB.Hyb.ValetTest.Core.Models
{
    public class VehicleSize
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "A vehicle size must have a unique name")]
        [StringLength(20, ErrorMessage = "A vehicle size can not have a name greater than 20 characters in length")]
        public string Name { get; set; }
    }
}
