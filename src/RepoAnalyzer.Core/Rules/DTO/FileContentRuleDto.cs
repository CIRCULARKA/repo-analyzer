namespace RepoAnalyzer.Core.Rules;

/// <summary>
/// DTO of a file content rule
/// </summary>
public record FileContentRuleDto : FileLocationRuleDto
{
    /// <summary>
    /// Regex pattern for file content that must match
    /// </summary>
    public required string ContentPattern { get; init; }
}
