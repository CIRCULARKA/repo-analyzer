namespace RepoAnalyzer.Tests.FileStructure;

/// <summary>
/// Hierarchy of empty files
/// </summary>
public class FakeFilesHierarchy
{
    private readonly FakeFiles _lines;
    private readonly string _location;

    /// <summary>
    /// Creates files hierarchy according to its string representation
    /// </summary>
    /// <param name="filesHierarchy">String representation of a hierarchy of files</param>
    /// <param name="location">Root location of files hierarchy</param>
    /// <remarks>
    /// Valid string representation is (if depth marker is '-'):
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
    public FakeFilesHierarchy(FakeFiles lines, string location)
    {
        _lines = lines;
        _location = location;
    }

    /// <summary>
    /// Creates files hierarchy with empty files
    /// </summary>
    public void InitializeHierarchy()
    {
        CreateFilesAndFolders(_lines, _location, 0);
    }

    /// <summary>
    /// Creates files and folders at specified depth level recursively
    /// </summary>
    /// <param name="lines">Lines that descibe files and folders</param>
    /// <param name="root">Location relative to files should be created</param>
    /// <param name="depth">Depth of files in files hierarchy</param>
    private void CreateFilesAndFolders(FakeFiles lines, string root, int depth)
    {
        var currentDepthFiles = lines.Where(l => l.DoesRepresentFile() && depth == l.Depth).ToArray();

        CreateFiles(root, currentDepthFiles.Select(f => f.Name).ToArray());

        var currentDepthFolders = lines.Where(l => l.DoesRepresentFile() is false && depth == l.Depth).ToList();

        if (currentDepthFiles.Count() == 0 && currentDepthFolders.Count() == 0)
            return;

        foreach (var f in currentDepthFolders)
        {
            var newFolderName = Path.Combine(root, f.Name);
            Directory.CreateDirectory(newFolderName);
            CreateFilesAndFolders(lines, newFolderName, depth + 1);
        }
    }

    /// <summary>
    /// Creates files in specified folder
    /// </summary>
    /// <param name="folderPath">Path to folder</param>
    /// <param name="filenames">Names of files to create</param>
    private void CreateFiles(string folderPath, string[] filenames)
    {
        foreach (var f in filenames)
            File.Create(Path.Combine(folderPath, f));
    }
}