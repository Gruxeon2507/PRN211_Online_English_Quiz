using Microsoft.AspNetCore.Mvc;
using Online_English_Quiz_Project.Models;

namespace Online_English_Quiz_Project.Controllers
{
    public class StatisticController : Controller
    {
        public IActionResult Statistic(int quizId)
        {
            using(PRN211_Online_English_QuizContext context = new PRN211_Online_English_QuizContext())
            {
                List<int> score = new List<int>(5);
                score.AddRange(Enumerable.Repeat(0, 5));
                var result = context.UserQuizzes.ToList();
                var quiz = context.Quizzes.ToList();
                if (quizId != 0)
                {
                    result = context.UserQuizzes.Where(q => q.QuizId==quizId).ToList();
                }
                foreach(var item in result)
                {
                    item.Quiz= context.Quizzes.FirstOrDefault(q => q.QuizId==item.QuizId);
                    if (item.Score <= 2)
                    {
                        score[0]++;
                    }else if(item.Score <= 4) {
                        score[1]++;
                    }
                    else if (item.Score <= 6) {
                        score[2]++;
                    }
                    else if(item.Score<= 8) {
                        score[3]++;
                    }
                    else
                    {
                        score[4]++;
                    }
                }
                ViewBag.data = result;
                ViewBag.score = score;
                ViewBag.quiz = quiz;
                
            }
           
            return View();
        }
    }
}
