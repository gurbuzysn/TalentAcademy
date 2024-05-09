using Microsoft.AspNetCore.Mvc;

namespace TalentAcademy.MVC.Areas.Trying.Controllers
{
    [Area("Trying")]
    public class TryingController : Controller
    {
        public IActionResult Gubidik()
        {
            return View();
        }
    }
}
