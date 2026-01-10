namespace RepoAnalyzer.RulesetParsing.DTO;

/// <summary>
/// A DTO for options of a ruleset
/// </summary>
public class OptionsDto
{
    /// <summary>
    /// Should ruleset be failed right after first rule
    /// was failed?
    /// </summary>
    public bool FailFast { get; init; }
}
