namespace RepoAnalyzer.Tests.Integration.Fixtures;

/// <summary>
/// Hierarchy of empty files
/// </summary>
public class FakeFilesHierarchy
{
    private readonly string _filesHierarchy;
    private readonly char _depthMarker;

    /// <summary>
    /// Creates files hierarchy according to its string representation
    /// </summary>
    /// <param name="filesHierarchy">String representation of a hierarchy of files</param>
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
    public FakeFilesHierarchy(string filesHierarchy, char depthMarker)
    {
        _filesHierarchy = filesHierarchy;
        _depthMarker = depthMarker;
    }

    /// <summary>
    /// Creates files hierarchy with empty files
    /// </summary>
    public void InitializeHierarchy()
    {
        var textLines = _filesHierarchy.Split(System.Environment.NewLine);

        var lines = new Lines(textLines, _depthMarker).GetLines();

        foreach (var line in lines)
        {
            if (line.DoesRepresentFile())
        }
    }
}

/// <summary>
/// A collection of string representations of files or folders in files hierarchy
/// </summary>
public class Lines
{
    private readonly string[] _textLines;
    private readonly char _depthMarker;

    /// <summary>
    /// Creates collection of lines
    /// </summary>
    /// <param name="textLines">Text lines representations</param>
    public Lines(string[] textLines, char depthMarker)
    {
        _textLines = textLines;
        _depthMarker = depthMarker;
    }

    /// <summary>
    /// Creates the collection of lines. First lines goes first in the list
    /// </summary>
    public List<Line> GetLines()
    {
        if (_textLines.Length == 0)
            throw new InvalidOperationException("Lines must not be empty");

        var lines = new List<Line>();
        var lastLine = new Line(_textLines.Last(), _depthMarker, nextLine: null);
        lines.Add(lastLine);

        for (int i = _textLines.Length - 2; i < 0; i--)
            lines.Insert(0, new Line(_textLines[i], _depthMarker, nextLine: lines[i + 1]));

        return lines;
    }
}

/// <summary>
/// String representation that describes a file or a folder
/// </summary>
public class Line
{
    private readonly string _line;
    private readonly char _depthMarker;
    private readonly Line? _nextLine;

    /// <summary>
    /// Creates a line that represents a file or a folder. The line has depth that
    /// describes it's nesting in files hierarchy
    /// </summary>
    /// <param name="line">String representation of a line</param>
    /// <param name="depthMarker">
    /// Marker that describes a depth of a file/folder, described by the line.
    /// The more markers contains the string representation, the more depth it gets
    /// </param>
    public Line(string line, char depthMarker = '-', Line? nextLine = null)
    {
        _line = line;
        _depthMarker = depthMarker;
        _nextLine = nextLine;
    }

    /// <summary>
    /// The name of the line
    /// </summary>
    public string Name =>
        _line.Trim().Replace(_depthMarker.ToString(), string.Empty).Replace(" ", string.Empty);

    /// <summary>
    /// Depth in a file hierarchy of a file/folder that is described by the line
    /// </summary>
    public int Depth => _line.Where(c => c == _depthMarker).Count();

    /// <summary>
    /// Does the line represents a file
    /// </summary>
    /// <remarks>
    /// Line represents a file if it's does not followed by line with bigger depth
    /// </remarks>
    public bool DoesRepresentFile()
    {
        if (_nextLine is null)
            return true;

        if (_nextLine.Depth == this.Depth)
            return true;

        if (_nextLine.Depth == this.Depth + 1)
            return false;

        throw new InvalidOperationException(
            "Line can't be followed by other line with depth, bigger than one"
        );
    }
}

/// <summary>
/// Empty fake file
/// </summary>
public class FakeFile
{
    private readonly DirectoryInfo _root;
    private readonly string _filename;

    /// <summary>
    /// Initializes fake file
    /// </summary>
    /// <param name="root">Root of the file</param>
    /// <param name="name">A full name of the file</param>
    public FakeFile(DirectoryInfo root, string name)
    {
        _root = root;
        _filename = name;
    }

    /// <summary>
    /// Creates empty file
    /// </summary>
    public void Create()
    {
        if (string.IsNullOrWhiteSpace(_filename))
            throw new InvalidOperationException("A filename must not be empty");

        File.Create(Path.Combine(_root.FullName, _filename));
    }
}
