using Microsoft.AspNetCore.Mvc;
using TalentAcademy.MVC.Models;

namespace TalentAcademy.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Login(UserLoginModel userLoginModel)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest();

        //    var client = _httpClientFactory.CreateClient();
        //    client.PostAsync("http://localhost:5020/api/Auth/Login");




        //    return View();
        //}


    }
}
