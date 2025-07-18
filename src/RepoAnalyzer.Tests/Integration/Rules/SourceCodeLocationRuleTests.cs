namespace RepoAnalyzer.Tests.Integration.Rules;

public class SourceCodeLocationRuleTests
{
    private readonly ITestOutputHelper _logger;

    public SourceCodeLocationRuleTests(ITestOutputHelper logger)
    {
        _logger = logger;
    }

    public static IEnumerable<object[]> TestData_ValidFileStructure =>
        new List<object[]>
        {
            // new object[]
            // {
            //     @"
            //         README.md
            //         src
            //         - Program.cs
            //     ",
            // },
            new object[]
            {
                @"
                    README.md
                    src
                    - Project.csproj
                    - Program.cs
                    - Core
                    -- Core.csproj
                    -- Class.cs
                    assets
                    - image.png
                ",
            },
        };

    [Theory]
    [MemberData(nameof(TestData_ValidFileStructure))]
    public void Apply_CalledOnValidFiles_ReturnsSuccess(string hierarchy)
    {
        // Arrange
        // var lines = hierarchy.Split(Environment.NewLine).Where(l => string.IsNullOrWhiteSpace(l) is false).Select(l => l.Trim());
        // int i = 0;
        // foreach (var l in lines)
        // {
        //     i++;
        //     _logger.WriteLine(i + ": " + l);
        // }
        CreateFakeFiles(hierarchy);
    }

    /// <summary>
    /// Creates file according to specified hierarchy
    /// </summary>
    /// <param name="hierarchy">Files hierarchy</param>
    private void CreateFakeFiles(string hierarchy) =>
        new FakeFilesHierarchy(
            new FakeFiles(
                hierarchy
                    .Split(Environment.NewLine)
                    .Where(l => string.IsNullOrWhiteSpace(l) is false)
                    .Select(l => l.Trim())
                    .ToArray(),
                '-'
            ),
            "/home/ruslan/Desktop/test"
        ).InitializeHierarchy();
}
