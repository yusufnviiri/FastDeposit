﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DataTransferObjects;
using Shared.RequestParameters;

namespace Contracts.ServiceContracts
{
   public interface IDepositService
    {
        Task<(IEnumerable<ShowSaccoTransactionDto> deposits, MetaData metaData)> GetAllDeposits(bool tracking, DepositParameters depositParameters);
        Task<(IEnumerable<ShowSaccoTransactionDto> deposits, MetaData metaData)> GetAllUserDeposits(bool tracking, DepositParameters depositParameters, string Id);
        //Task<ShowSaccoTransactionDto> GetDepositById(int Id,bool tracking);
        Task<ShowSaccoTransactionDto> GetDepositById(int Id, bool tracking);

        Task<ShowSaccoTransactionDto> CreateDeposit(CreateSaccoTransactionDto transaction,string Id);
        Task CreateDepositFromExcelData();


    }
}
