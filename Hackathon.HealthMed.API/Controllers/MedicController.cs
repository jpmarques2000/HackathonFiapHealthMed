using Microsoft.AspNetCore.Mvc;

namespace Hackathon.HealthMed.API.Controllers
{
    public class MedicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
