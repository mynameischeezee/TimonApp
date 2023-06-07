namespace Timon.Business.Dto;

public class UserTimeRecord
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public User User { get; set; } = null!;
    public TimeRecord TimeRecord { get; set; } = null!;
}