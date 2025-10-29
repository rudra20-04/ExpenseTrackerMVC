using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ExpenseTracker.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var totalExpense = await _context.Expenses.SumAsync(e => (decimal?)e.Amount) ?? 0;
            var totalIncome = await _context.Incomes.SumAsync(i => (decimal?)i.Amount) ?? 0;

            ViewBag.TotalExpense = totalExpense;
            ViewBag.TotalIncome = totalIncome;
            ViewBag.Balance = totalIncome - totalExpense;

            return View();
        }
    }
}
