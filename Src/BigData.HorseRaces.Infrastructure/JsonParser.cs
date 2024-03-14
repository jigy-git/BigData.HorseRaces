using BigData.HorseRaces.Interfaces;

namespace BigData.HorseRaces.Infrastructure;

public class JsonParser : IFileParser
{
    public string ICanParseExtension() => "JSON";

    public Task<IEnumerable<object>> ParseAsync(Stream stream)
    {
        throw new NotImplementedException();
    }
}
