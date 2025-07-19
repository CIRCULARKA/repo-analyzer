namespace RepoAnalyzer.Tests.FileStructure;

/// <summary>
/// A collection of files or folders in hierarchy for testing purposes
/// </summary>
public class TestFilesystemItems : IEnumerable<TestFilesystemItem>, IEnumerator<TestFilesystemItem>
{
    private readonly List<TestFilesystemItem> _lines;
    private readonly string[] _textLines;
    private readonly char _depthMarker;
    private IEnumerator<TestFilesystemItem> _currentEnumerator = null!;

    /// <summary>
    /// Creates collection of test filesystem items
    /// </summary>
    /// <param name="itemsRepresentations">Text lines representations</param>
    /// <param name="depthMarker">Marker that describes depth level of a file/folder represented by the line</param>
    public TestFilesystemItems(string[] itemsRepresentations, char depthMarker)
    {
        _depthMarker = depthMarker;
        _textLines = itemsRepresentations;
        _lines = CreateLines().ToList();
    }

    #region Enumrable implementation

    IEnumerator<TestFilesystemItem> IEnumerable<TestFilesystemItem>.GetEnumerator() => _currentEnumerator = _lines.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _currentEnumerator = _lines.GetEnumerator();

    TestFilesystemItem IEnumerator<TestFilesystemItem>.Current => _currentEnumerator.Current;

    object IEnumerator.Current => _currentEnumerator.Current;

    bool IEnumerator.MoveNext() => _currentEnumerator.MoveNext();

    void IEnumerator.Reset() => (_currentEnumerator as IEnumerator).Reset();

    public void Dispose() => _currentEnumerator.Dispose();

    #endregion

    /// <summary>
    /// Creates the collection of test items. First items goes first in the list
    /// </summary>
    private List<TestFilesystemItem CreateLines()
    {
        var lines = new List<TestFilesystemItem>();

        for (int i = 0; i < _textLines.Length; i--)
            lines.Add(new TestFilesystemItem(_textLines[i], _depthMarker));

        return lines;
    }
    
    public bool DoesRepresentFile(int lineIndex)
    {
        if (lineIndex >= _textLines.Length - 1)
            return true;

        // if (_textLines[lineIndex + 1] is null)
        //     return true;
        //
        // if (_nextLine.Depth == this.Depth)
        //     return true;
        //
        // if (_nextLine.Depth == this.Depth + 1)
        //     return false;
        //
        // if (_nextLine.Depth < this.Depth)
        //     return true;

        throw new InvalidOperationException(
            "Line can't be followed by other line with depth, bigger than by one"
        );
    }

    /// <summary>
    /// Create lines recursively
    /// </summary>
    /// <param name="textLines">
    /// Files representations in a text form. Each line represents file or folder
    /// </param>
    /// <param name="depthMarker">Depth marker</param>
    /// <returns>
    /// First created line
    /// </returns>
    private TestFilesystemItem CreateLinesRecursively(int index = 0)
    {
        TestFilesystemItem? nextLine = null;
        if (index < _textLines.Length - 1)
            nextLine = CreateLinesRecursively();

        var line = new TestFilesystemItem(_textLines[index], _depthMarker, nextLine);
        _lines.Insert(0, line);

        return line;
    }
}