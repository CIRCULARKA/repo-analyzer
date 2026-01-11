namespace RepoAnalyzer.Tests.Unit.RulesetParsing;

public class YamlRulesetParserTests
{
    [Fact]
    [Trait("x", "x")]
    public void TestParse()
    {
        // Arrange
        var config = @"
            rules:
            - type: fileContent
              name: Company-wide .editorconfig
              description: Ensures presence of .editorconfig in repository's root
              errorMessage: There is no company-wide .editorconfig file in the root of the repo
              filePath:
                type: regex
                value: ^.editorconfig$
              fileContent:
                type: equalToFile
                value: /var/conventions/.editorconfig
              options:
                failFast: true
        ";

        var parser = new YamlRulesetParser();

        // Act
        var result = parser.ParseRuleset(config);

        // Arrange
    }
}
