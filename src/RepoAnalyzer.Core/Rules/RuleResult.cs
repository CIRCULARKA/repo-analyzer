namespace RepoAnalyzer.Core.Rules;

/// <summary>
/// The default result of rule application
/// </summary>
public class RuleResult : IRuleResult
{
    public required IRule Rule { get; init; }

    public virtual bool Success { get; init; }
}
