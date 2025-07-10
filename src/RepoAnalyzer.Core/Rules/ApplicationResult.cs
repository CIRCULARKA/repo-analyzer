namespace RepoAnalyzer.Core.Rules;

/// <summary>
/// Result of rule application
/// </summary>
public class ApplicationResult : IApplicationResult
{
    private bool _isObserved;

    public ApplicationResult(bool isObserved)
    {
        _isObserved = isObserved;
    }
}
