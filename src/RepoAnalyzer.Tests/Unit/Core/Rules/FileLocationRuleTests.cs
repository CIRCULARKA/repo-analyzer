using File = RepoAnalyzer.Core.File;
using IPath = TruePath.IPath;

namespace RepoAnalyzer.Tests.Core.Rules;

public class FileLocationRuleTests
{
    public static IEnumerable<object[]> TestData_PositiveCases =>
        new List<object[]>
        {
            new object[]
            {
                LocalPath.Create("ThePath"),
                new File(LocalPath.Create("ThePath"), string.Empty),
            },
        };

    [Theory]
    [MemberData(nameof(TestData_PositiveCases))]
    public void Apply_CalledOnExistingFiles_ReturnsLocationValidatedResult(
        IPath path,
        File testFile
    )
    {
        // Arrange
        var rule = new FileLocationRule(path);

        // Act
        // TODO: Stopped here!
        rule.Apply()
    }
}
