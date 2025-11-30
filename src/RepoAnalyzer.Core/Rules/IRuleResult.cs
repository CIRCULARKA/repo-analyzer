namespace RepoAnalyzer.Core.Rules;

/// <summary>
/// A result of a rule application
/// </summary>
public interface IRuleResult
{
    /// <summary>
    /// A rule that returned the result
    /// </summary>
    public IRule Rule { get; }

    /// <summary>
    /// Was rule application successful
    /// </summary>
    public bool Success { get; }
}
