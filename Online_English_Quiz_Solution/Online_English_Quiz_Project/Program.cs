namespace Online_English_Quiz_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();
            var app = builder.Build();
            app.UseSession();
            app.MapControllerRoute(
                name: "login",
                pattern: "/login",
                defaults: new { controller = "Authentication", action = "Login" }
             );
            app.MapControllerRoute(
                name: "logout",
                pattern: "/logout",
                defaults: new { controller = "Authentication", action = "Logout" }
             );
            app.MapControllerRoute(
               name: "home",
               pattern: "/home",
               defaults: new { controller = "Display", action = "Home" }
           );
            app.MapControllerRoute(
                name: "quiz",
                pattern: "/quiz/{quizId}",
                defaults: new { controller = "Quiz", action = "Quiz" }
            );
            app.MapControllerRoute(
                name: "submitQuiz",
                pattern: "/submit/{quizId}",
                defaults: new { controller = "Quiz", action = "Submit",method="post" }
            );
            app.MapControllerRoute(
                name: "result",
                pattern: "/result",
                defaults: new { controller = "Display", action = "Result" }
            );
            app.MapControllerRoute(
                name: "Statistic",
                pattern: "/statistic",
                defaults: new { controller = "Statistic", action = "Statistic" }
            );
            app.MapControllerRoute(
                name: "Statistic",
                pattern: "/statistic/{quizId}",
                defaults: new { controller = "Statistic", action = "Statistic" }
            );
            app.MapGet("/", context =>
            {
                context.Response.Redirect("/home");
                return Task.CompletedTask;

            });
            app.Run();
        }
    }
}