using Data_Hospital_Manager.Entities;
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
