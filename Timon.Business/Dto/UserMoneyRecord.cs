namespace Timon.Business.Dto;

public class UserMoneyRecord
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public User User { get; set; } = null!;
    public MoneyRecord MoneyRecord { get; set; } = null!;
}