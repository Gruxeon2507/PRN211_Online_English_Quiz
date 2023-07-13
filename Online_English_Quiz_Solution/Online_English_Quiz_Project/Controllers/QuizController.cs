using Microsoft.AspNetCore.Mvc;
using Online_English_Quiz_Project.Models;

namespace Online_English_Quiz_Project.Controllers
{
    public class QuizController : Controller
    {
        static int id;
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
            int id = quizId;
            return View();
            //return RedirectToAction("Login", "Authentication");
        }
        static string score;
        [HttpPost]
        public IActionResult Submit(List<string> answers, int quizId,string username)
        {

            int correctAnswer = 0;
            int totalQuestion = 10;
            int temp = 0; 

            using (PRN211_Online_English_QuizContext context = new PRN211_Online_English_QuizContext())
            {
                for(int i = 0; i <= 9; i++)
                {
                    int index = Convert.ToInt32(answers[i]);
                    Console.WriteLine(index);
                    var correct = context.Answers.Where(a =>a.AnswerId == index).ToList();
                    foreach(var answer in correct)
                    {
                        Console.WriteLine(answer.AnswerId);
                        if (answer.IsCorrectAnswer)
                        {
                            correctAnswer++;
                        }
                    }
                }
                Console.WriteLine(correctAnswer);
                double finalScore = (double)correctAnswer / totalQuestion * 10;
                score = finalScore+"";
                UserQuiz quiz = new UserQuiz();
                quiz.DateTaken = DateTime.Now;
                quiz.Username =username;
                quiz.Score = finalScore;
                quiz.QuizId = quizId;
                context.UserQuizzes.Add(quiz);
                context.SaveChanges();
                Console.WriteLine(correctAnswer / totalQuestion);
                Console.WriteLine("chay vao day");
            }
            
            return RedirectToAction("Submit","Quiz");
        }
        [HttpGet]
        public IActionResult Submit()
        {
            ViewBag.TotalScore = score;
            return View();
        }
    }
}
