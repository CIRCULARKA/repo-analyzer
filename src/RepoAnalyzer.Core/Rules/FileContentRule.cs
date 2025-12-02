namespace RepoAnalyzer.Core.Rules;

/// <summary>
/// The rule that validates file content
/// </summary>
public class FileContentRule : IRule
{
    private FileLocationRule _locationRule;
    private Regex _regex;

    public FileContentRule(FileLocationRule locationRule, Regex contentRegex)
    {
        _locationRule = locationRule;
        _regex = contentRegex;
    }

    public RuleType Type => RuleType.FileContent;

    public IRuleResult Apply(IRepository repo)
    {
        var locationResult = _locationRule.Apply(repo);
        if (locationResult.Success is false)
            return locationResult;

        var successLocationResult = (LocationValidatedRuleResult)locationResult;

        return new RuleResult
        {
            Rule = this,
            Success = _regex.Match(successLocationResult.File.Content).Success,
        };
    }
}