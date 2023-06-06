using Timon.Abstract.DataAccess;

namespace Timon.DataAccess.Models
{
    public class UserTimeRecord : BaseEntity
    {
        public User User { get; set; } = null!;
        public TimeRecord TimeRecord { get; set; } = null!;
    }
}
