using System.ComponentModel.DataAnnotations.Schema;
using Timon.Abstract.DataAccess;

namespace Timon.DataAccess.Models
{
    public class UserTimeRecord : BaseEntity
    {
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public int TimeRecordId { get; set; }

        [ForeignKey("TimeRecordId")]
        public TimeRecord TimeRecord { get; set; } = null!;
    }
}
