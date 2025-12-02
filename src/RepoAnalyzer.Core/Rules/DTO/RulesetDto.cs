namespace RepoAnalyzer.Core.Rules;

/// <summary>
/// DTO of a ruleset
/// </summary>
public record RulesetDto
{
    /// <summary>
    /// Rules
    /// </summary>
    public required List<RuleDto> Rules { get; init; }
}
