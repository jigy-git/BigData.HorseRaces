using BigData.HorseRaces.Infrastructure;
using BigData.HorseRaces.Interfaces;
using Microsoft.Extensions.Logging;

namespace BigData.HorseRaces.Application;

public class FileProcessingService(ILogger<FileProcessingService> logger, IFileParserRegistry fileParserRegistry, IDataProcessor dataProcessor, IDataStore dataStore) : IFileProcessingService
{
    private readonly ILogger<FileProcessingService> _logger = logger;
    private readonly IFileParserRegistry _fileParserRegistry = fileParserRegistry;
    private readonly IDataProcessor _dataProcessor = dataProcessor;
    private readonly IDataStore _dataStore = dataStore;

    public async Task ProcessAsync(string filename, Stream stream)
    {
        var parser = _fileParserRegistry.GetParser(filename);

        var data = await parser.ParseAsync(stream);

        var processedData = await _dataProcessor.ProcessAsync(data);

        await _dataStore.StoreAsync(processedData);

        _logger.LogInformation($"C# Blob trigger function Processed blob\n Name: {filename} \n");
    }
}
