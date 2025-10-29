using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Models
{
    public class Income
    {
        [Key]
        public int Id { get; set; }  // Primary key

        [Required]
        public int UserId { get; set; } // Foreign key to User

        [Required]
        [StringLength(100)]
        public string Source { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
