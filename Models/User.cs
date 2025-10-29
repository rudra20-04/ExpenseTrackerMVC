using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required] public string Username { get; set; } = string.Empty;
        [Required] public string Password { get; set; } = string.Empty;
        [Required][EmailAddress] public string Email { get; set; } = string.Empty;
        [Required] public string Firstname { get; set; } = string.Empty;
        [Required] public string Lastname { get; set; } = string.Empty;

        public ICollection<Expense>? ExpenseList { get; set; }
    }
}
