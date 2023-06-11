using Timon.Abstract.DataAccess.Repository;
using Timon.DataAccess.Models;

namespace Timon.DataAccess.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<User> Users { get; }
    IGenericRepository<MoneyRecord> MoneyRecords { get; }
    IGenericRepository<TimeRecord> TimeRecords { get; }
    IGenericRepository<UserMoneyRecord> UserMoneyRecords { get; }
    IGenericRepository<UserTimeRecord> UserTimeRecords { get; }
    IGenericRepository<Category> Category { get; }
    Task Save();
}