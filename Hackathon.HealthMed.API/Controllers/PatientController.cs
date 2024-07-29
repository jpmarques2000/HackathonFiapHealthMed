using Microsoft.AspNetCore.Mvc;

namespace Hackathon.HealthMed.API.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
