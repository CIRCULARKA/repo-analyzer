namespace RepoAnalyzer.Core;

/// <summary>
/// A repository
/// </summary>
public interface IRepository
{
    /// <summary>
    /// Repository files
    /// </summary>
    public IReadOnlyList<File> Files { get; }
}
