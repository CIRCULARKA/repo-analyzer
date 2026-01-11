namespace RepoAnalyzer.RulesetParsing.DTO;

/// <summary>
/// A DTO for a file content specification
/// </summary>
public class FileContentDto
{
    /// <summary>
    /// The type of file content
    /// </summary>
    public FileContentType Type { get; init; }

    /// <summary>
    /// Path to file with content
    /// </summary>
    public string Value { get; init; } = null!;
}
