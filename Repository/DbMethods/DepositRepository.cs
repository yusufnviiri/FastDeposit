using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IEnumerable<Deposit>> GetAllDeposits(bool tracking)=> await FindAll(tracking).OrderBy(k=>k.Amount).ToListAsync();

        public async Task<Deposit> FindDepositById(int id, bool tracking)=> await  FindByCondition(k=>k.Id.Equals(id),tracking).SingleOrDefaultAsync();

        public void CreateDeposit(Deposit deposit) => Create(deposit);
    }
}
