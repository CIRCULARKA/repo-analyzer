namespace RepoAnalyzer.Tests.Integration.Fixtures;

/// <summary>
/// Fixture that allows to create files environment
/// </summary>
public class FilesFixture : IDisposable
{
    private readonly List<DirectoryInfo> _createdDirectories = new();

    /// <summary>
    /// Creates files according to specified hierarchy
    /// </summary>
    /// <param name="fileHierarchy">Hierarchy of files</param>
    /// <remarks>
    /// Valid string representation is:
    /// @"
    ///     file.ext
    ///     folder1
    ///     - file1
    ///     - file2
    ///     - subfolder1
    ///     -- subfolderfile1
    ///     ...
    /// "
    /// </remarks>
    public DirectoryInfo CreateFiles(string fileHierarchy)
    {
        var lines = fileHierarchy.Split(System.Environment.NewLine);

        var root = Directory.CreateDirectory(Guid.NewGuid().ToString());
        _createdDirectories.Add(root);

        foreach (var line in lines)
        {
            root.CreateSubdirectory();
        }

        throw new NotImplementedException();
    }

    private void CreateFilesAndFolders(int depth, DirectoryInfo root, string[] filenames, string[] folderNames)
    {

        foreach (var )
    }

    private void CreateDirectories(DirectoryInfo root, string[] directoryNames)
    {

    }

    private void CreateFiles(DirectoryInfo root, string[] filenames)
    {
        foreach (var f in filenames)
            File.Create(Path.Combine(root.FullName, f));
    }

    public void Dispose()
    {
        foreach (var d in _createdDirectories)
            d.Delete(recursive: true);

        GC.SuppressFinalize(this);
    }
}
