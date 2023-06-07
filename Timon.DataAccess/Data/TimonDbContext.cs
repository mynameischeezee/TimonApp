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

        /// <summary>
        /// Use this constructor for MIGRATING ONLY
        /// see: https://github.com/dotnet/efcore/issues/30268
        /// </summary>
        public TimonDbContext()
        {
            
        }

        /// <summary>
        /// Use this constructor for Maui project
        /// </summary>
        /// <param name="options"></param>
        public TimonDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
