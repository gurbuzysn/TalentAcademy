using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using TalentAcademy.MVC.Models;
using Microsoft.AspNetCore.Identity;

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




                    //User.Claims.ToString();
                    //User.Identity.ToString();

                    //var fullName = User.Claims.FirstOrDefault(x => x.Type == "FullName")!.Value;





                    //var userRole = claims[0].ToString();
                    //var header = "Role: ";
                    //int index = userRole.IndexOf(header);

                   

                    //string aimWord = userRole.Substring(index + header.Length);
                    //Console.WriteLine(aimWord);


                    var role = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)!.Value;
                    await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                    return RedirectToAction("Index", "Home", new { Area = role });





                    //return RedirectToAction("Index", "Home", new { Area = User.Claims.FirstOrDefault(x => x.Type == "Role")!.Value.ToString() });
                    //return RedirectToAction("Index", "Home", new { Area = User.Claims});


                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                }
            }
            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            //var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;

            //var client = _httpClientFactory.CreateClient();

            //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            //var response = await client.GetAsync("https://localhost/api/Auth/Logout");


            HttpContext.SignOutAsync();

            return RedirectToAction("Login");
        }






    }
}
