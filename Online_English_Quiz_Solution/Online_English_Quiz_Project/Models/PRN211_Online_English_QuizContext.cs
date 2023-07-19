using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Online_English_Quiz_Project.Models
{
    public partial class PRN211_Online_English_QuizContext : DbContext
    {
        public PRN211_Online_English_QuizContext()
        {
        }

        public PRN211_Online_English_QuizContext(DbContextOptions<PRN211_Online_English_QuizContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answers { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<Quiz> Quizzes { get; set; } = null!;
        public virtual DbSet<QuizQuestion> QuizQuestions { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserAnswer> UserAnswers { get; set; } = null!;
        public virtual DbSet<UserQuiz> UserQuizzes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=LAPTOP-EKELI1UA;database=PRN211_Online_English_Quiz;uid=duckm;pwd=Password123#@!;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>(entity =>
            {
                entity.ToTable("Answer");

                entity.Property(e => e.AnswerId).HasColumnName("answerId");

                entity.Property(e => e.AnswerText)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("answerText");

                entity.Property(e => e.IsCorrectAnswer).HasColumnName("isCorrectAnswer");

                entity.Property(e => e.QuestionId).HasColumnName("questionId");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK__Answer__question__37A5467C");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question");

                entity.Property(e => e.QuestionId).HasColumnName("questionId");

                entity.Property(e => e.QuestionText)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("questionText");
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.ToTable("Quiz");

                entity.Property(e => e.QuizId).HasColumnName("quizId");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.QuizDescription)
                    .IsUnicode(false)
                    .HasColumnName("quizDescription");

                entity.Property(e => e.QuizTitle)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("quizTitle");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Quizzes)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__Quiz__created_by__2C3393D0");
            });

            modelBuilder.Entity<QuizQuestion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("QuizQuestion");

                entity.Property(e => e.QuestionId).HasColumnName("questionId");

                entity.Property(e => e.QuizId).HasColumnName("quizId");

                entity.HasOne(d => d.Question)
                    .WithMany()
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK__QuizQuest__quest__34C8D9D1");

                entity.HasOne(d => d.Quiz)
                    .WithMany()
                    .HasForeignKey(d => d.QuizId)
                    .HasConstraintName("FK__QuizQuest__quizI__33D4B598");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("roleId");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("roleName");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__User__F3DBC573F07D2CD4");

                entity.ToTable("User");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .HasColumnName("displayName");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("date")
                    .HasColumnName("registrationDate");

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Usernames)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserRole",
                        l => l.HasOne<Role>().WithMany().HasForeignKey("RoleId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserRole__roleId__29572725"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("Username").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserRole__userna__286302EC"),
                        j =>
                        {
                            j.HasKey("Username", "RoleId").HasName("PK__UserRole__4F02411163CBB1D5");

                            j.ToTable("UserRole");

                            j.IndexerProperty<string>("Username").HasMaxLength(255).IsUnicode(false).HasColumnName("username");

                            j.IndexerProperty<int>("RoleId").HasColumnName("roleId");
                        });
            });

            modelBuilder.Entity<UserAnswer>(entity =>
            {
                entity.HasKey(e => new { e.QuizId, e.QuestionId, e.Username })
                    .HasName("PK__UserAnsw__8B251AB3BCAAD438");

                entity.ToTable("UserAnswer");

                entity.Property(e => e.QuizId).HasColumnName("quizId");

                entity.Property(e => e.QuestionId).HasColumnName("questionId");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.AnswerId).HasColumnName("answerId");

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.UserAnswers)
                    .HasForeignKey(d => d.AnswerId)
                    .HasConstraintName("FK__UserAnswe__answe__3C69FB99");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.UserAnswers)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserAnswe__quest__3B75D760");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.UserAnswers)
                    .HasForeignKey(d => d.QuizId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserAnswe__quizI__3A81B327");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.UserAnswers)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserAnswe__usern__3D5E1FD2");
            });

            modelBuilder.Entity<UserQuiz>(entity =>
            {
                entity.ToTable("UserQuiz");

                entity.Property(e => e.DateTaken)
                    .HasColumnType("datetime")
                    .HasColumnName("dateTaken");

                entity.Property(e => e.QuizId).HasColumnName("quizId");

                entity.Property(e => e.Score).HasColumnName("score");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.UserQuizzes)
                    .HasForeignKey(d => d.QuizId)
                    .HasConstraintName("FK__UserQuiz__quizId__300424B4");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.UserQuizzes)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK__UserQuiz__userna__2F10007B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
