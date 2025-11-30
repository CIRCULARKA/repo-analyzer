namespace RepoAnalyzer.Core;

/// <summary>
/// A file
/// </summary>
public class File
{
    public File(IPath path, string content)
    {
        ArgumentNullException.ThrowIfNull(content);

        Location = path;
        Content = content;
    }

    /// <summary>
    /// Location of a file relative to <see cref="IRepository" /> root
    /// </summary>
    public IPath Location { get; }

    /// <summary>
    /// The file's content
    /// </summary>
    public string Content { get; }

    public static bool operator ==(File left, File right) => left.Location == right.Location;

    public static bool operator !=(File left, File right) => !(left == right);

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;

        if (obj is not File)
            return false;

        var other = (File)obj;

        return this.Location == other.Location;
    }

    public override int GetHashCode() => Location.GetHashCode();
}
