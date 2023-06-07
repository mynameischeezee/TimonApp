namespace Timon.Business.Dto;

public class Category
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Name { get; set; }
    public User? User { get; set; }
    public int Priority { get; set; }
}