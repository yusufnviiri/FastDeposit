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
    public class DepositRepository:RepositoryBase<Deposit>,IDepositRepository
    {
        public DepositRepository(ApplicationDbContext db):base(db) 
        {
            
        }
        public async Task<PagedList<Deposit>> GetAllDeposits(bool tracking, DepositParameters depositParameters) { 
            
           var deposits = await FindAll(tracking).Skip((depositParameters.PageNumber-1)*depositParameters.PageSize).Take(depositParameters.PageSize).ToListAsync();

            var count = await FindAll(tracking).CountAsync();
            //return PagedList<Deposit>.ToPageList(deposits, depositParameters.PageNumber,depositParameters.PageSize);
            return new PagedList<Deposit>(deposits, count,depositParameters.PageNumber, depositParameters.PageSize);
        }

        public async Task<Deposit> FindDepositById(int id, bool tracking)=> await  FindByCondition(k=>k.Id.Equals(id),tracking).SingleOrDefaultAsync();

        public void CreateDeposit(Deposit deposit) => Create(deposit);

        //public async Task<Decimal> GetLastDepositAsync(bool tracking) => await GetLastTransaction(tracking).;
    
    }
}
