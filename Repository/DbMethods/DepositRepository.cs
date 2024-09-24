using Contracts;
using Entities.Models;
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
    }
}
