using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ActiveAccount
    {
        [Column("ActiveAccountId")]
        public int Id { get; set; } 
        public decimal ActiveAmount { get; set; }
        public decimal ActiveBalance { get; set; }

        public string? TransactionDate { get; set; } = $"{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year} at {DateTime.Now.Hour}:{DateTime.Now.Minute}";
        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]

        [ForeignKey(nameof(User))]
        [Column(TypeName = "nvarchar(450)")]
        public string? UserId { get; set; }
        public User? User { get; set; }
        [ForeignKey(nameof(Deposit))]
        public int DepositId { get; set; }

        public Deposit? Deposit { get; set; }
        [ForeignKey(nameof(Withdraw))]
        public int WithdrawId { get; set; }

        public Withdraw? Withdraw { get; set; }
    }
}
