using BigData.HorseRaces.Domain.Extensions;

namespace BigData.HorseRaces.DomainTests;

public class FilenameExtensionsTests
{
    [Theory]
    [InlineData(".pdf", "pdf")]
    [InlineData("wolferhamptonrace1.json", "json")]
    [InlineData("C:\\datasources\\races\\caulfieldrace1.xml", "xml")]
    [InlineData("test", "")]
    public void FileExtensionAreIdentifiedCorrectly(string filename, string filetypeExpected)
    {
        var fileExtn = filename.GetFileExtension();
        Assert.Equal(filetypeExpected, fileExtn);
    }
}