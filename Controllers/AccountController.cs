using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Data;
using ExpenseTracker.Models;

namespace ExpenseTracker.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _db;

        public AccountController(AppDbContext db)
        {
            _db = db;
        }

        // ✅ Register (GET)
        public IActionResult Register() => View();

        // ✅ Register (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                if (_db.Users.Any(u => u.Username == user.Username))
                {
                    TempData["ErrorMessage"] = "Username already exists!";
                    return View(user);
                }

                _db.Users.Add(user);
                _db.SaveChanges();

                TempData["SuccessMessage"] = "Account created successfully!";
                return RedirectToAction("Login");
            }
            return View(user);
        }

        // ✅ Login (GET)
        public IActionResult Login() => View();

        // ✅ Login (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string username, string password)
        {
            var user = _db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user == null)
            {
                TempData["ErrorMessage"] = "Invalid credentials!";
                return View();
            }

            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("Username", user.Username);

            return RedirectToAction("Index", "Dashboard");
        }

        // ✅ Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
