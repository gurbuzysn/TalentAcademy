﻿using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;
using System.Text.Json;
using TalentAcademy.MVC.Areas.Admin.Models.Student;
using TalentAcademy.MVC.Enums;
using TalentAcademy.MVC.Models;

namespace TalentAcademy.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class StudentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly INotyfService _notyf;

        public StudentController(IHttpClientFactory httpClientFactory, INotyfService notyf)
        {
            _httpClientFactory = httpClientFactory;
            _notyf = notyf;
        }


        public async Task<IActionResult> List()
        {
            ViewBag.GenderList = Enum.GetValues(typeof(Gender)).Cast<Gender>().Select(e => new SelectListItem
            {
                Value = e.ToString(),
                Text = e.ToString()
            }).ToList();


            var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.ToString();
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var response = await client.GetAsync("https://localhost:7043/api/Students");

                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<List<StudentListModel>>(jsonData, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                    return View(result);
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentCreateModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.ToString();

            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                using (var content = new MultipartFormDataContent())
                {
                    content.Add(new StringContent(model.FirstName), "FirstName");
                    content.Add(new StringContent(model.LastName), "LastName");
                    content.Add(new StringContent(model.Gender.ToString()), "Gender");
                    content.Add(new StringContent(model.DateOfBirth.ToString("o")), "DateOfBirth");

                    if (model.Image != null)
                    {
                        var fileContent = new StreamContent(model.Image.OpenReadStream());
                        fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(model.Image.ContentType);
                        content.Add(fileContent, "Image", model.Image.FileName);
                    }

                    try
                    {
                        var response = await client.PostAsync("https://localhost:7043/api/Students", content);

                        var jsonData = await response.Content.ReadAsStringAsync();
                        var result = JsonSerializer.Deserialize<GeneralResponseModel>(jsonData, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase});

                        if (response.IsSuccessStatusCode)
                        {
                            TempData["Message"] = result.Message;
                            return RedirectToAction("List");
                        }
                        ModelState.AddModelError("", "Bir hata oluştu");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", $"Bir hata oluştu: {ex.Message}");
                    }
                }
            }

            return View(model);
        }






        public async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.ToString();
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var jsonData = JsonSerializer.Serialize(id);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.DeleteAsync($"https://localhost:7043/api/Students/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            ModelState.AddModelError("", "Bir hata oluştu");
            return RedirectToAction("List");
        }

    }
}
