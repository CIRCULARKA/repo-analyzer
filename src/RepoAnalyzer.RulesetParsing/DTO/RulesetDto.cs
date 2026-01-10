namespace RepoAnalyzer.RulesetParsing.DTO;

/// <summary>
/// A DTO of a rule from a ruleset
/// </summary>
/// TODO: Stopped at making DTO for ruleset format
public class RuleDto
{
    /// <summary>
    /// The rule's type
    /// </summary>
    public RuleType Type { get; init; }

    /// <summary>
    /// The name of the rule
    /// </summary>
    public string Name { get; init; } = null!;

    /// <summary>
    /// The rule's description
    /// </summary>
    public string Description { get; init; } = null!;

    /// <summary>
    /// Message that should be displayed if rule
    /// wasn't pass
    /// </summary>
    public string ErrorMessage { get; init; } = null!;
}
