using Contracts;
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
        public async Task<PagedList<Withdraw>> GetUserWithdraws(bool tracking, WithdrawParameters withdrawParameters, string UserId)
        {
            var count = await FindAll(tracking).CountAsync();
        var maxPages = Math.Ceiling((double)(count / (double)withdrawParameters.PageSize));
        //if (depositParameters.PageNumber == 1) { depositParameters.PageNumber = (int)maxPages; }
        var withdraws = await FindByCondition((k => k.UserId.Equals(UserId)), tracking).OrderByDescending(k => k.Id).Skip((withdrawParameters.PageNumber - 1) * withdrawParameters.PageSize).Take(withdrawParameters.PageSize).ToListAsync();
            //return PagedList<Deposit>.ToPageList(deposits, depositParameters.PageNumber,depositParameters.PageSize);
            return new PagedList<Withdraw>(withdraws, count, withdrawParameters.PageNumber, withdrawParameters.PageSize);
        }

}
}
