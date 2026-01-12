namespace Application.Common.Models;

using System;

/// <summary>
/// Minimal DTO used by the generator. Replace/extend with domain DTOs as needed.
/// </summary>
public record QuestDto
{
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string Author { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}
