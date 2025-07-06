namespace RepoAnalyzer.Core;

/// <summary>
/// Repository rule interface
/// </summary>
public interface IRepositoryRule
{
}

/// <summary>
/// Source code location rule
/// </summary>
public class SourceCodeLocationRule : IRepositoryRule
{
    private readonly string _ruleName;

    public RepositoryRule(string ruleName)
    {
        _ruleName = ruleName;
    }

    /// <summary>
    /// Applies the rule to repository files
    /// </summary>
    /// <param name="ct">Токен отмены операции</param>
    public async Task ApplyAsync( CancellationToken ct)
    {

    }
}

/// <summary>
/// Result of rule application
/// </summary>
public class ApplicationResult : ApplicationResult
{
    private bool _isObserved;

    public ApplicationResult(bool isObserved)
    {
        _isObserved = isObserved;
    }
}

/// <summary>
/// Interface of a rule result
/// </summary>
public interface IApplicationResult
{
}
