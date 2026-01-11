namespace RepoAnalyzer.RulesetParsing;

/// <summary>
/// Ruleset parser that parses ruleset from YAML format
/// </summary>
public class YamlRulesetParser
{
    public Ruleset ParseRuleset(string yaml)
    {
        var deserialiser = new DeserializerBuilder().WithCaseInsensitivePropertyMatching().Build();
        var dto = deserialiser.Deserialize<RulesetDto>(yaml);

    }
}
