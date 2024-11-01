﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Shared.DataTransferObjects;
using Shared.RequestParameters;

namespace Contracts
{
    public interface IDepositRepository
    {
       Task<PagedList<Deposit>> GetAllDeposits(bool tracking, DepositParameters depositParameters);
        Task<PagedList<Deposit>> GetUserDeposits(bool tracking, DepositParameters depositParameters,string UserId);
        Task<Deposit> FindDepositById( int id,bool tracking);

        //Task<Decimal> GetLastDeposit(bool tracking);
        void CreateDeposit(Deposit deposit);
       Task<bool> FindIfTransactionExists(string date, string userId, bool tracking);
    }
}
