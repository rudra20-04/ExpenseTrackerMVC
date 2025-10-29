using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly AppDbContext _db;
        public ExpensesController(AppDbContext db) { _db = db; }

        public async Task<IActionResult> Index()
        {
            var uid = HttpContext.Session.GetInt32("UserId");
            if (uid == null) return RedirectToAction("Login", "Account");

            var list = await _db.Expenses
                .Include(e => e.Category)
                .Where(e => e.UserId == uid)
                .OrderByDescending(e => e.Date)
                .ToListAsync();
            return View(list);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_db.Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Expense expense)
        {
            var uid = HttpContext.Session.GetInt32("UserId");
            if (uid == null) return RedirectToAction("Login", "Account");

            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_db.Categories, "Id", "Name", expense.CategoryId);
                return View(expense);
            }

            expense.UserId = uid.Value;
            _db.Expenses.Add(expense);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var expense = await _db.Expenses.FindAsync(id);
            if (expense == null) return NotFound();

            ViewBag.Categories = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_db.Categories, "Id", "Name", expense.CategoryId);
            return View(expense);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Expense expense)
        {
            if (id != expense.Id) return NotFound();
            var uid = HttpContext.Session.GetInt32("UserId");
            if (uid == null) return RedirectToAction("Login", "Account");

            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_db.Categories, "Id", "Name", expense.CategoryId);
                return View(expense);
            }

            var e = await _db.Expenses.FindAsync(id);
            if (e == null) return NotFound();

            e.Title = expense.Title;
            e.Amount = expense.Amount;
            e.Date = expense.Date;
            e.CategoryId = expense.CategoryId;
            // keep e.UserId unchanged (should already be set)

            _db.Expenses.Update(e);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var expense = await _db.Expenses.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
            if (expense == null) return NotFound();
            return View(expense);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expense = await _db.Expenses.FindAsync(id);
            if (expense != null) { _db.Expenses.Remove(expense); await _db.SaveChangesAsync(); }
            return RedirectToAction(nameof(Index));
        }
    }
}
