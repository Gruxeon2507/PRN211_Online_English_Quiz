using System;
using System.Collections.Generic;

namespace Online_English_Quiz_Project.Models
{
    public partial class UserQuiz
    {
        public int UserQuizId { get; set; }
        public string? Username { get; set; }
        public int? QuizId { get; set; }
        public double? Score { get; set; }
        public DateTime DateTaken { get; set; }

        public virtual Quiz? Quiz { get; set; }
        public virtual User? UsernameNavigation { get; set; }
    }
}
