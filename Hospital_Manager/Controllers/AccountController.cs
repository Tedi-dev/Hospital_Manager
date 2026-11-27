using Data_Hospital_Manager.Entities;
using Hospital_Manager.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Manager.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> sim;
        private readonly UserManager<User> um;
        public AccountController(SignInManager<User> sim, UserManager<User> um)
        {
            this.sim = sim;
            this.um = um;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            if (!ModelState.IsValid)
            {
                                return View(lvm);
            }
            var result = await sim.PasswordSignInAsync(lvm.UserName, lvm.Password, lvm.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Hospital");
            }
            ModelState.AddModelError(string.Empty, "Wrong username or password.");
            return View(lvm);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await sim.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
