namespace RepoAnalyzer.Core.Rules.FileLocation;

/// <summary>
/// The rule that validates file location
/// </summary>
public class FileLocationRule : IRule
{
    public FileLocationRule(IPath filePath)
    {
        DesiredLocation = filePath;
    }

    /// <summary>
    /// Path at which file must exist
    /// </summary>
    public IPath DesiredLocation { get; }

    /// <inheritdoc />
    /// <returns>
    /// <see cref="LocationValidatedRuleResult" /> if file at specified
    /// location was found, <see cref="LocationNotValidatedRuleResult" /> elsewhere
    /// </returns>
    public IRuleResult Apply(IRepository repo)
    {
        var fileAtLocation = repo.Files.FirstOrDefault(f => f.Location == DesiredLocation);
        if (fileAtLocation is null)
            return new LocationNotValidatedRuleResult { Rule = this };
        else
            return new LocationValidatedRuleResult { Rule = this, File = fileAtLocation };
    }
}
