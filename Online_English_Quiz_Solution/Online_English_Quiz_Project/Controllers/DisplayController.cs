using Microsoft.AspNetCore.Mvc;
using Online_English_Quiz_Project.Models;

namespace Online_English_Quiz_Project.Controllers
{
    public class DisplayController : Controller
    {
        public IActionResult Home()
        {
            using(PRN211_Online_English_QuizContext context = new PRN211_Online_English_QuizContext())
            {
                ViewBag.quizzes = context.Quizzes.ToList();
                return View();
            }
        }
    }
}
