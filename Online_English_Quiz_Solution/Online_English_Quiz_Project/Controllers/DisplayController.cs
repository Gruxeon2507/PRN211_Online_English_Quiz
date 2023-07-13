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

        public IActionResult Result(int quizId)
        {
            ViewBag.id = quizId;
            using(PRN211_Online_English_QuizContext context = new PRN211_Online_English_QuizContext())
            {
                var result = context.UserQuizzes.Where(uq => uq.QuizId == quizId && uq.Username == HttpContext.Session.GetString("username")).ToList();
                var quiz = context.Quizzes.FirstOrDefault(q => q.QuizId==quizId);
                ViewBag.result = result;
                ViewBag.quiz = quiz;
            }
            
            return View();
        }
    }
}
