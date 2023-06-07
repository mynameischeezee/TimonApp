using Timon.Abstract.DataAccess;

namespace Timon.DataAccess.Models;

public class Category : BaseEntity
{
    public string Name { get; set; } = null!;
    public User? User { get; set; } = null!;
    public int Priority { get; set; }
}