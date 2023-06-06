using Timon.Abstract.DataAccess;

namespace Timon.DataAccess.Models
{
    public class MoneyRecord : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
