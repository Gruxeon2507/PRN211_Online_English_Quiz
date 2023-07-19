using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            string username=HttpContext.Session.GetString("username");
            ViewBag.id = quizId;
            using(PRN211_Online_English_QuizContext context = new PRN211_Online_English_QuizContext())
            {
                var result = context.UserQuizzes.Where(uq => uq.QuizId == quizId && uq.Username == HttpContext.Session.GetString("username")).ToList();
                var quiz = context.Quizzes.FirstOrDefault(q => q.QuizId==quizId);
                var answer = context.UserAnswers.Where(ua => ua.QuizId == quizId && ua.Username == username).Include(ua => ua.Quiz).Include(ua => ua.Question).Include(ua => ua.Answer).ToList();
                var question = context.Questions.Include(q => q.Answers).ToList();
                var quizQuestion = context.QuizQuestions.Where(q => q.QuizId == quizId).Include(q => q.Question).Include(q => q.Quiz).ToList();
                var answer2 = context.Answers.ToList();
                ViewBag.result = result;
                ViewBag.quiz = quiz;
                ViewBag.answer = answer;
                ViewBag.question = question;
                ViewBag.answer2 = answer2;
                ViewBag.quizQuestion =quizQuestion;
                
                
            }
            
            return View();
        }
    }
}
