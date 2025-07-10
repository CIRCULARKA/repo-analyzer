namespace RepoAnalyzer.Core.Rules;

/// <summary>
/// Repository rule interface
/// </summary>
public interface IRepositoryRule
{
    /// <summary>
    /// Applies the rule to repository files
    /// </summary>
    /// <param name="root">Information about repository folder root</param>
    /// <param name="ct">Cancellation token</param>
    public Task<ApplicationResult> ApplyAsync(IDirectoryInfo root, CancellationToken ct);
}
