using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DbMethods
{
   public sealed class RepositoryManager:IRepositoryManager
    {
        private readonly Lazy<IDepositRepository> _depositRepository;
        private readonly Lazy<IWithdrawRepository> _withdrawRepository;
        private readonly ApplicationDbContext _context;
        public RepositoryManager(ApplicationDbContext db)
        {
            _context = db;
            _depositRepository= new Lazy<IDepositRepository>(()=> new DepositRepository(db));
            _withdrawRepository = new Lazy<IWithdrawRepository>(()=> new WithdrawRepository(db));
            
        }
        public IDepositRepository DepositManager=> _depositRepository.Value;
        public IWithdrawRepository WithdrawManager => _withdrawRepository.Value;
        public async Task SaveAsync()=>await _context.SaveChangesAsync();
    }
}
