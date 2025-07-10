namespace RepoAnalyzer.Core.Rules;

/// <summary>
/// Source code location rule.
/// Ensures that all source code is located under specified folder
/// relative to the root of a repository and that the folder does exists
/// </summary>
public class SourceCodeLocationRule : IRepositoryRule
{
    private readonly string _ruleName;
    private readonly string _sourceCodeFolder;

    public SourceCodeLocationRule(string sourceCodeFolder, string ruleName)
    {
        _sourceCodeFolder = sourceCodeFolder;
        _ruleName = ruleName;
    }

    /// <summary>
    /// Applies the rule to repository files
    /// </summary>
    /// <param name="repositoryRoot">Корень репозитория</param>
    /// <param name="ct">Токен отмены операции</param>
    public async Task<ApplicationResult> ApplyAsync(IDirectoryInfo root, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
