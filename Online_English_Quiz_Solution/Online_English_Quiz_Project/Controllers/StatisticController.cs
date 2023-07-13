using Microsoft.AspNetCore.Mvc;
using Online_English_Quiz_Project.Models;

namespace Online_English_Quiz_Project.Controllers
{
    public class StatisticController : Controller
    {
        public IActionResult Statistic()
        {
            using(PRN211_Online_English_QuizContext context = new PRN211_Online_English_QuizContext())
            {
                var result = context.UserQuizzes.ToList();
                ViewBag.data = result;
            }
           
            return View();
        }
    }
}
