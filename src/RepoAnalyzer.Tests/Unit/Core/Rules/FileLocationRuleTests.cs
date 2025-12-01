namespace RepoAnalyzer.Tests.Core.Rules;

public class FileLocationRuleTests
{
    public static IEnumerable<object[]> TestData_PositiveCases =>
        new List<object[]>
        {
            // Target file is somewhere in repository
            new object[]
            {
                new TestRepository("./a.txt", "./a/b.cs", "a/b/target_filename.txt", "a/b/c/d.ea"),
                new Regex(".*target_filename\\.txt.*"),
                // Expected file index
                2,
            },
            // Target file is first repository file
            new object[]
            {
                new TestRepository("a/b/target_filename.txt", "./a.txt", "a/b/c/d.ea"),
                new Regex(".*target_filename\\.txt.*"),
                0,
            },
            // Target file is last repository file
            new object[]
            {
                new TestRepository("a/b/c/d/.ea", "./a.txt", "a/b/target_filename.txt"),
                new Regex(".*target_filename\\.txt.*"),
                2,
            },
            // There are more than one matching file
            new object[]
            {
                new TestRepository(
                    "a/b/c/d/.ea",
                    "./a.txt",
                    "a/target.txt",
                    "a/b/target__filename.txt",
                    "a/b/c/target_filename.txt",
                    "a/c/text.txt",
                    "a/b/c/d/target_filename.txt"
                ),
                new Regex(".*target_filename\\.txt.*"),
                4,
            },
        };

    public static IEnumerable<object[]> TestData_NegativeCases =>
        new List<object[]>
        {
            // There is no matching file in repository
            new object[]
            {
                new TestRepository("./a.txt", "./a/b.cs", "a/b/target_filename1.txt", "a/b/c/d.ea"),
                new Regex(".*target_filename\\.txt.*"),
            },
            // There is no files in repository at all
            new object[] { new TestRepository(), new Regex(".*target_filename\\.txt.*") },
        };

    [Theory]
    [MemberData(nameof(TestData_PositiveCases))]
    public void Apply_ThereIsMatchingFileInRepository_ReturnsSuccessfulResult(
        IRepository repository,
        Regex regex,
        int _
    )
    {
        // Arrange
        var rule = new FileLocationRule(regex);

        // Act
        var result = rule.Apply(repository);

        // Assert
        Assert.True(result.Success);
    }

    [Theory]
    [MemberData(nameof(TestData_PositiveCases))]
    public void Apply_ThereIsMatchingFileInRepository_ReturnsLocationValidatedRuleResultl(
        IRepository repository,
        Regex regex,
        int _
    )
    {
        // Arrange
        var rule = new FileLocationRule(regex);

        // Act
        var result = rule.Apply(repository);

        // Assert
        Assert.IsType<LocationValidatedRuleResult>(result);
    }

    [Theory]
    [MemberData(nameof(TestData_PositiveCases))]
    public void Apply_ThereIsMatchingFileInRepository_ReturnsProperFile(
        IRepository repository,
        Regex regex,
        int expectedFileIndex
    )
    {
        // Arrange
        var rule = new FileLocationRule(regex);

        // Act
        var result = (LocationValidatedRuleResult)rule.Apply(repository);

        // Assert
        Assert.Equal(repository.Files[expectedFileIndex], result.File);
    }

    [Theory]
    [MemberData(nameof(TestData_PositiveCases))]
    public void Apply_ThereIsMatchingFileInRepository_ReturnsItselfInResult(
        IRepository repository,
        Regex regex,
        int _
    )
    {
        // Arrange
        var rule = new FileLocationRule(regex);

        // Act
        var result = rule.Apply(repository);

        // Assert
        Assert.Same(rule, result.Rule);
    }

    [Theory]
    [MemberData(nameof(TestData_NegativeCases))]
    public void Apply_ThereIsNoMatchingFileInRepository_ReturnsUnsuccessfullResult(
        IRepository repository,
        Regex regex
    )
    {
        // Arrange
        var rule = new FileLocationRule(regex);

        // Act
        var result = rule.Apply(repository);

        // Assert
        Assert.False(result.Success);
    }

    [Theory]
    [MemberData(nameof(TestData_NegativeCases))]
    public void Apply_ThereIsNoMatchingFileInRepository_ReturnsLocationNotValidatedRuleResult(
        IRepository repository,
        Regex regex
    )
    {
        // Arrange
        var rule = new FileLocationRule(regex);

        // Act
        var result = rule.Apply(repository);

        // Assert
        Assert.IsType<LocationNotValidatedRuleResult>(result);
    }

    [Theory]
    [MemberData(nameof(TestData_NegativeCases))]
    public void Apply_ThereIsNoMatchingFileInRepository_ReturnsItselfInResult(
        IRepository repository,
        Regex regex
    )
    {
        // Arrange
        var rule = new FileLocationRule(regex);

        // Act
        var result = rule.Apply(repository);

        // Assert
        Assert.Same(rule, result.Rule);
    }
}
