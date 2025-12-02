namespace RepoAnalyzer.Core.Rules;

/// <summary>
/// Repository rule interface
/// </summary>
public interface IRule
{
    /// <summary>
    /// The type of the rule
    /// </summary>
    public RuleType Type { get; }

    /// <summary>
    /// Applies the rule to repository files
    /// </summary>
    /// <param name="repo">Repository to apply the rule to</param>
    public IRuleResult Apply(IRepository repo);
}