using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using TalentAcademy.MVC.Areas.Admin.Models;
using TalentAcademy.MVC.Areas.Admin.Models.Admin;

namespace TalentAcademy.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly INotyfService _notyf;

        public HomeController(IWebHostEnvironment webHostEnvironment, IHttpClientFactory httpClientFactory, INotyfService notyf)
        {
            _webHostEnvironment = webHostEnvironment;
            _httpClientFactory = httpClientFactory;
            _notyf = notyf;
        }
        public IActionResult Index(AdminDashboardModel model)
        {
            return View(model);
        }

        public async Task<IActionResult> Profile()
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value;
            var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.ToString();

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var content = new StringContent(JsonSerializer.Serialize(userId), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7043/api/User", content);

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<UserInfoModel>(jsonData);
                return View(result);
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Dosya seçilmedi.");

            var pathName = Path.GetExtension(file.FileName);
            var userName = $"{User.Claims.FirstOrDefault(x => x.Type == "FullName")!.Value}";
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "img", $"{userName}{pathName}");

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return Ok("Dosya başarıyla yüklendi");
        }
    }
}
