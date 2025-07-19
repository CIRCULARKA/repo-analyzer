namespace RepoAnalyzer.Tests.FileStructure;

/// <summary>
/// A fake file or folder for testing purposes
/// </summary>
public class TestFilesystemItem
{
    private readonly string _textRepresentation;
    private readonly char _depthMarker;

    /// <summary>
    /// Creates a filesystem item that represents a file or a folder. The item has depth that
    /// describes it's nesting in files hierarchy
    /// </summary>
    /// <param name="isFile">Does the item represents a file</param>
    /// <param name="textRepresentation">String representation of the item</param>
    /// <param name="depthMarker">
    /// Marker that describes a depth of a file/folder, described by it's text representation.
    /// The more markers contains the text representation, the more depth it gets
    /// </param>
    /// <param name="parent">Parent item that own the item in hierarchy</param>
    public TestFilesystemItem(bool isFile, string textRepresentation, char depthMarker = '-', TestFilesystemItem? parent = null)
    {
        _textRepresentation = textRepresentation;
        _depthMarker = depthMarker;
        Parent = parent;
    }

    /// <summary>
    /// The name of the item
    /// </summary>
    public string Name =>
        _textRepresentation.Replace(_depthMarker.ToString(), string.Empty).Replace(" ", string.Empty);

    /// <summary>
    /// Depth in a file hierarchy of a file/folder that is described by the item
    /// </summary>
    public int Depth => _textRepresentation.Where(c => c == _depthMarker).Count();

    /// <summary>
    /// Parent line
    /// </summary>
    public TestFilesystemItem? Parent { get; private init; }

    /// <summary>
    /// Does the item represents a file
    /// </summary>
    public bool IsFile { get; private init; }
}