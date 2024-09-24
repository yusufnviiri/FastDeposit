using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class LoanSecurity
    {
        public int LoanSecurityId { get; set; }
        public string? Description { get; set; }
        [ForeignKey(nameof(Loan))]

        public int LoanId { get; set; }
        public Loan? Loan { get; set; }
    }
}
