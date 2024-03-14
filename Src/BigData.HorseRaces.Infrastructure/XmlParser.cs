using BigData.HorseRaces.Interfaces;

namespace BigData.HorseRaces.Infrastructure;

public class XmlParser : IFileParser
{
    public string ICanParseExtension() => "XML";

    public Task<IEnumerable<object>> ParseAsync(Stream stream)
    {
        throw new NotImplementedException();
    }
}
