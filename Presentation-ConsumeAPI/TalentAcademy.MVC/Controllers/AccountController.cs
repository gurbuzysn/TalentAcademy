using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using TalentAcademy.MVC.Models;

namespace TalentAcademy.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly INotyfService _notyf;

        public AccountController(IHttpClientFactory httpClientFactory, INotyfService notyf)
        {
            _httpClientFactory = httpClientFactory;
            _notyf = notyf;
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
                var response = await client.PostAsync("https://localhost:7043/api/Auth/Login", content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var tokenModel = JsonSerializer.Deserialize<JwtTokenResponseModel>(jsonData, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });


                    var token = new JwtSecurityTokenHandler().ReadJwtToken(tokenModel.Token);



                    var claims = token.Claims.ToList();
                    claims.Add(new Claim("accessToken", tokenModel.Token));
                    var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);

                    var authProps = new AuthenticationProperties
                    {
                        ExpiresUtc = tokenModel.ExpireDate,
                        IsPersistent = true,
                    };

                    var userRole = claims[0].ToString();
                    var header = "Role: ";
                    int index = userRole.IndexOf(header);

                    string aimWord = userRole.Substring(index + header.Length);
                    Console.WriteLine(aimWord);

                    await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                    return RedirectToAction("Index", "Home", new { Area = aimWord });
                }
                else
                {
                    TempData["AlertMessage"] = "Kullanıcı adı veya parola hatalı";
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
