using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shared.DataTransferObjects
{
    //public record ShowSaccoTransactionDto(int DepopsitId, decimal Amount, decimal Balance,string TransactionDate,string UserId);
    //public record ShowSaccoTransactionDto( decimal Amount, decimal Balance, string TransactionDate);
    public record ShowSaccoTransactionDto(int Id=0, decimal Amount=0, decimal Balance=0, string TransactionDate="");

}
