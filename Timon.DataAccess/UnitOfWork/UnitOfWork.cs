using Timon.Abstract.DataAccess.Repository;
using Timon.DataAccess.Context;
using Timon.DataAccess.Models;
using Timon.DataAccess.Repository;

namespace Timon.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TimonDbContext _context;
        public IGenericRepository<User> Users { get; }
        public IGenericRepository<MoneyRecord> MoneyRecords { get;  }
        public IGenericRepository<TimeRecord> TimeRecords { get; }
        public IGenericRepository<UserMoneyRecord> UserMoneyRecords { get; }
        public IGenericRepository<UserTimeRecord> UserTimeRecords { get; }
        public IGenericRepository<Category> Category { get; }

        public UnitOfWork(TimonDbContext context,
            IGenericRepository<User> users, 
            IGenericRepository<MoneyRecord> moneyRecords, 
            IGenericRepository<TimeRecord> timeRecords,
            IGenericRepository<UserMoneyRecord> userMoneyRecords,
            IGenericRepository<UserTimeRecord> userTimeRecords, 
            IGenericRepository<Category> category)
        {
            _context = context;
            Users = users;
            MoneyRecords = moneyRecords;
            TimeRecords = timeRecords;
            UserMoneyRecords = userMoneyRecords;
            UserTimeRecords = userTimeRecords;
            Category = category;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
