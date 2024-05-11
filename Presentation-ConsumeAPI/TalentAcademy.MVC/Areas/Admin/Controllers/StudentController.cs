﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Text;
using System.Text.Json;
using TalentAcademy.MVC.Areas.Admin.Models.Student;

namespace TalentAcademy.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class StudentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StudentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> List()
        {
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


        [HttpGet]
        public IActionResult Create()
        {
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


                var jsonData = JsonSerializer.Serialize(model);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://localhost:7043/api/Students", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("List");
                }

                ModelState.AddModelError("", "Bir hata oluştu");
            }
            return RedirectToAction("List");
        }

        
        public async Task<IActionResult> Delete(Guid id)
        {
            if(!ModelState.IsValid)
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
