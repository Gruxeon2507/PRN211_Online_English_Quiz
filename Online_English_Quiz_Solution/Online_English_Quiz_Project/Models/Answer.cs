using System;
using System.Collections.Generic;

namespace Online_English_Quiz_Project.Models
{
    public partial class Answer
    {
        public int AnswerId { get; set; }
        public int? QuestionId { get; set; }
        public string? AnswerText { get; set; }
        public bool IsCorrectAnswer { get; set; }

        public virtual Question? Question { get; set; }
    }
}
