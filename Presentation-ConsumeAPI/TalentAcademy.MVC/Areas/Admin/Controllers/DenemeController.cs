using Microsoft.AspNetCore.Mvc;

namespace TalentAcademy.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DenemeController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
