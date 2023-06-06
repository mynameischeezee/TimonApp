using Timon.Abstract.DataAccess;

namespace Timon.DataAccess.Models
{
    public class UserMoneyRecord : BaseEntity
    {
        public User User {get; set; } = null!;
        public MoneyRecord MoneyRecord { get; set; } = null!;
    }
}
