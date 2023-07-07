using System;
using System.Collections.Generic;

namespace Online_English_Quiz_Project.Models
{
    public partial class User
    {
        public User()
        {
            Quizzes = new HashSet<Quiz>();
            UserQuizzes = new HashSet<UserQuiz>();
            Roles = new HashSet<Role>();
        }

        public string Username { get; set; } = null!;
        public string? Password { get; set; }
        public string? DisplayName { get; set; }
        public string? Email { get; set; }
        public DateTime? RegistrationDate { get; set; }

        public virtual ICollection<Quiz> Quizzes { get; set; }
        public virtual ICollection<UserQuiz> UserQuizzes { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
