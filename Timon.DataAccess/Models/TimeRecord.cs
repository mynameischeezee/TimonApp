using Timon.Abstract.DataAccess;

namespace Timon.DataAccess.Models
{
    public class TimeRecord : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
    }
}
