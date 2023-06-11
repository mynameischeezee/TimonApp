using System.ComponentModel.DataAnnotations.Schema;
using Timon.Abstract.DataAccess;
using Timon.DataAccess.Data;

namespace Timon.DataAccess.Models
{
    public class MoneyRecord : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public MoneyRecordType Type { get; set; }
    }
}
