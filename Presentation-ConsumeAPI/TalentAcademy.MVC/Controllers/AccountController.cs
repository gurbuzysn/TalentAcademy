using Microsoft.AspNetCore.Mvc;
using TalentAcademy.MVC.Models;

namespace TalentAcademy.MVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginModel userLoginModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return View();
        }


    }
}
