using System.ComponentModel.DataAnnotations;

namespace SixB.Hyb.ValetTest.Core.Models
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
