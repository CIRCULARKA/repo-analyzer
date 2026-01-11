namespace RepoAnalyzer.RulesetParsing.DTO;

/// <summary>
/// A DTO for file path specification
/// </summary>
public class FilePathDto
{
    /// <summary>
    /// The type of file content
    /// </summary>
    public FilePathType Type { get; init; }

    /// <summary>
    /// Path to file with content
    /// </summary>
    public string Value { get; init; } = null!;
}
