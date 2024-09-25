using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record ShowSaccoTransactionDto(int Id, decimal Amount, decimal Balance,string TransactionDate);
 
}
