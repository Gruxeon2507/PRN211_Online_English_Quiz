using Microsoft.AspNetCore.Mvc;

namespace Online_English_Quiz_Project.Controllers
{
    public class QuizController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
