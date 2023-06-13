using System.ComponentModel.DataAnnotations.Schema;
using Timon.Abstract.DataAccess;

namespace Timon.DataAccess.Models
{
    public class TimeRecord : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [NotMapped]
        public string Duration => (DateTo - DateFrom).TotalMinutes.ToString();
    }
}
