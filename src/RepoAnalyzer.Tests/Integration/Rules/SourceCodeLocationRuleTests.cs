namespace RepoAnalyzer.Tests.Integration.Rules;

public class SourceCodeLocationRuleTests
{
    public IEnumerable<object[]> TestData_ValidFileStructure =>
        new List<object[]>
        {
            new object[]
            {
                @"
                    README.md
                    src
                    - Program.cs
                ",
                @"
                    README.md
                    src
                    - Project.csproj
                    - Program.cs
                    - Core
                    -- Core.csproj
                    -- Class.cs
                    assets
                    - image.png
                ",
            }
        };

    // [Theory]
    public async Task Apply_CalledOnValidFiles_ReturnsSuccess()
    {

    }

    /// <summary>
    /// Converts string representation of a file structure into hierarchy of files
    /// </summary>
    /// <param name="fileStructure">File structures in string representation</param>
    /// <remarks>
    /// Valid string representation is:
    /// file.ext
    /// folder1
    /// - file1
    /// - file2
    /// - subfolder1
    /// -- subfolderfile1
    /// ...
    /// </remarks>
    private IDirectoryInfo ConvertToDirectoryInfo(string fileStructure)
    {
    }
}
