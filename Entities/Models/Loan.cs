using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Loan
    {
        public int LoanId { get; set; }
        public decimal PrincipleAmount{ get; set; }
        public int Installements  { get; set; }
        public decimal CompoundAmount {  get; set; }
        public float Interest { get; set; } 
        public bool IsApproved { get; set; }
        public bool Status { get; set; }
        public string ApplicationDate { get; set; } = $"{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year} at {DateTime.Now.Hour}:{DateTime.Now.Minute}";
        [ForeignKey(nameof(LoanWitness))]
        public int LoanWitnessId { get; set; }
        public LoanWitness? LoanWitness { get; set; }
        [ForeignKey(nameof(LoanSecurity))]
        public int LoanSecurityId {  get; set; }
        public LoanSecurity? LoanSecurity { get; set; }

    }
}
