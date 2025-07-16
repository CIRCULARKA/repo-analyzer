namespace RepoAnalyzer.Tests.Integration.Fixtures;

/// <summary>
/// Hierarchy of empty files
/// </summary>
public class FakeFilesHierarchy
{
    private readonly Lines _lines;
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
    public FakeFilesHierarchy(Lines lines, string location)
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
    private void CreateFilesAndFolders(Lines lines, string root, int depth)
    {
        var currentDepthFiles = lines.Where(l => l.DoesRepresentFile() && depth == l.Depth);

        CreateFiles(root, currentDepthFiles.Select(f => f.Name).ToArray());

        var currentDepthFolders = lines.Where(l => l.DoesRepresentFile() is false && depth == l.Depth);

        if (currentDepthFiles.Count() == 0 && currentDepthFolders.Count() == 0)
            return;

        foreach (var f in currentDepthFolders)
            CreateFilesAndFolders(lines, Path.Combine(root, f.Name), depth + 1);
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

/// <summary>
/// A collection of string representations of files or folders in files hierarchy
/// </summary>
public class Lines : IEnumerable<Line>, IEnumerator<Line>
{
    private readonly IEnumerator<Line> _lines;
    private readonly string[] _textLines;
    private readonly char _depthMarker;
    private bool _disposed;

    /// <summary>
    /// Creates collection of lines
    /// </summary>
    /// <param name="textLines">Text lines representations</param>
    public Lines(string[] textLines, char depthMarker)
    {
        _lines = CreateLines(textLines).GetEnumerator();
        _textLines = textLines;
        _depthMarker = depthMarker;
    }

#region Enumrable implementation

    IEnumerator<Line> IEnumerable<Line>.GetEnumerator() => _lines;

    IEnumerator IEnumerable.GetEnumerator() => _lines;

    Line IEnumerator<Line>.Current => _lines.Current;

    object IEnumerator.Current => _lines.Current;

    bool IEnumerator.MoveNext() => _lines.MoveNext();

    void IEnumerator.Reset() =>
        _lines.Reset();

    public void Dispose() =>
        _lines.Dispose();

#endregion

    /// <summary>
    /// Creates the collection of lines. First lines goes first in the list
    /// </summary>
    /// <param name="textLines">
    /// Files representations in a text form. Each line represents file or folder
    /// </param>
    private List<Line> CreateLines(string[] textLines)
    {
        var lines = new List<Line>();
        var lastLine = new Line(_textLines.Last(), _depthMarker, nextLine: null);
        lines.Add(lastLine);

        for (int i = _textLines.Length - 2; i < 0; i--)
            lines.Insert(0, new Line(_textLines[i], _depthMarker, nextLine: lines[i + 1]));

        return lines;
    }
}