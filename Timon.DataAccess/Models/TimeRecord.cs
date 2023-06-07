using Timon.Abstract.DataAccess;

namespace Timon.DataAccess.Models
{
    public class TimeRecord : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
