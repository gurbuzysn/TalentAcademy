using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
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

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();

                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

                var response = await client.PostAsync("http://localhost:5020/api/Auth/Login", content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var tokenModel = JsonSerializer.Deserialize<JwtTokenResponseModel>(jsonData);
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı")
                }

            }
            return View(model);
        }


    }
}
