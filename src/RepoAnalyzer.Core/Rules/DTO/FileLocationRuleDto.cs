namespace RepoAnalyzer.Core.Rules;

/// <summary>
/// DTO of a file location rule
/// </summary>
public record FileLocationRuleDto
{
    /// <summary>
    /// Regex pattern for file path that must be found
    /// </summary>
    public required string LocationPattern { get; init; }
}
