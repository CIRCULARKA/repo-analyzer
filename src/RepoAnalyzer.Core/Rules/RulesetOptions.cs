namespace RepoAnalyzer.Core.Rules;

/// <summary>
/// Options that control ruleset behaviour
/// </summary>
public class RulesetOptions
{
    /// <summary>
    /// Should ruleset stop applying rules on first failed one?
    /// </summary>
    public required bool FailFast { get; init; }
}
