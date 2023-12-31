﻿using System;
using System.Collections.Generic;

namespace Online_English_Quiz_Project.Models
{
    public partial class QuizQuestion
    {
        public int? QuizId { get; set; }
        public int? QuestionId { get; set; }

        public virtual Question? Question { get; set; }
        public virtual Quiz? Quiz { get; set; }
    }
}
