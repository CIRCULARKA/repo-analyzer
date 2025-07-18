namespace RepoAnalyzer.Tests.FileStructure;

/// <summary>
/// A collection of string representations of files or folders in files hierarchy
/// </summary>
public class FakeFiles : IEnumerable<FakeFile>, IEnumerator<FakeFile>
{
    private readonly List<FakeFile> _lines;
    private readonly string[] _textLines;
    private readonly char _depthMarker;
    private IEnumerator<FakeFile> _currentEnumerator = null!;

    /// <summary>
    /// Creates collection of lines
    /// </summary>
    /// <param name="textLines">Text lines representations</param>
    /// <param name="depthMarker">Marker that describes depth level of a file/folder represented by the line</param>
    public FakeFiles(string[] textLines, char depthMarker)
    {
        _depthMarker = depthMarker;
        _textLines = textLines;
        _lines = CreateLines().ToList();
    }

    #region Enumrable implementation

    IEnumerator<FakeFile> IEnumerable<FakeFile>.GetEnumerator() => _currentEnumerator = _lines.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _currentEnumerator = _lines.GetEnumerator();

    FakeFile IEnumerator<FakeFile>.Current => _currentEnumerator.Current;

    object IEnumerator.Current => _currentEnumerator.Current;

    bool IEnumerator.MoveNext() => _currentEnumerator.MoveNext();

    void IEnumerator.Reset() => (_currentEnumerator as IEnumerator).Reset();

    public void Dispose() => _currentEnumerator.Dispose();

    #endregion

    /// <summary>
    /// Creates the collection of lines. First lines goes first in the list
    /// </summary>
    /// <param name="textLines">
    /// Files representations in a text form. Each line represents file or folder
    /// </param>
    /// <param name="depthMarker">Depth marker</param>
    private FakeFile[] CreateLines()
    {
        var lines = new FakeFile[_textLines.Length];
        var lastLine = new FakeFile(_textLines.Last(), _depthMarker, nextLine: null);
        lines[_textLines.Length - 1] = lastLine;

        for (int i = _textLines.Length - 2; i >= 0; i--)
            lines[i] = new FakeFile(_textLines[i], _depthMarker, nextLine: lines[i + 1]);

        return lines;
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
    private FakeFile CreateLinesRecursively(int index = 0)
    {
        FakeFile? nextLine = null;
        if (index < _textLines.Length - 1)
            nextLine = CreateLinesRecursively();

        var line = new FakeFile(_textLines[index], _depthMarker, nextLine);
        _lines.Insert(0, line);

        return line;
    }
}