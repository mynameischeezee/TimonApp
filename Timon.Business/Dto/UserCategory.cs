namespace Timon.Business.Dto;

public class UserCategory
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public User User { get; set; }
    public Category Category { get; set; }
}