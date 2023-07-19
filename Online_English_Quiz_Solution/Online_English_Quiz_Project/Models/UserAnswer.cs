using System;
using System.Collections.Generic;

namespace Online_English_Quiz_Project.Models
{
    public partial class UserAnswer
    {
        public int QuizId { get; set; }
        public int QuestionId { get; set; }
        public int? AnswerId { get; set; }
        public string Username { get; set; } = null!;

        public virtual Answer? Answer { get; set; }
        public virtual Question Question { get; set; } = null!;
        public virtual Quiz Quiz { get; set; } = null!;
        public virtual User UsernameNavigation { get; set; } = null!;
    }
}
