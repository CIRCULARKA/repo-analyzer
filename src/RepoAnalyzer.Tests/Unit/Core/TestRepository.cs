using File = RepoAnalyzer.Core.File;

namespace RepoAnalyzer.Tests.Core;

/// <summary>
/// Test repository
/// </summary>
public class TestRepository : IRepository
{
    /// <summary>
    /// Creates test repository with empty files
    /// </summary>
    /// <param name="fileNames">Filenames of empty files</param>
    public TestRepository(params string[] fileNames)
    {
        var files = new List<File>(fileNames.Length);
        foreach (var fn in fileNames)
            files.Add(new(location: LocalPath.Create(fn), content: string.Empty));

        Files = files.AsReadOnly();
    }

    public IReadOnlyList<File> Files { get; }
}
