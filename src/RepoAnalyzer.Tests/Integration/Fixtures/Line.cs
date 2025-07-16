namespace RepoAnalyzer.Tests.Integration.Fixtures;

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
            "Line can't be followed by other line with depth, bigger than by one"
        );
    }
}