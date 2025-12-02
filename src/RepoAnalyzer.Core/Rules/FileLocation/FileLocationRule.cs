namespace RepoAnalyzer.Core.Rules.FileLocation;

/// <summary>
/// The rule that validates file location
/// </summary>
public class FileLocationRule : IRule
{
    /// <summary>
    /// Creates file location rule
    /// </summary>
    /// <param name="locationRegex">Regex for searched file path</param>
    public FileLocationRule(Regex locationRegex)
    {
        LocationRegex = locationRegex;
    }

    public RuleType Type => RuleType.FileLocation;

    /// <summary>
    /// Regex that target file's path must match
    /// </summary>
    public Regex LocationRegex { get; }

    /// <inheritdoc />
    /// <returns>
    /// <see cref="LocationValidatedRuleResult" /> if file at specified
    /// location was found, <see cref="LocationNotValidatedRuleResult" /> elsewhere
    /// </returns>
    public IRuleResult Apply(IRepository repo)
    {
        var fileAtLocation = repo.Files.FirstOrDefault(f =>
            LocationRegex.Match(f.Location.Value).Success
        );
        if (fileAtLocation is null)
            return new LocationNotValidatedRuleResult { Rule = this };
        else
            return new LocationValidatedRuleResult { Rule = this, File = fileAtLocation };
    }
}
