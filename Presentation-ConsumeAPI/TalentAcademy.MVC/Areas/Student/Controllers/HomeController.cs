using Microsoft.AspNetCore.Mvc;

namespace TalentAcademy.MVC.Areas.Student.Controllers
{
    [Area("Student")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
