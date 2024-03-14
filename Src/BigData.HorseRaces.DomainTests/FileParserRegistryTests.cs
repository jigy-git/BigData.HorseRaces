
using BigData.HorseRaces.Domain;
using BigData.HorseRaces.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BigData.HorseRaces.DomainTests;

public class MoqJsonParser : IFileParser
{
    public string ICanParseExtension() => "json";
    public Task<IEnumerable<object>> ParseAsync(Stream stream)
    {
        throw new NotImplementedException();
    }
}

public class MoqXMLParser : IFileParser
{
    public string ICanParseExtension() => "xml";
    public Task<IEnumerable<object>> ParseAsync(Stream stream)
    {
        throw new NotImplementedException();
    }
}

public class MoqCSharpParser : IFileParser
{
    public string ICanParseExtension() => "cs";
    public Task<IEnumerable<object>> ParseAsync(Stream stream)
    {
        throw new NotImplementedException();
    }
}

public class MoqFixture
{
    public MoqFixture()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection
            .AddSingleton<IFileParser, MoqJsonParser>()
            .AddSingleton<IFileParser, MoqXMLParser>()
            .AddSingleton<IFileParser, MoqCSharpParser>();

        ServiceProvider = serviceCollection.BuildServiceProvider();
    }

    public ServiceProvider ServiceProvider { get; private set; }
}


public class FileParserRegistryTests : IClassFixture<MoqFixture>
{
    private ServiceProvider _serviceProvider;

    public FileParserRegistryTests(MoqFixture fixture)
    {
        _serviceProvider = fixture.ServiceProvider;
    }

    [Fact]
    public void GetParserReturnsRightParser()
    {
        var fileParserRegistry = new FileParserRegistry(_serviceProvider);

        var xmlParser = fileParserRegistry.GetParser("test.xml");

        Assert.NotNull(xmlParser);
        Assert.IsType<MoqXMLParser>(xmlParser);

        var xmlParser2 = fileParserRegistry.GetParser("test.XML");

        Assert.NotNull(xmlParser2);
        Assert.IsType<MoqXMLParser>(xmlParser2);

        var jsonParser = fileParserRegistry.GetParser("test.json");

        Assert.NotNull(jsonParser);
        Assert.IsType<MoqJsonParser>(jsonParser);


        var nullParser = fileParserRegistry.GetParser("test.dbf");

        Assert.Null(nullParser);
    }

}
