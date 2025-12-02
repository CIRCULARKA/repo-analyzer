namespace RepoAnalyzer.Core.Rules;

/// <summary>
/// Rule DTO base
/// </summary>
public abstract record RuleDto
{
    /// <summary>
    /// Type of a rule
    /// </summary>
    public required RuleType Type { get; init; }
}
