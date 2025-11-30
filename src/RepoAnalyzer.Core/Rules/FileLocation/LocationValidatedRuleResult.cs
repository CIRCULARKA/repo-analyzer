namespace RepoAnalyzer.Core.Rules.FileLocation;

/// <summary>
/// The result of a <see cref="FileLocationRule" />
/// when the rule founds file at specified path
/// </summary>
public class LocationValidatedRuleResult : RuleResult
{
    public override bool Success => true;

    /// <summary>
    /// The file that was found at specified location
    /// </summary>
    public required File File { get; init; }
}
