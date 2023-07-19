using System;
using System.Collections.Generic;

namespace Online_English_Quiz_Project.Models
{
    public partial class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
            UserAnswers = new HashSet<UserAnswer>();
        }

        public int QuestionId { get; set; }
        public string? QuestionText { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<UserAnswer> UserAnswers { get; set; }
    }
}
