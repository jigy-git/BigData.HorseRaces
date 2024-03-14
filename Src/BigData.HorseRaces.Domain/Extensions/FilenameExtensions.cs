namespace BigData.HorseRaces.Domain.Extensions;

public static class FilenameExtensions
{
    public static string GetFileExtension(this string filename)
    {
        FileInfo fi = new(filename);
        return fi.Extension.Replace(".", "");
    }
}
