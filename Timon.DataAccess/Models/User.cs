using Timon.Abstract.DataAccess;

namespace Timon.DataAccess.Models
{
    public class User : BaseEntity
    {
        public string? UserName { get; set; }
        public string Email { get; set; } = null!;
        public string? MonoBankApiKey { get; set; }
    }
}
