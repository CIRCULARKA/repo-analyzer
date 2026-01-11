namespace RepoAnalyzer.RulesetParsing.DTO;

/// <summary>
/// A DTO of a rule from a ruleset. Version 1
/// </summary>
public class RuleDtoV1
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

    /// <summary>
    /// Content that must match
    /// </summary>
    public FileContentDto FileContent { get; init; } = null!;

    /// <summary>
    /// Path of the file that must pass requirements
    /// </summary>
    public FilePathDto FilePath { get; init; } = null!;

    /// <summary>
    /// The rule's options
    /// </summary>
    public OptionsDto Options { get; init; } = null!;
}
