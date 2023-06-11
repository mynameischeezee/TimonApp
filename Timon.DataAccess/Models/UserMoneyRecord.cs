using System.ComponentModel.DataAnnotations.Schema;
using Timon.Abstract.DataAccess;

namespace Timon.DataAccess.Models
{
    public class UserMoneyRecord : BaseEntity
    {
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public int MoneyRecordId { get; set; }

        [ForeignKey("MoneyRecordId")]
        public MoneyRecord MoneyRecord { get; set; } = null!;
    }
}
