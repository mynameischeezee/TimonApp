using Microsoft.EntityFrameworkCore;
using Timon.DataAccess.Models;

namespace Timon.DataAccess.Data
{
    public class TimonDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<MoneyRecord> MoneyRecords { get; set; }
        public DbSet<TimeRecord> TimeRecords { get; set; }
        public DbSet<UserMoneyRecord> UserMoneyRecords { get; set; }
        public DbSet<UserTimeRecord> UserTimeRecords { get; set; }

        public TimonDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
