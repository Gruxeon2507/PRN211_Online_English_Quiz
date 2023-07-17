using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Online_English_Quiz_Project.Models;
using System;
using System.Web;

namespace Online_English_Quiz_Project.Controllers
{
    public class AuthenticationController : Controller
    {
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User loginUser)
        {
            if (ModelState.IsValid)
            {
                using(PRN211_Online_English_QuizContext context = new PRN211_Online_English_QuizContext())
                {
                    var user = context.Users.FirstOrDefault(u => u.Username == loginUser.Username && u.Password == loginUser.Password);
                    if (user != null)
                    {
                        HttpContext.Session.SetString("username", user.Username);
                        HttpContext.Session.SetString("displayName", user.DisplayName);
                        if (user.Username.Equals("admin"))
                        {
                            HttpContext.Session.SetString("role", "admin");

                        }
                        else
                        {
                            HttpContext.Session.SetString("role", "user");
                        }
                        return RedirectToAction("Home","Display");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid username or password");
                        return View(loginUser);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View(loginUser);
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("displayName");
            return RedirectToAction("Home", "Display");
        }

    }
}
