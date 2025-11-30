namespace RepoAnalyzer.Core.Rules;

/// <summary>
/// Repository rule interface
/// </summary>
public interface IRule
{
    /// <summary>
    /// Applies the rule to repository files
    /// </summary>
    /// <param name="repo">Repository to apply the rule to</param>
    public IRuleResult Apply(IRepository repo);
}
