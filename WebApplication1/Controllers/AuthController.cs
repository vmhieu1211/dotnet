using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

public class AuthController : Controller
{
    private readonly DataContext _context;
    private readonly IPasswordHasher<User> _passwordHasher;
    public AuthController(DataContext context, IPasswordHasher<User> passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }

    [HttpGet]
    public IActionResult Login()
    {
        if (HttpContext.Session.GetString("Email") != null)
        {
            return RedirectToAction("Index", "Home");
        }

        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == model.Email);
            if (user != null)
            {
                var result = _passwordHasher.VerifyHashedPassword(user, user.Password, model.Password);
                if (result == PasswordVerificationResult.Success)
                {
                    HttpContext.Session.SetString("Email", user.Email);
                    HttpContext.Session.SetString("UserId", user.Id.ToString());

                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Incorrect password. Please try again.");
            }

        }
        else
        {
            ModelState.AddModelError("", "Email address not found. Please check your email.");
        }

        return View(model);

    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        HttpContext.Session.Clear();

        return RedirectToAction("Login", "Auth");
    }

}
