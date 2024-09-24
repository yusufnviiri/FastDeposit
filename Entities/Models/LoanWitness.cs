using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
   public class LoanWitness
    {
        public int LoanWitnessId { get; set; }
        public string? FirstWitnessName { get; set; }
        public string? FirstWitnessContact { get; set; }
        public string? FirstWitnessResidence { get; set; }
        public string? SecondWitnessName { get; set; }
        public string? SecondWitnessContact { get; set; }
        public string? SecondWitnessResidence { get; set; }

        [ForeignKey(nameof(Loan))]
        public int LoanId { get; set; }
        public Loan? Loan { get; set; }
    }
}
