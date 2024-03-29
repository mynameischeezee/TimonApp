﻿namespace Timon.Business.Dto;

public class User
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string? UserName { get; set; }
    public string Email { get; set; } = null!;
    public string? MonoBankApiKey { get; set; }
}