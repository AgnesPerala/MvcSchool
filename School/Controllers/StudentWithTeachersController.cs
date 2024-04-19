using Microsoft.AspNetCore.Mvc;

namespace School.Controllers
{
    public class StudentWithTeachersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
