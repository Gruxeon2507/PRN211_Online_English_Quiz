using System;
using System.Collections.Generic;

namespace Online_English_Quiz_Project.Models
{
    public partial class Quiz
    {
        public Quiz()
        {
            UserQuizzes = new HashSet<UserQuiz>();
        }

        public int QuizId { get; set; }
        public string? QuizTitle { get; set; }
        public string? QuizDescription { get; set; }
        public string? CreatedBy { get; set; }

        public virtual User? CreatedByNavigation { get; set; }
        public virtual ICollection<UserQuiz> UserQuizzes { get; set; }
    }
}
