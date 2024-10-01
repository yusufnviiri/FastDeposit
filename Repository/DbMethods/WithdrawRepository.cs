﻿using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DbMethods
{
   public class WithdrawRepository:RepositoryBase<Withdraw>,IWithdrawRepository
    {
        public WithdrawRepository(ApplicationDbContext db):base(db) { }

        public async Task<PagedList<Withdraw>> GetAllWithdraws(bool tracking,WithdrawParameters parameters)
        {


            var withdraws= await FindAll(tracking).OrderByDescending(k=>k.Id).Skip((parameters.PageNumber-1)*parameters.PageSize).Take(parameters.PageSize).ToListAsync();
            var count = await FindAll(tracking).CountAsync();
            return new PagedList<Withdraw>(withdraws, count,parameters.PageNumber,parameters.PageSize);

        }
        public void CreateWithdraw(Withdraw transact)=>Create(transact);
        public async Task<Withdraw> GetLastWithdraw()
        {
            var withdraw = await FindAll(tracking: false).ToListAsync();
            return withdraw.LastOrDefault();

        }

    }
}
