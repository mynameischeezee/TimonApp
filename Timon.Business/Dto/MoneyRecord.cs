namespace Timon.Business.Dto;

public class MoneyRecord
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public int Amount { get; set; }
    public DateTime Date { get; set; }
}