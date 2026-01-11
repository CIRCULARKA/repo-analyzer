namespace RepoAnalyzer.RulesetParsing.DTO;

/// <summary>
/// A DTO for a ruleset
/// </summary>
public class RulesetDto
{
    /// <summary>
    /// A list of rules
    /// </summary>
    public List<RuleDtoV1> Rules { get; init; } = null!;
}
