namespace RepoAnalyzer.Core.Rules;

/// <summary>
/// A ruleset - collection of rules
/// </summary>
public class Ruleset
{
    /// <summary>
    /// Collection of rules to apply to a repository
    /// </summary>
    public required IReadOnlyList<IRule> Rules { get; init; }

    /// <summary>
    /// Applies all rules to a repository
    /// </summary>
    /// <param name="repository">Repository</param>
    /// <param name="opts">Options</param>
    public IEnumerable<IRuleResult> Apply(IRepository repository, RulesetOptions opts)
    {
        foreach (var r in Rules)
        {
            var result = r.Apply(repository);
            if (result.Success is false && opts.FailFast)
            {
                yield return result;
                yield break;
            }

            yield return result;
        }
    }
}
