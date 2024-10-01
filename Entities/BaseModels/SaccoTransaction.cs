using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.BaseModels
{
    public abstract class SaccoTransaction
    {
        public decimal? Amount { get; set; } = 0M;

        public decimal? Balance { get; set; } = 0M;

        public string? TransactionDate {  get; set; }= $"{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year} at {DateTime.Now.Hour}:{DateTime.Now.Minute}";
        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public ActiveAccount? ActiveAccount { get; set; }


        [ForeignKey(nameof(User))]
        [Column(TypeName = "nvarchar(450)")]
        public string? UserId { get; set; }
        public User? User { get; set; }

        public void SetBalance(decimal balance,string marker)
        {
            switch (marker.ToLower())
            {
                case "withdraw": this.Balance = this.Amount - balance; break;
                case "deposit":this.Balance = this.Amount + balance;break;
                default:this.Balance = balance; break;
            }
           
        }
    }
}
