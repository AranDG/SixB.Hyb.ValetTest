using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SixB.Hyb.ValetTest.Core.Enums;
using SixB.Hyb.ValetTest.Core.Models;

namespace SixB.Hyb.ValetTest.Controllers
{

    public class AuthController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                var alert = new Alert
                {
                    Type = AlertType.Error,
                    Message = "Invalid credentials"
                };
                TempData.Put("Alert", alert);

                return View(model);
            }

            return RedirectToAction("Index", "Admin");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
