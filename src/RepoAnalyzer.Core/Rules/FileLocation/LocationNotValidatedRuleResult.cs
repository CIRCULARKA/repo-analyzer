namespace RepoAnalyzer.Core.Rules.FileLocation;

/// <summary>
/// The result of a <see cref="FileLocationRule" />
/// when rule could not find file at specified location
/// </summary>
public class LocationNotValidatedRuleResult : RuleResult
{
    public override bool Success => false;
}
