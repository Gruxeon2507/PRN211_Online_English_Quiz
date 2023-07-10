using Microsoft.AspNetCore.Mvc;
using Online_English_Quiz_Project.Models;

namespace Online_English_Quiz_Project.Controllers
{
    public class QuizController : Controller
    {
        public IActionResult Quiz(int quizId)
        {
            using (PRN211_Online_English_QuizContext context = new PRN211_Online_English_QuizContext())
            {
                var quiz = context.Quizzes.FirstOrDefault(q => q.QuizId == quizId);
                if(quiz != null)
                {
                    ViewBag.QuizId = quizId;
                    ViewBag.QuizTitle = quiz.QuizTitle;
                    
                    List<QuizQuestion> questionList = context.QuizQuestions.Where(q => q.QuizId==quizId).ToList();
                    List<Question> questions = context.Questions.Where(q => questionList.Select(q1 => q1.QuestionId).Contains(q.QuestionId)).ToList();
                    ViewBag.Questions = questions;
                    List<Answer> answers = context.Answers.Where(a => questionList.Select(q => q.QuestionId).Contains(a.QuestionId)).ToList();
                    ViewBag.Answers = answers;
                    return View();
                }
            }
            return View();
            //return RedirectToAction("Login", "Authentication");
        }
        [HttpPost]
        public IActionResult Submit(IFormCollection form)
        {
            using(PRN211_Online_English_QuizContext context = new PRN211_Online_English_QuizContext())
            {
                int correctAnswer = 0;
                int totalQuestion = 0;
                int temp = 0;
                foreach (var key in form.Keys)
                {
                    if (key.StartsWith("answer"))
                    {
                        int answer = Int32.Parse(form[key]);
                        var correct = context.Answers.Where(a => a.AnswerId == answer && a.IsCorrectAnswer == true);
                        if (correct != null)
                        {
                            correctAnswer++;
                        }
                        totalQuestion++;
                    }
                }
                ViewBag.TotalScore = correctAnswer / totalQuestion;
                //Console.WriteLine(correctAnswer / totalQuestion);
                Console.WriteLine("chay vao day");
            }
            return RedirectToAction("Submit","Quiz");
        }
        [HttpGet]
        public IActionResult Submit()
        {
            return View();
        }
    }
}
