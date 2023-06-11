using System.ComponentModel.DataAnnotations.Schema;
using Timon.Abstract.DataAccess;

namespace Timon.DataAccess.Models;

public class Category : BaseEntity
{
    public string Name { get; set; } = null!;
    public int Priority { get; set; }
    public int UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }
}