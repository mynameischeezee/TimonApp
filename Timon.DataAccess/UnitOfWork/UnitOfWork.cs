using Timon.Abstract.DataAccess.Repository;
using Timon.DataAccess.Context;
using Timon.DataAccess.Models;
using Timon.DataAccess.Repository;

namespace Timon.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TimonDbContext _context;
        private IGenericRepository<User> _users;
        private IGenericRepository<MoneyRecord> _moneyRecords;
        private IGenericRepository<TimeRecord> _timeRecords;
        private IGenericRepository<UserMoneyRecord> _userMoneyRecords;
        private IGenericRepository<UserTimeRecord> _userTimeRecords;
        private IGenericRepository<Category> _category;

        public IGenericRepository<User> Users => _users ??= new GenericRepository<User>(_context);
        public IGenericRepository<MoneyRecord> MoneyRecords => _moneyRecords ??= new GenericRepository<MoneyRecord>(_context);
        public IGenericRepository<TimeRecord> TimeRecords => _timeRecords ??= new GenericRepository<TimeRecord>(_context);
        public IGenericRepository<UserMoneyRecord> UserMoneyRecords => _userMoneyRecords ??= new GenericRepository<UserMoneyRecord>(_context);
        public IGenericRepository<UserTimeRecord> UserTimeRecords => _userTimeRecords ??= new GenericRepository<UserTimeRecord>(_context);
        public IGenericRepository<Category> Category => _category ??= new GenericRepository<Category>(_context);

        public UnitOfWork(TimonDbContext context)
        {
            _context = context;
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
